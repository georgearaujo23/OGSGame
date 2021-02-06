using Controller;
using SceneLoading;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.UI
{
    class PanelInformacoesEstacao : MonoBehaviour
    {
        [SerializeField] private GameObject panelBotoes, panelInformacoesDetalhes;
        [SerializeField] private Button pfBtnOpcao;
        private Button btnFuncionamento, btnInformacoes, 
            btnMelhorias, btnDesafios, btnBonificacoes;

        public void PreencherInformacoesEstacao(int id_estacao_tipo)
        {
            LimparValores();
            panelInformacoesDetalhes.GetComponent<PanelInformacoesDetalhes>().LimparValores();
            
            var estacao = ScoreManager.instance.GetEstacaoPorTipo(id_estacao_tipo);
            var emeS = EstacaoMelhoriaEstacaoController.ConsultarPorIdEstacao(estacao.id_estacao);
            var et = EstacaoTipoController.ConsultarPorId(id_estacao_tipo);

            panelInformacoesDetalhes.GetComponent<PanelInformacoesDetalhes>().SetValores(emeS, et);

            btnFuncionamento = Instantiate(pfBtnOpcao, panelBotoes.transform);
            btnFuncionamento.GetComponentInChildren<Text>().text = "Funcionamento";
            btnFuncionamento.onClick.AddListener(delegate {
                panelInformacoesDetalhes.GetComponent<PanelInformacoesDetalhes>().ExibirPanel(1);
                AlterarSpriteBotoes(1);
                AudioManager.instance.PlayButtonClick();
            });

            btnInformacoes = Instantiate(pfBtnOpcao, panelBotoes.transform);
            btnInformacoes.GetComponentInChildren<Text>().text = "Informações";
            btnInformacoes.onClick.AddListener(delegate {
                panelInformacoesDetalhes.GetComponent<PanelInformacoesDetalhes>().ExibirPanel(2);
                AlterarSpriteBotoes(2);
                AudioManager.instance.PlayButtonClick();
            });

            btnMelhorias = Instantiate(pfBtnOpcao, panelBotoes.transform);
            btnMelhorias.GetComponentInChildren<Text>().text = "Melhorias";
            btnMelhorias.onClick.AddListener(delegate {
                panelInformacoesDetalhes.GetComponent<PanelInformacoesDetalhes>().ExibirPanel(3);
                AlterarSpriteBotoes(3);
                AudioManager.instance.PlayButtonClick();
            });
            if(id_estacao_tipo == 3)
            {
                OpcoesBilioteca();
            }
            btnFuncionamento.onClick.Invoke();
        }

        void OpcoesBilioteca()
        {
            btnDesafios = Instantiate(pfBtnOpcao, panelBotoes.transform);
            btnDesafios.GetComponentInChildren<Text>().text = "Desafios";
            btnDesafios.onClick.AddListener(delegate {
                AudioManager.instance.PlayButtonClick();
                AlterarSpriteBotoes(4);
                GameManager.instance.LoadDesafios();
            });

            btnBonificacoes = Instantiate(pfBtnOpcao, panelBotoes.transform);
            btnBonificacoes.GetComponentInChildren<Text>().text = "Bonificações";
            btnBonificacoes.onClick.AddListener(delegate {
                AudioManager.instance.PlayButtonClick();
                ScoreManager.instance.ExibirBonificacoes();
                GetComponentInParent<PanelManager>().gameObject.SetActive(false);
            });
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
