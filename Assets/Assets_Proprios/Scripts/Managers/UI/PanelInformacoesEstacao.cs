using Classes;
using Controller;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Managers.UI
{
    class PanelInformacoesEstacao : MonoBehaviour
    {
        [SerializeField] private GameObject panelBotoes, panelInformacoesDetalhes;
        [SerializeField] private Button pfBtnOpcao;
        private Button btnFuncionamento, btnInformacoes, btnMelhorias;

        public void PreencherInformacoesEstacao(int id_estacao_tipo)
        {
            LimparValores();
            panelInformacoesDetalhes.GetComponent<PanelInformacoesDetalhes>().LimparValores();
            
            var estacao = ScoreManager.instance.GetEstacaoPorTipo(id_estacao_tipo);
            var emeS = EstacaoMelhoriaEstacaoController.ConsultarEstacaoMelhoriaEstacao(estacao.id_estacao);
            var et = EstacaoTipoController.EstacaoTipoPorId(id_estacao_tipo);

            panelInformacoesDetalhes.GetComponent<PanelInformacoesDetalhes>().SetValores(emeS, et);

            btnFuncionamento = Instantiate(pfBtnOpcao, panelBotoes.transform);
            btnFuncionamento.GetComponentInChildren<Text>().text = "Funcionamento";
            btnFuncionamento.onClick.AddListener(delegate {
                panelInformacoesDetalhes.GetComponent<PanelInformacoesDetalhes>().ExibirPanel(1);
                AlterarSpriteBotoes(1);
                Camera.main.GetComponents<AudioSource>()[2].Play();
            });

            btnInformacoes = Instantiate(pfBtnOpcao, panelBotoes.transform);
            btnInformacoes.GetComponentInChildren<Text>().text = "Informações";
            btnInformacoes.onClick.AddListener(delegate {
                panelInformacoesDetalhes.GetComponent<PanelInformacoesDetalhes>().ExibirPanel(2);
                AlterarSpriteBotoes(2);
                Camera.main.GetComponents<AudioSource>()[2].Play();
            });

            btnMelhorias = Instantiate(pfBtnOpcao, panelBotoes.transform);
            btnMelhorias.GetComponentInChildren<Text>().text = "Melhorias";
            btnMelhorias.onClick.AddListener(delegate {
                panelInformacoesDetalhes.GetComponent<PanelInformacoesDetalhes>().ExibirPanel(3);
                AlterarSpriteBotoes(3);
                Camera.main.GetComponents<AudioSource>()[2].Play();
            });

            btnFuncionamento.onClick.Invoke();
        }

        void AlterarSpriteBotoes(int idBotao)
        {
            switch (idBotao)
            {
                case 1:
                    btnFuncionamento.image.sprite = btnFuncionamento.spriteState.selectedSprite;
                    btnInformacoes.image.sprite = btnFuncionamento.spriteState.disabledSprite;
                    btnMelhorias.image.sprite = btnFuncionamento.spriteState.disabledSprite;
                    break;
                case 2:
                    btnFuncionamento.image.sprite = btnFuncionamento.spriteState.disabledSprite;
                    btnInformacoes.image.sprite = btnFuncionamento.spriteState.selectedSprite;
                    btnMelhorias.image.sprite = btnFuncionamento.spriteState.disabledSprite;
                    break;
                case 3:
                    btnFuncionamento.image.sprite = btnFuncionamento.spriteState.disabledSprite;
                    btnInformacoes.image.sprite = btnFuncionamento.spriteState.disabledSprite;
                    btnMelhorias.image.sprite = btnFuncionamento.spriteState.selectedSprite;
                    break;
            }
        }

        public void LimparValores()
        {
            foreach (Transform child in panelBotoes.transform)
            {
                Destroy(child.gameObject);
            }
        }

    }
}
