using Classes;
using Containers;
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
    class EstacaoMelhoriaController
    {
        public static List<EstacaoMelhoria> Consultar(int id_estacao_tipo, int id_tribo)
        {
            var path = String.Format("estacaoMelhoriaPorSabedoria?id_estacao_tipo={0}&id_tribo={1}", id_estacao_tipo, id_tribo);
            try
            {
                var jsonResponse = APIRequest.Get(path);
                var esMelhorias = JsonUtility.FromJson<EstacaoMelhoriaContainer>(jsonResponse).melhorias;
                return esMelhorias;
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
                                return BaseController<EstacaoMelhoriaContainer>.TryGetRefreshToken(path).melhorias;
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
