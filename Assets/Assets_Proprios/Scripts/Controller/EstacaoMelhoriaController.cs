using Classes;
using Containers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Controller
{
    class EstacaoMelhoriaController
    {
        public static List<EstacaoMelhoria> Consultar(int id_estacao_tipo, int sabedoria)
        {
            var jsonResponse = APIRequest.Get(String.Format("estacaoMelhoriaPorSabedoria?id_estacao_tipo={0}&sabedoria={1}", id_estacao_tipo, sabedoria));
            var esMelhorias = JsonUtility.FromJson<EstacaoMelhoriaContainer>(jsonResponse).melhorias;
            return esMelhorias;
        }
    }
}
