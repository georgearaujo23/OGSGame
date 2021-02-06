using Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Controller
{
    class DesafioJogadorController
    {
        public static DesafioJogador Inserir(int id_jogador, int id_desafio)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("id_jogador", id_jogador.ToString());
            parametros.Add("id_desafio", id_desafio.ToString());
            var path = "desafioJogador";
            try
            {
                var jsonResponse = APIRequest.Post(path, parametros);
                var desafioJogador = JsonUtility.FromJson<DesafioJogador>(jsonResponse);
                return desafioJogador;
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
                                return BaseController<DesafioJogador>.TryPostRefreshToken(path, parametros);
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
