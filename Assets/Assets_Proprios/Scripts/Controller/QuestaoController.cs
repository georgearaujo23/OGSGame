using Classes;
using System;
using System.IO;
using System.Net;
using System.Net.Security;
using UnityEngine;

namespace Controller
{
    public  class QuestaoController
    {
        public static Questao questaoPorId(int id_questao)
        {
            var jsonResponse = APIRequest.Get(String.Format("questao/{0}", id_questao));
            var questao = JsonUtility.FromJson<Questao>(jsonResponse);
            return questao;
        }

    }
}
