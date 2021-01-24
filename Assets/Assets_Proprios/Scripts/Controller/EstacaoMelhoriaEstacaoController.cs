using Classes;
using Containers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    class EstacaoMelhoriaEstacaoController
    {
        public static List<EstacaoMelhoriaEstacao> ConsultarEstacaoMelhoriaEstacao(int id_estacao)
        {
            var jsonResponse = APIRequest.Get(String.Format("estacaoMelhoriaEstacaoPorEstacao?id_estacao={0}", id_estacao));
            var eMelhoriae = JsonUtility.FromJson<EstacaoMelhoriaEstacaoContainer>(jsonResponse).melhorias;
            return eMelhoriae;
        }

        public static Tribo InserirEstacaoMelhoriaEstacao(int id_estacao, int id_estacao_melhoria, int id_tribo)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("id_estacao", id_estacao.ToString());
            parametros.Add("id_estacao_melhoria", id_estacao_melhoria.ToString());
            parametros.Add("id_tribo", id_tribo.ToString());
            var jsonResponse = APIRequest.Post("estacao_melhoria", parametros);
            var tribo = JsonUtility.FromJson<Tribo>(jsonResponse);
            return tribo;
        }
    }
}
