using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [Serializable]
    public class VersaoApk
    {
        public int id_versao;
        public string numero;
        public string data_inicio;
        public string data_fim;
        public bool ativo;
    }
}
