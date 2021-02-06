using System;

namespace Classes
{
    [Serializable]
    public class EstacaoMelhoria
    {
        public int id_estacao_melhoria;
        public string nome;
        public string descricao;
        public int custo_moedas;
        public int energia;
        public int comida;
        public int agua;
        public int populacao;
        public int sustentabilidade;
        public int sabedoria;
        public int sabedoria_pesquisa;
        public bool pesquisado;
        public int id_estacao_tipo;
        public int id_estacao_melhoria_relacionada;
        public EstacaoTipo estacao_tipo;
    }
}
