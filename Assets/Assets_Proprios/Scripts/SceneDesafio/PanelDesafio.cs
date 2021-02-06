using Classes;
using Controller;
using Managers;
using SceneLoading;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace SceneDesafio
{
    class PanelDesafio :MonoBehaviour
    {
        [SerializeField]
        private GameObject content;
        [SerializeField]
        private GameObject panelQuestao, panelResultado;
        [SerializeField]
        private Button botaoVoltar;
        [SerializeField]
        private Button botaoVoltarQuestao;
        [SerializeField]
        private GameObject desafioPanel;
        [SerializeField]
        private Button botaoBonificacao;
        [SerializeField]
        private Sprite spriteMoedas, spriteSabedoria, spriteXP;

        private void Start()
        {
            botaoVoltar.onClick.AddListener(Voltar);
            botaoVoltarQuestao.onClick.AddListener(delegate {
                LimparDesafios();
                CarregarDesafios();
                VoltarQuestao();
            });
            CarregarDesafios();
        }

        void CarregarDesafios()
        {
            var desafios = DesafioController.Consultar(ScoreManager.instance.Id_jogador);
            foreach (var desafio in desafios)
            {
                var novoDesafio = Instantiate(desafioPanel, content.transform);
                var panelBonificacoes = novoDesafio.transform.GetChild(7);
                Text[] textos = novoDesafio.GetComponentsInChildren<Text>();
                Button btnResposta = novoDesafio.GetComponentInChildren<Button>();
                btnResposta.onClick.AddListener(delegate {
                    AudioManager.instance.PlayButtonClick();
                    ResponderDesafio(desafio);
                });
                textos[0].text = desafio.descricao;
                textos[2].text = desafio.quantidade_questoes.ToString();
                textos[4].text = desafio.quantidade_acertos.ToString();
                textos[6].text = DateTime.Parse(desafio.data_inicio).ToString("dd/MM/yyyy") + " - " + DateTime.Parse(desafio.data_fim).ToString("dd/MM/yyyy");

                var btnMoedas = Instantiate(botaoBonificacao, panelBonificacoes.transform);
                btnMoedas.image.sprite = spriteMoedas;
                var Text = btnMoedas.GetComponentInChildren<Text>();
                Text.text = "+" + desafio.moedas;

                var btnSabedoria = Instantiate(botaoBonificacao, panelBonificacoes.transform);
                btnSabedoria.image.sprite = spriteSabedoria;
                Text = btnSabedoria.GetComponentInChildren<Text>();
                Text.text = "+" + desafio.sabedoria;

                var btnXP = Instantiate(botaoBonificacao, panelBonificacoes.transform);
                btnXP.image.sprite = spriteXP;
                Text = btnXP.GetComponentInChildren<Text>();
                Text.text = "+" + desafio.xp;

            }

            void ResponderDesafio(Desafio desafio)
            {
                panelQuestao.SetActive(true);
                botaoVoltarQuestao.gameObject.SetActive(true);
                gameObject.SetActive(false);
                var pnQuestao = panelQuestao.GetComponent<PanelQuestao>();
                pnQuestao.CarregarDesafio(desafio.id_desafio, desafio.quantidade_questoes, desafio.quantidade_acertos);
            }
        }

        void Voltar()
        {
            GameManager.instance.LoadTribo();
        }

        void VoltarQuestao()
        {
            panelQuestao.SetActive(false);
            panelResultado.SetActive(false);
            botaoVoltarQuestao.gameObject.SetActive(false);
            gameObject.SetActive(true);
        }

        void LimparDesafios()
        {
            foreach (Transform child in content.transform)
            {
                Destroy(child.gameObject);
            }
            content.transform.DetachChildren();
        }

    }
}
