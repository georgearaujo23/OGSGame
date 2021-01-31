using Classes;
using System;
using UnityEngine;

namespace Controller
{
    class EstacaoTipoController
    {
        public static EstacaoTipo ConsultarPorId(int id_estacaoTipo)
        {
            var jsonResponse = APIRequest.Get(String.Format("estacaoTipo/{0}", id_estacaoTipo));
            var et = JsonUtility.FromJson<EstacaoTipo>(jsonResponse);
            return et;
        }
    }
}
