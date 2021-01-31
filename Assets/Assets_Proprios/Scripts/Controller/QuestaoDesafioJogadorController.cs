using Classes;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    class QuestaoDesafioJogadorController
    {
        public static Tribo Inserir(int id_desafio_jogador, int id_questao, int id_desafio, int id_tribo, int id_questao_alternativa, bool terminou, bool acertou)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("id_desafio_jogador", id_desafio_jogador.ToString());
            parametros.Add("id_questao", id_questao.ToString());
            parametros.Add("id_desafio", id_desafio.ToString());
            parametros.Add("id_tribo", id_tribo.ToString()); 
            parametros.Add("id_questao_alternativa", id_questao_alternativa.ToString());
            parametros.Add("terminou", terminou ? "1" : "0");
            parametros.Add("acertou", acertou ? "1" : "0");
            parametros.Add("nick_name", PlayerPrefs.GetString("usuario"));
            var jsonResponse = APIRequest.Post("questaoDesafioJogador", parametros);
            var tribo = JsonUtility.FromJson<Tribo>(jsonResponse);
            return tribo;
        }
    }
}
