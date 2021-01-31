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
    class DesafioController
    {
        public static List<Desafio> Consultar(int id_jogador)
        {
            var jsonResponse = APIRequest.Get(String.Format("desafios/{0}", id_jogador));
            var desafios = JsonUtility.FromJson<DesafioContainer>(jsonResponse).desafios;
            return desafios;
        }
    }
}
