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
            var path = String.Format("tribo/{0}", id_tribo);
            try
            {
                var jsonResponse = APIRequest.Get(path);
                var tribo = JsonUtility.FromJson<Tribo>(jsonResponse);
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
                                return BaseController<Tribo>.TryGetRefreshToken(path);
                            }
                        }
                    }
                    var jsonResponse =
                        new StreamReader(webExcp.Response.GetResponseStream()).ReadToEnd();
                    var response = JsonUtility.FromJson<ResponseAPI>(jsonResponse);
                    throw new Exception(response.message);

                }
                throw webExcp;

            }
        }

        public static Tribo ConsultarPorUsuario()
        {
            if (!PlayerPrefs.HasKey("usuario")) {
                GameManager.instance.Logoff();
                return null;
            }
            if (PlayerPrefs.GetString("usuario").Equals(string.Empty)){
                GameManager.instance.Logoff();
                return null;
            }
            string path = String.Format("triboPorUsuario/{0}", PlayerPrefs.GetString("usuario"));
            try
            {
                var jsonResponse = APIRequest.Get(path);
                Debug.Log(jsonResponse);
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
                                return BaseController<Tribo>.TryGetRefreshToken(path);
                            }
                        }
                    }
                    var jsonResponse =
                        new StreamReader(webExcp.Response.GetResponseStream()).ReadToEnd();
                    var response = JsonUtility.FromJson<ResponseAPI>(jsonResponse);
                    throw new Exception(response.message);

                }
                throw webExcp;

            }
        }

    }
}
