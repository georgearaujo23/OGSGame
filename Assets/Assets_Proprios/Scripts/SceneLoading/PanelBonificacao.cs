using Classes;
using Controller;
using Managers;
using SceneLoading;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SceneLoading
{
    class PanelBonificacao : MonoBehaviour
    {
        [SerializeField]
        private GameObject content;
        [SerializeField]
        private Button botaoVoltar;
        [SerializeField]
        private GameObject bonificacaoPanel;
        [SerializeField]
        private Button botaoBonificacao;
        [SerializeField]
        private Sprite spriteMoedas, spriteSabedoria, spriteXP;

        private void Start()
        {
            botaoVoltar.onClick.AddListener(delegate {
                AudioManager.instance.PlayButtonClick();
                Voltar();
            });
        }

        public void CarregarBonificacoes(List<Bonificacao> bonificacoes)
        {
            LimparDesafios();
            foreach (var bonificacao in bonificacoes)
            {
                var novaBonificacao = Instantiate(bonificacaoPanel, content.transform);
                var panelBonificacoes = novaBonificacao.transform.GetChild(1);
                Text[] textos = novaBonificacao.GetComponentsInChildren<Text>();
                Button btnResposta = novaBonificacao.GetComponentInChildren<Button>();
                btnResposta.onClick.AddListener(delegate {
                    AudioManager.instance.PlayConstrucaoUP();
                    ResponderDesafio(bonificacao);
                });
                textos[0].text = bonificacao.descricao ;

                var btnMoedas = Instantiate(botaoBonificacao, panelBonificacoes.transform);
                btnMoedas.image.sprite = spriteMoedas;
                var Text = btnMoedas.GetComponentInChildren<Text>();
                Text.text = "+" + bonificacao.moedas;

                var btnSabedoria = Instantiate(botaoBonificacao, panelBonificacoes.transform);
                btnSabedoria.image.sprite = spriteSabedoria;
                Text = btnSabedoria.GetComponentInChildren<Text>();
                Text.text = "+" + bonificacao.sabedoria;

                var btnXP = Instantiate(botaoBonificacao, panelBonificacoes.transform);
                btnXP.image.sprite = spriteXP;
                Text = btnXP.GetComponentInChildren<Text>();
                Text.text = "+" + bonificacao.xp;

            }
        }

        void ResponderDesafio(Bonificacao bonus)
        {
            try
            {
                var bonificacoes = BonificacaoController.Receber(bonus.id_bonificacao, bonus.id_tribo);
                ScoreManager.instance.RecarregarTribo();
                CarregarBonificacoes(bonificacoes);
            }
            catch (Exception e)
            {
                ScoreManager.instance.ExibirPanelErro(null, e.Message);
            }

        }

        void Voltar()
        {
            gameObject.SetActive(false);
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
