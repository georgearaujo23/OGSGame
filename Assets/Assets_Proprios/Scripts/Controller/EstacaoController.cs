using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Controller
{
    class EstacaoController
    {
        public static List<Estacao> estacoesPorTribo(int id_tribo)
        {
            var jsonResponse = APIRequest.Get(String.Format("estacoes/{0}", id_tribo));
            var estacoes = JsonUtility.FromJson<List<Estacao>>(jsonResponse);
            return estacoes;
        }
    }
}
