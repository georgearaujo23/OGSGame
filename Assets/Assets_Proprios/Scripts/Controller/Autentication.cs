using System;
using Classes;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Net.Security;

namespace Controller
{
    class Autentication
    {
        public ResponseAPI Autenticar(string email, string senha)
        {
            var rAPI = new ResponseAPI();
            try
            {
                var data_acesso = DateTime.Now;
                ICredentials credencial = new NetworkCredential(email, senha);
                HttpWebRequest requestAut = (HttpWebRequest)WebRequest.Create(String.Format(APIKey.URI + "auth?DATA_ACESSO={0}", data_acesso.ToString("yyyy/MM/dd")));
                requestAut.PreAuthenticate = true;
                requestAut.Credentials = credencial;
                requestAut.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificadoOGS.validador);
                requestAut.ContentType = "application/json";
                HttpWebResponse response2 = (HttpWebResponse)requestAut.GetResponse();
                StreamReader reader = new StreamReader(response2.GetResponseStream());
                var auth = reader.ReadToEnd();
                var apikey = JsonUtility.FromJson<APIKey>(auth);
                PlayerPrefs.SetString("apikey", apikey.API_CHAVE);
            }
            catch (WebException webExcp)
            {
                rAPI.status = false;
                if (webExcp.Status == WebExceptionStatus.ProtocolError) {
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
            return rAPI;
        }
    }
}
