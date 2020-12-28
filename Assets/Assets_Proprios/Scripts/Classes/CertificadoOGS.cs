using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Classes
{
    class CertificadoOGS
    {
        public static bool validador(System.Object sender, X509Certificate certificado, X509Chain x509Chain, SslPolicyErrors v)
        {
            X509Certificate cert = new X509Certificate("Assets/Assets_Proprios/Certificado/OGS.cert");
            if (!certificado.Equals(cert))
            {
                return false;
            }

            if (certificado.GetPublicKey().Equals(cert.GetPublicKey()))
            {
                return false;
            }
            if (DateTime.Parse(certificado.GetExpirationDateString()) < DateTime.Now)
            {
                return false;
            }

            return true;

        }

    }
}
