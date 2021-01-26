using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Controller
{
    class BaseController<T>
    {
        public static T TryRefreshToken(string path)
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

    }
}
