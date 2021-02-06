using System;
using System.Collections.Generic;

namespace Classes
{
    [Serializable]
    public class Questao
    {
        public int id_questao;
        public string enunciado;
        public int id_assunto;
        public int nivel;
        public List<QuestaoAlternativa> alternativas;
    }
}
