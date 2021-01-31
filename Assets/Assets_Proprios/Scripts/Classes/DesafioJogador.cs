
using System;

namespace Classes
{
    [Serializable]
    public class DesafioJogador
    {
        public int id_desafio_jogador;
        public int id_jogador;
        public int id_desafio;
        public int quantidade_acertos;
        public int quantidade_respondida;
        public bool terminou;
    }
}
