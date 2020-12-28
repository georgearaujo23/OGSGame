using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Classes
{
    [Serializable]
    class ResponseAPI
    {
        public string message = "Erro ao conectar ao servidor.";
        public bool status = true;
    }
}
