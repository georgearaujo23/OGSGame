using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [Serializable]
    public class Tribo
    {
        public int id;
        public int reputacao = 0;
        public int nivel = 0;
        public int nivel_sustentavel = 0;
        public int id_jogador = 0;
        public int acoes = 0;
        public int nivel_sabedoria = 0;
        public List<Estacao> estacoes;
    }
}
