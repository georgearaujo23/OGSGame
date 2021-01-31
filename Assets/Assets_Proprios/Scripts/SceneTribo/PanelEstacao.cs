using SceneLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.UI
{
    class PanelEstacao : PanelManager
    {
        [SerializeField] private GameObject estacaoFazenda;
        [SerializeField] private GameObject estacaoTreinamento;
        [SerializeField] private GameObject estacaoEnergia;
        [SerializeField] private GameObject estacaoAgua;
        [SerializeField] private Text nome;


        public void Abrir(int id_estacao_tipo, UIEstacaoManager uIEstacaoManager)
        {
            gameObject.SetActive(true);
            EstacaoInformacao ei;
            if (gameObject.TryGetComponent<EstacaoInformacao>(out ei))
            {
                ei.GetValores(id_estacao_tipo);
            }
            switch (id_estacao_tipo)
            {
                case 1:
                    nome.text = "Água Nv. " + ScoreManager.instance.GetEstacaoPorTipo(id_estacao_tipo).nivel.ToString();
                    estacaoAgua.SetActive(true);
                    estacaoFazenda.SetActive(false);
                    estacaoTreinamento.SetActive(false);
                    estacaoEnergia.SetActive(false);
                    break;
                case 2:
                    nome.text = "Fazenda Nv. " + ScoreManager.instance.GetEstacaoPorTipo(id_estacao_tipo).nivel.ToString();
                    estacaoAgua.SetActive(false);
                    estacaoFazenda.SetActive(true);
                    estacaoTreinamento.SetActive(false);
                    estacaoEnergia.SetActive(false);
                    break;
                case 3:
                    nome.text = "Biblioteca Nv. " + ScoreManager.instance.GetEstacaoPorTipo(id_estacao_tipo).nivel.ToString();
                    estacaoAgua.SetActive(false);
                    estacaoFazenda.SetActive(false);
                    estacaoTreinamento.SetActive(true);
                    estacaoEnergia.SetActive(false);
                    break;
                case 4:
                    nome.text = "Energia Nv. " + ScoreManager.instance.GetEstacaoPorTipo(id_estacao_tipo).nivel.ToString();
                    estacaoAgua.SetActive(false);
                    estacaoFazenda.SetActive(false);
                    estacaoTreinamento.SetActive(false);
                    estacaoEnergia.SetActive(true);
                    break;
            }


            PanelInformacoesEstacao pie = gameObject.GetComponentInChildren<PanelInformacoesEstacao>();
            if( pie != null){
                pie.PreencherInformacoesEstacao(id_estacao_tipo);
            }

            PanelOpcaoPesquisa pop = gameObject.GetComponentInChildren<PanelOpcaoPesquisa>();
            if (pop != null)
            {
                pop.PreencherMelhorias(id_estacao_tipo, uIEstacaoManager);
            }
            
        }

    }
}
