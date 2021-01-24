using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    [Serializable]
    public class Estacao
    {
        public int id_estacao;
        public int producao;
        public int consumo;
        public int nivel;
        public int id_tribo;
        public int id_estacao_tipo;
        public int experiencia;
        public int experiencia_prox;
        public EstacaoTipo estacao_tipo;
    }
}
