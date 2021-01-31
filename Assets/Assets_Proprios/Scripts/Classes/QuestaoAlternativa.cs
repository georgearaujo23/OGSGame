using System;

namespace Classes
{
    [Serializable]
    public class QuestaoAlternativa
    {
        public int id_questao_alternativa;
        public string texto;
        public int id_questao;
        public bool correta;
    }
}
