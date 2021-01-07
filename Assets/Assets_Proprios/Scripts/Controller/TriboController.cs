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
            var jsonResponse = APIRequest.Get(String.Format("tribo/{0}", id_tribo));
            var tribo = JsonUtility.FromJson<Tribo>(jsonResponse);
            return tribo;
        }

        public static Tribo TriboPorEmail(string email)
        {
            var jsonResponse = APIRequest.Get(String.Format("triboPorEmail/{0}", email));
            var tribo = JsonUtility.FromJson<Tribo>(jsonResponse);
            return tribo;
        }
    }
}
