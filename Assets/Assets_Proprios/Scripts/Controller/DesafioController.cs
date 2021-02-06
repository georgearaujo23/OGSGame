using Classes;
using Containers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

namespace Controller
{
    class DesafioController
    {
        public static List<Desafio> Consultar(int id_jogador)
        {
            var path = String.Format("desafios/{0}", id_jogador);
            try
            {
                var jsonResponse = APIRequest.Get(path);
                var desafios = JsonUtility.FromJson<DesafioContainer>(jsonResponse).desafios;
                return desafios;
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
                                return BaseController<DesafioContainer>.TryGetRefreshToken(path).desafios;
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
