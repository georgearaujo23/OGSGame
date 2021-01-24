using System;

namespace Classes
{
    [Serializable]
    public class EstacaoMelhoriaEstacao
    {
        public int id_estacao_melhoria_estacao;
        public int quantidade;
        public int id_estacao;
        public int id_estacao_melhoria;
        public EstacaoMelhoria estacao_melhoria;
    }
}

