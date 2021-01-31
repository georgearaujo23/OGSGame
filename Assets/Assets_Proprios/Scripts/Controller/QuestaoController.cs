using Classes;
using Containers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using UnityEngine;

namespace Controller
{
    class QuestaoController
    {
        public static Questao ConsultarPorId(int id_questao)
        {
            var jsonResponse = APIRequest.Get(String.Format("questao/{0}", id_questao));
            var questao = JsonUtility.FromJson<Questao>(jsonResponse);
            return questao;
        }

        public static List<Questao> ConsultarQuestoesDesafio(int quantidade_questoes, int id_desafio_jogador)
        {
            var jsonResponse = APIRequest.Get(String.Format("questoesNovoDesafio?quantidade_questoes={0}&id_desafio_jogador={1}", quantidade_questoes, id_desafio_jogador));
            var desafios = JsonUtility.FromJson<QuestaoContainer>(jsonResponse).questoes;
            return desafios;
        }

    }
}
