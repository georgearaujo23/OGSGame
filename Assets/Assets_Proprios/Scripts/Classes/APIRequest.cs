using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using System.Net.Security;
using SceneLoading;

namespace Classes
{
    class APIRequest
    {
        protected static void VerifiarToken()
        {
            var resul = false;
            if (!PlayerPrefs.HasKey("apiRefreshToken"))
                resul = true;
            if (PlayerPrefs.GetString("apiRefreshToken").Equals(String.Empty))
                resul = true;
            if (!PlayerPrefs.HasKey("apiToken"))
                resul = true;
            if (PlayerPrefs.GetString("apiToken").Equals(String.Empty))
                resul = true;

            if (resul)
            {
                GameManager.instance.Logoff();
                throw new Exception("Usuário não logado");
            }

        }

        public static void Autenticar(string usuario, string senha)
        {
            string postData = String.Format("user={0}&password={1}", usuario, senha);
            Debug.Log(postData);
            HttpWebRequest requestAut = (HttpWebRequest)WebRequest.Create(APIKey.URI + "auth");
            requestAut.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificadoOGS.validador);
            requestAut.AllowAutoRedirect = true;
            requestAut.AuthenticationLevel = AuthenticationLevel.MutualAuthRequired;
            requestAut.Method = "POST";
            byte[] data = Encoding.ASCII.GetBytes(postData);
            requestAut.ContentType = "application/x-www-form-urlencoded";
            requestAut.ContentLength = data.Length;

            Stream requestStream = requestAut.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            HttpWebResponse response = (HttpWebResponse)requestAut.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());

            var auth = reader.ReadToEnd();
            var apikey = JsonUtility.FromJson<APIKey>(auth);
            PlayerPrefs.SetString("apiToken", apikey.apiToken);
            PlayerPrefs.SetString("apiRefreshToken", apikey.apiRefreshToken);
            PlayerPrefs.SetString("usuario", usuario);
            PlayerPrefs.SetString("senha", senha);
        }

        public static bool RefreshAutenticacao()
        {
            string postData = String.Format("refreshToken={0}", PlayerPrefs.GetString("apiRefreshToken"));

            try
            {
                HttpWebRequest requestAut = (HttpWebRequest)WebRequest.Create(APIKey.URI + "refreshToken");
                requestAut.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificadoOGS.validador);
                requestAut.AllowAutoRedirect = true;
                requestAut.Method = "POST";
                byte[] data = Encoding.ASCII.GetBytes(postData);
                requestAut.ContentType = "application/json";
                requestAut.ContentLength = data.Length;

                Stream requestStream = requestAut.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse)requestAut.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());

                var auth = reader.ReadToEnd();
                var apikey = JsonUtility.FromJson<APIKey>(auth);
                Debug.Log(apikey.apiToken);
                Debug.Log(apikey.apiRefreshToken);
                PlayerPrefs.SetString("apiToken", apikey.apiToken);
                PlayerPrefs.SetString("apiRefreshToken", apikey.apiRefreshToken);
                return true;
            }
            catch (WebException webExcp)
            {

                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;

                    Debug.Log("Status HTML: " + httpResponse.StatusCode);
                }
                Debug.Log(webExcp.Message);
                return false;

            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return false;
            }

        }

        public static string Get(string path)
        {
            VerifiarToken();
            Debug.Log("URL+PATH: " + APIKey.URI + path);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIKey.URI + path);
            request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificadoOGS.validador);       
            request.ContentType = "application/json";
            request.AllowAutoRedirect = true;
            request.Headers.Set("X-Token", PlayerPrefs.GetString("apiToken"));
            request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequired;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var str = reader.ReadToEnd();
            Debug.Log("GET Retorno API:" + str);
            return str;
        }

        public static string GetSemToken(string path)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIKey.URI + path);
            request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificadoOGS.validador);
            request.ContentType = "application/json";
            request.AllowAutoRedirect = true;
            request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequired;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var str = reader.ReadToEnd();
            return str;
        }

        public static string Post(string path, Dictionary<string, string> postParameters)
        {
            VerifiarToken();
            string postData = "";

            foreach (string key in postParameters.Keys)
            {
                postData += key + "="
                        + postParameters[key] + "&";
            }
            Debug.Log(APIKey.URI + path + postData);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(APIKey.URI + path);
            request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificadoOGS.validador);
            request.AllowAutoRedirect = true;
            request.Headers.Set("X-Token", PlayerPrefs.GetString("apiToken"));
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
            var str = reader.ReadToEnd();
            Debug.Log("POST Retorno API:" + str);
            return str;
        }

    }
}
