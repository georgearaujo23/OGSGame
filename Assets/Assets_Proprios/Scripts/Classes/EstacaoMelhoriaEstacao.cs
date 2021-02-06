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
        public bool esta_construindo;
        public string inicio_construcao;
        public string fim_construcao;
        public EstacaoMelhoria estacao_melhoria;

    }
}

