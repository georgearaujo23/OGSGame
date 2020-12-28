using Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Controller
{
    class TriboController
    {
        public static Tribo TriboPorId(int id_tribo)
        {
            var tribo = new Tribo();
            var rAPI = new ResponseAPI();
            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(APIKey.URI + "tribo/{0}", id_tribo));
                request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificadoOGS.validador);
                request.ContentType = "application/json";
                request.AllowAutoRedirect = true;
                request.Headers.Set("X-Token", PlayerPrefs.GetString("apikey"));
                request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequired;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string jsonResponse = reader.ReadToEnd();
                tribo = JsonUtility.FromJson<Tribo>(jsonResponse);
            }
            catch (WebException webExcp)
            {
                rAPI.status = false;
                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    StreamReader reader = new StreamReader(httpResponse.GetResponseStream());
                    rAPI = JsonUtility.FromJson<ResponseAPI>(reader.ReadToEnd());
                    rAPI.status = false;
                }

            }
            catch (Exception e)
            {
                rAPI.status = false;
            }
            return tribo;
        }
    }
}
