using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [Serializable]
    class APIKey
    {
        public string apiToken;
        public string apiRefreshToken;
        //IFB
        //public static string URI = "https://api.guardioesdosaber.com.br/";
        //LOCAL
        public static string URI = "https://localhost/";
    }
}
