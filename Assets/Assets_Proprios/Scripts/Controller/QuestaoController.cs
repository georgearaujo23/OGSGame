using Classes;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using UnityEngine;

namespace Controller
{
    public  class QuestaoController
    {
        public static Questao questaoPorId(int id_questao)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create( String.Format(APIKey.URI + "questao/{0}", id_questao));
            request.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CertificadoOGS.validador);
            request.ContentType = "application/json";
            request.AllowAutoRedirect = true;
            request.Headers.Set("X-Token", PlayerPrefs.GetString("apikey")) ;
            request.AuthenticationLevel = AuthenticationLevel.MutualAuthRequired;
            
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            
            string jsonResponse = reader.ReadToEnd();
            var questao = JsonUtility.FromJson<Questao>(jsonResponse);
            return questao;
        }

    }
}
