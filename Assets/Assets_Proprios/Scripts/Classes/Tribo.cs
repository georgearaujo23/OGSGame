﻿using System;
using System.Collections.Generic;

namespace Classes
{
    [Serializable]
    public class Tribo
    {
        public int id_tribo;
        public int reputacao;
        public int nivel;
        public int nivel_sustentavel;
        public int id_jogador;
        public int moedas;
        public int sabedoria;
        public int sabedoria_saldo;
        public int experiencia;
        public int experiencia_prox;
        public List<Estacao> estacoes;
        public Jogador jogador;

        public Tribo() {
            this.id_tribo = 0;
            this.reputacao = 0;
            this.nivel = 0;
            this.nivel_sustentavel = 0;
            this.id_jogador = 0;
            this.moedas = 0;
            this.sabedoria = 0;
            this.sabedoria_saldo = 0;
            this.experiencia = 0;
            this.experiencia_prox = 0;
            this.estacoes = new List<Estacao>();
    }

    }
}
