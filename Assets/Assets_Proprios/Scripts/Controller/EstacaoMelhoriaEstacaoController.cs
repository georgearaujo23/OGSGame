using Classes;
using Containers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controller
{
    class EstacaoMelhoriaEstacaoController
    {
        public static List<EstacaoMelhoriaEstacao> ConsultarPorIdEstacao(int id_estacao)
        {
            var jsonResponse = APIRequest.Get(String.Format("estacaoMelhoriaEstacaoPorEstacao?id_estacao={0}", id_estacao));
            var eMelhoriae = JsonUtility.FromJson<EstacaoMelhoriaEstacaoContainer>(jsonResponse).melhorias;
            return eMelhoriae;
        }

        public static EstacaoMelhoriaEstacao ConsultarEstacaoEmConstrucao(int id_estacao)
        {
            try
            {
                var jsonResponse = APIRequest.Get(String.Format("estacaoMelhoriaEmConstrucao?id_estacao={0}", id_estacao));
                Debug.Log(jsonResponse);
                var emeEmConstrucao = JsonUtility.FromJson<EstacaoMelhoriaEstacao>(jsonResponse);
                return emeEmConstrucao;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static Tribo Inserir(int id_estacao, int id_estacao_melhoria)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("id_estacao", id_estacao.ToString());
            parametros.Add("id_estacao_melhoria", id_estacao_melhoria.ToString());
            parametros.Add("nick_name", PlayerPrefs.GetString("usuario"));
            var jsonResponse = APIRequest.Post("estacaoMelhoria", parametros);
            var tribo = JsonUtility.FromJson<Tribo>(jsonResponse);
            return tribo;
        }

        public static Tribo AtualizarConstrucao(int idEstacaoMelhoriaEstacao)
        {
            Dictionary<string, string> parametros = new Dictionary<string, string>();
            parametros.Add("id_estacao_melhoria_estacao", idEstacaoMelhoriaEstacao.ToString());
            parametros.Add("nick_name", PlayerPrefs.GetString("usuario"));
            var jsonResponse = APIRequest.Post("estacaoMelhoriaEstacaoConstrucao", parametros);
            var tribo = JsonUtility.FromJson<Tribo>(jsonResponse);
            return tribo;
        }

    }
}
