using System;

namespace Classes
{
    [Serializable]
    class ResponseAPI
    {
        public string message = "Erro ao conectar ao servidor.";
        public int codErro = 1;
    }
}
