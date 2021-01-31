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
        public bool estaConstruindo;
        public string inicioConstrucao;
        public string fimConstrucao;
        public string horaServidor;
        public EstacaoMelhoria estacao_melhoria;

    }
}

