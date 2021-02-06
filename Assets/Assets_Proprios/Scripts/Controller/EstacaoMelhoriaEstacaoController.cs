using Classes;
using Containers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

namespace Controller
{
    class EstacaoMelhoriaEstacaoController
    {
        public static List<EstacaoMelhoriaEstacao> ConsultarPorIdEstacao(int id_estacao)
        {
            var path = String.Format("estacaoMelhoriaEstacaoPorEstacao?id_estacao={0}", id_estacao);
            try
            {
                var jsonResponse = APIRequest.Get(path);
                var eMelhoriae = JsonUtility.FromJson<EstacaoMelhoriaEstacaoContainer>(jsonResponse).melhorias;
                return eMelhoriae;
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
                                return BaseController<EstacaoMelhoriaEstacaoContainer>.TryGetRefreshToken(path).melhorias;
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

        public static EstacaoMelhoriaEstacao ConsultarEstacaoEmConstrucao(int id_estacao)
        {
            var path = String.Format("estacaoMelhoriaEmConstrucao?id_estacao={0}", id_estacao);
            try
            {
                var jsonResponse = APIRequest.Get(path);
                Debug.Log(jsonResponse);
                var emeEmConstrucao = JsonUtility.FromJson<EstacaoMelhoriaEstacao>(jsonResponse);
                return emeEmConstrucao;
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
                                return BaseController<EstacaoMelhoriaEstacao>.TryGetRefreshToken(path);
                            }
                        }
                    }
                    if (httpResponse.StatusCode == HttpStatusCode.PaymentRequired)
                    {
                        return null;
                    }
                        var jsonResponse =
                        new StreamReader(webExcp.Response.GetResponseStream()).ReadToEnd();
                    var response = JsonUtility.FromJson<ResponseAPI>(jsonResponse);
                    Debug.Log(webExcp.Message);
                    throw new Exception(response.message);

                }
                throw webExcp;

            }
        }

        public static Tribo Inserir(int id_estacao, int id_estacao_melhoria)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("id_estacao", id_estacao.ToString());
            parametros.Add("id_estacao_melhoria", id_estacao_melhoria.ToString());
            parametros.Add("nick_name", PlayerPrefs.GetString("usuario"));
            var path = "estacaoMelhoria";
            try
            {
                var jsonResponse = APIRequest.Post(path, parametros);
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
                                return BaseController<Tribo>.TryPostRefreshToken(path, parametros);
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

        public static Tribo AtualizarConstrucao(int idEstacaoMelhoriaEstacao)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("id_estacao_melhoria_estacao", idEstacaoMelhoriaEstacao.ToString());
            parametros.Add("nick_name", PlayerPrefs.GetString("usuario"));
            var path = "estacaoMelhoriaEstacaoConstrucao";
            try
            {
                var jsonResponse = APIRequest.Post(path, parametros);
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
                                return BaseController<Tribo>.TryPostRefreshToken(path, parametros);
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
