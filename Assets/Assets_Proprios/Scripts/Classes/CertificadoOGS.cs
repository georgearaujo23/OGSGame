using System;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

namespace Classes
{
    class CertificadoOGS : MonoBehaviour
    {
        private static string PUB_KEY = "3082010A0282010100D19A4CA1CC611FFBBE5EB1AAF54406674C0021B671239E60DD9A7F408D6AA9143981C113F9E6834F7C65DB7697BB867C6FBA90D9F1396B0530446377A3DAADC4A8F821AA5E65203842F54371C0F98DE70E9343F73BA45853529BB778AEFE8DE955BED98CEA627EB65F1BDF9D12D2588E3D0269A92908D009284148FE0137D213361B22004F5B7FE0568DB04D4FCF26C2853EB5514D8221574A0AE75E8525F83225F05E14AB57D6D0199509A5FD84A5D286278D667C54CE74EE10B201C63CB63E947A322997D9015BFACAEE8D49BD7E9176017CBE710F8AFE22E27A620CA63B28A3F9518AC6AEC0EAE370B824E08394A9A58E9A58551766DCA51B62716540EEB10203010001";
        public static bool validador(System.Object sender, X509Certificate certificado, X509Chain x509Chain, SslPolicyErrors v)
        {
            
            if (!certificado.GetPublicKeyString().Equals(PUB_KEY))
            {
                Debug.Log(certificado.GetPublicKeyString());
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
