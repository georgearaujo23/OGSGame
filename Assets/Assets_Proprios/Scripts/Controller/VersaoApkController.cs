using Classes;
using SceneLoading;
using System;
using System.IO;
using System.Net;
using UnityEngine;

namespace Controller
{
    class VersaoApkController
    {
        public static VersaoApk ConsultarVersaoAtiva()
        {
            string path = "versaoAtual";
            try
            {
                var jsonResponse = APIRequest.GetSemToken(path);
                Debug.Log(jsonResponse);
                var versao = JsonUtility.FromJson<VersaoApk>(jsonResponse);
                return versao;
            }
            catch (WebException webExcp)
            {
                throw webExcp;
            }
        }

    }
}
