using Classes;
using SceneLoading;
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
    class BaseController<T>
    {
        public static T TryGetRefreshToken(string path)
        {
            try
            {
                if (APIRequest.RefreshAutenticacao())
                {
                    Debug.Log("TryRefreshToken");
                    var jsonResponse = APIRequest.Get(String.Format(path));
                    var obj = JsonUtility.FromJson<T>(jsonResponse);
                    return obj;
                }
                else
                {
                    GameManager.instance.Logoff();
                }
                return default(T);
            }
            catch (WebException webExcp)
            {
                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    var jsonResponse =
                        new StreamReader(webExcp.Response.GetResponseStream()).ReadToEnd();
                    var response = JsonUtility.FromJson<ResponseAPI>(jsonResponse);
                    throw new Exception(response.message);
                }
                throw webExcp;
            }
        }

        public static T TryPostRefreshToken(string path, Dictionary<string, string> postParameters)
        {
            try
            {
                if (APIRequest.RefreshAutenticacao())
                {
                    var jsonResponse = APIRequest.Post(path, postParameters);
                    var obj = JsonUtility.FromJson<T>(jsonResponse);
                    return obj;
                }
                else
                {
                    GameManager.instance.Logoff();
                }
                return default(T);
            }
            catch (WebException webExcp)
            {
                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
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
