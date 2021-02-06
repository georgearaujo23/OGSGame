using Classes;
using Containers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using UnityEngine;

namespace Controller
{
    class QuestaoController
    {
        public static Questao ConsultarPorId(int id_questao)
        {
            var path = String.Format("questao/{0}", id_questao);
            try
            {
                var jsonResponse = APIRequest.Get(path);
                var questao = JsonUtility.FromJson<Questao>(jsonResponse);
                return questao;
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
                                return BaseController<Questao>.TryGetRefreshToken(path);
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

        public static List<Questao> ConsultarQuestoesDesafio(int quantidade_questoes, int id_desafio_jogador)
        {
            var path = String.Format("questoesNovoDesafio?quantidade_questoes={0}&id_desafio_jogador={1}", quantidade_questoes, id_desafio_jogador);
            try
            {
                var jsonResponse = APIRequest.Get(path);
                var desafios = JsonUtility.FromJson<QuestaoContainer>(jsonResponse).questoes;
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
                                return BaseController<QuestaoContainer>.TryGetRefreshToken(path).questoes;
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
