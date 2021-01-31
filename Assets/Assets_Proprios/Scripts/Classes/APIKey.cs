using System;

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
        public static string URI = "https://192.168.0.100/";
    }
}
