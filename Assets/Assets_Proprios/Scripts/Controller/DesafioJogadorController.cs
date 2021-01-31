using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Controller
{
    class DesafioJogadorController
    {
        public static DesafioJogador Inserir(int id_jogador, int id_desafio)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("id_jogador", id_jogador.ToString());
            parametros.Add("id_desafio", id_desafio.ToString());
            var jsonResponse = APIRequest.Post("desafioJogador", parametros);
            var desafioJogador = JsonUtility.FromJson<DesafioJogador>(jsonResponse);
            return desafioJogador;
        }
    }
}
