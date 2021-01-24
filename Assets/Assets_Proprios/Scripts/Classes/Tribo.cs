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
        public int id_tribo;
        public int reputacao = 0;
        public int nivel = 0;
        public int nivel_sustentavel = 0;
        public int id_jogador = 0;
        public int moedas = 0;
        public int nivel_sabedoria = 0;
        public int experiencia = 0;
        public int experiencia_prox = 0;
        public List<Estacao> estacoes;
    }
}
