using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Managers.UI
{
    class PanelEstacao : PanelManager
    {
        [SerializeField] private GameObject estacaoFazenda;
        [SerializeField] private GameObject estacaoTreinamento;
        [SerializeField] private GameObject estacaoEnergia;
        [SerializeField] private GameObject estacaoAgua;
        

        public void Abrir(int estacao)
        {
            gameObject.SetActive(true);
            gameObject.GetComponent<EstacaoInformacao>().GetValores(estacao);
            switch (estacao)
            {
                case 1:
                    estacaoAgua.SetActive(true);
                    estacaoFazenda.SetActive(false);
                    estacaoTreinamento.SetActive(false);
                    estacaoEnergia.SetActive(false);
                    break;
                case 2:
                    estacaoAgua.SetActive(false);
                    estacaoFazenda.SetActive(true);
                    estacaoTreinamento.SetActive(false);
                    estacaoEnergia.SetActive(false);
                    break;
                case 3:
                    estacaoAgua.SetActive(false);
                    estacaoFazenda.SetActive(false);
                    estacaoTreinamento.SetActive(true);
                    estacaoEnergia.SetActive(false);
                    break;
                case 4:
                    estacaoAgua.SetActive(false);
                    estacaoFazenda.SetActive(false);
                    estacaoTreinamento.SetActive(false);
                    estacaoEnergia.SetActive(true);
                    break;
            }
        }

    }
}
