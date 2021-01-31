using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [Serializable]
    public class Desafio
    {
        public int id_desafio;
        public int moedas;
        public int sabedoria;
        public int quantidade_questoes;
        public int quantidade_acertos;
        public int xp;
        public string descricao;
        public string data_inicio;
        public string data_fim;
    }
}
