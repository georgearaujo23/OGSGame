using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [Serializable]
    public class Bonificacao
    {
        public int id_bonificacao;
        public int id_tribo;
        public int moedas;
        public int sabedoria;
        public int xp;
        public string descricao;
        public bool recebida;
    }
}

