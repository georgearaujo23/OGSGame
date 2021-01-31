using Classes;
using SceneLoading;
using System;
using System.IO;
using System.Net;
using UnityEngine;

namespace Controller
{
    class TriboController
    {
        public static Tribo ConsultarPorId(int id_tribo)
        {
            var jsonResponse = APIRequest.Get(String.Format("tribo/{0}", id_tribo));
            var tribo = JsonUtility.FromJson<Tribo>(jsonResponse);
            return tribo;
        }

        public static Tribo ConsultarPorUsuario()
        {
            if (!PlayerPrefs.HasKey("usuario")) {
                GameManager.instance.Logoff();
                throw new Exception("Usuário não logado");
            }
            if (PlayerPrefs.GetString("usuario").Equals(string.Empty)){
                GameManager.instance.Logoff();
                throw new Exception("Usuário não logado");
            }
           
            string path = String.Format("triboPorUsuario/{0}", PlayerPrefs.GetString("usuario"));
            try
            {
                var jsonResponse = APIRequest.Get(path);
                var tribo = JsonUtility.FromJson<Tribo> (jsonResponse);
                return tribo;
            }
            catch (WebException webExcp)
            {
                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    if (httpResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        if (PlayerPrefs.HasKey("apiRefreshToken"))
                        {
                            if (PlayerPrefs.GetString("apiRefreshToken") != String.Empty)
                            {
                                return BaseController<Tribo>.TryRefreshToken(path);
                            }
                        }
                    }
                    Debug.Log("Status HTML: " + httpResponse.StatusCode + " - " + HttpStatusCode.Unauthorized);
                    return null;
                }
                Debug.Log(webExcp.Message);
                return null;

            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return null;
            }
        }
    }
}
