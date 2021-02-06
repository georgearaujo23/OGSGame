using Classes;
using Containers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

namespace Controller
{
    class BonificacaoController
    {
        public static List<Bonificacao> Consultar(int id_tribo)
        {
            var path = String.Format("bonificacao?id_tribo={0}", id_tribo);
            try
            {
                var jsonResponse = APIRequest.Get(path);
                var bonificacoes = JsonUtility.FromJson<BonificacaoContainer>(jsonResponse).bonificacoes;
                return bonificacoes;
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
                                return BaseController<BonificacaoContainer>.TryGetRefreshToken(path).bonificacoes;
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

        public static List<Bonificacao> Receber(int id_bonificacao, int id_tribo)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("id_tribo", id_tribo.ToString());
            parametros.Add("id_bonificacao", id_bonificacao.ToString());
            var path = "receberBonificao";
            try
            {
                var jsonResponse = APIRequest.Post(path, parametros);
                var bonificacoes = JsonUtility.FromJson<BonificacaoContainer>(jsonResponse).bonificacoes;
                return bonificacoes;
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
                                return BaseController<BonificacaoContainer>.TryPostRefreshToken(path, parametros).bonificacoes;
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
