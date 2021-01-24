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
        public static List<EstacaoMelhoria> ConsultarEstacaoMelhoria(int id_estacao_tipo, int nivelEstacao)
        {
            var jsonResponse = APIRequest.Get(String.Format("estacaomelhoriaPorTipoNivel?id_estacao_tipo={0}&nivel={1}", id_estacao_tipo, nivelEstacao));
            var esMelhorias = JsonUtility.FromJson<EstacaoMelhoriaContainer>(jsonResponse).melhorias;
            return esMelhorias;
        }
    }
}
