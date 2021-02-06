using Classes;
using System;
using System.IO;
using System.Net;
using UnityEngine;

namespace Controller
{
    class EstacaoTipoController
    {
        public static EstacaoTipo ConsultarPorId(int id_estacaoTipo)
        {
            var path = String.Format("estacaoTipo/{0}", id_estacaoTipo);
            try
            {
                var jsonResponse = APIRequest.Get(path);
                var et = JsonUtility.FromJson<EstacaoTipo>(jsonResponse);
                return et;
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
                                return BaseController<EstacaoTipo>.TryGetRefreshToken(path);
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
