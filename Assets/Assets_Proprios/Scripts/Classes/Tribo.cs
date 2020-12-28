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
        public int producao_agua = 0;
        public int consumo_agua = 0;
        public int producao_comida = 0;
        public int consumo_comida = 0;
        public int producao_energia = 0;
        public int consumo_energia = 0;
        public int reputacao = 0;
        public int nivel = 0;
        public int nivel_sustentavel = 0;
        public int id_jogador = 0;
        public int acoes = 0;
        public int nivel_sabedoria = 0;
    }
}
