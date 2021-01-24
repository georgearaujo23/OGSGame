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

namespace Classes
{
    class APIRequest
    {
        public static void Autenticar(string email, string senha)
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
            Debug.Log(apikey.API_CHAVE);
            PlayerPrefs.SetString("apikey", apikey.API_CHAVE);
            PlayerPrefs.SetString("email", email);
            PlayerPrefs.SetString("senha", senha);
        }

        public static string Get(string path)
        {
            try
            {
                Debug.Log(APIKey.URI + path);
                Debug.Log(PlayerPrefs.GetString("apikey"));
                var email = "george";
                var senha = "abc123456";
                
                if (!PlayerPrefs.HasKey("apikey"))
                {
                    if (PlayerPrefs.GetString("apikey") == String.Empty)
                    {
                        
                        var a = new APIRequest();
                        APIRequest.Autenticar(email, senha);
                    }
                }
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIKey.URI + path);
                request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificadoOGS.validador);       
                request.ContentType = "application/json";
                request.AllowAutoRedirect = true;
                request.Headers.Set("X-Token", PlayerPrefs.GetString("apikey"));
                request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequired;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var str = reader.ReadToEnd();
                Debug.Log(str);
                return str;
            }
            catch (WebException webExcp)
            {
                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    StreamReader reader = new StreamReader(httpResponse.GetResponseStream());
                    var str = reader.ReadToEnd();
                    Debug.Log(str);
                    return str;
                }
                Debug.Log(webExcp.Message);
                return webExcp.Message;

            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return e.Message;
            }
        }

        public static string Post(string path, Dictionary<string, string> postParameters)
        {
            try
            {
                var email = "george";
                var senha = "abc123456";
                if (!PlayerPrefs.HasKey("apikey"))
                {
                    var a = new APIRequest();
                    APIRequest.Autenticar(email, senha);
                }
                string postData = "";

                foreach (string key in postParameters.Keys)
                {
                    postData += key + "="
                          + postParameters[key] + "&";
                }

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIKey.URI + path);
                request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificadoOGS.validador);
                request.AllowAutoRedirect = true;
                request.Headers.Set("X-Token", PlayerPrefs.GetString("apikey"));
                request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequired;
                request.Method = "POST";
                byte[] data = Encoding.ASCII.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                Stream requestStream = request.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return null;
            }
        }


    }
}
