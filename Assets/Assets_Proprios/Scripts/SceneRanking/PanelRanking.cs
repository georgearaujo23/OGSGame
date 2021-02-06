using Controller;
using SceneLoading;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SceneRanking
{
    class PanelRanking : MonoBehaviour
    {
        [SerializeField]
        private GameObject panelRaking, content, contentBotoes;
        [SerializeField]
        private Button botaoVoltar;
        [SerializeField]
        private Button pfBtnOpcao;
        private Button btnRankingNivel, btnRankingSustentavel, 
            btnRankingSabedoria, btnReputacao;
        private void Start()
        {
            botaoVoltar.onClick.AddListener(Voltar);
            btnRankingNivel = Instantiate(pfBtnOpcao, contentBotoes.transform);
            btnRankingNivel.GetComponentInChildren<Text>().text = "Nível";
            btnRankingNivel.onClick.AddListener(delegate {
                AlterarSpriteBotoes(1);
                Limpar();
                AudioManager.instance.PlayButtonClick();
                CarregarRankingNivel();
            });

            btnRankingSustentavel = Instantiate(pfBtnOpcao, contentBotoes.transform);
            btnRankingSustentavel.GetComponentInChildren<Text>().text = "Sustentável";
            btnRankingSustentavel.onClick.AddListener(delegate {
                AlterarSpriteBotoes(2);
                Limpar();
                AudioManager.instance.PlayButtonClick();
                CarregarRankingSustentavel();
            });

            btnRankingSabedoria = Instantiate(pfBtnOpcao, contentBotoes.transform);
            btnRankingSabedoria.GetComponentInChildren<Text>().text = "Sabedoria";
            btnRankingSabedoria.onClick.AddListener(delegate {
                AlterarSpriteBotoes(3);
                Limpar();
                AudioManager.instance.PlayButtonClick();
                CarregarRankingSabedoria();
            });

            btnReputacao = Instantiate(pfBtnOpcao, contentBotoes.transform);
            btnReputacao.GetComponentInChildren<Text>().text = "Reputação";
            btnReputacao.onClick.AddListener(delegate {
                AlterarSpriteBotoes(4);
                Limpar();
                AudioManager.instance.PlayButtonClick();
                CarregarRankingReputacao();
            });

            btnRankingNivel.onClick.Invoke();
        }
        
        private void CarregarRankingReputacao()
        {
            var ranking = RankingController.ConsultarReputacao();
            var posicao = 0;
            var nivel_anterior = 0;
            var index = 0;
            foreach (var r in ranking)
            {
                var panel = Instantiate(panelRaking, content.transform);
                var image = panel.GetComponent<Image>();
                var color = index % 2 == 0 ? new Color32(142, 85, 85, 100) :
                    new Color32(146, 146, 146, 100);
                color = r.nick_name != PlayerPrefs.GetString("usuario") ? color :
                    new Color32(151, 169, 255, 255);
                image.color = color;
                var texts = panel.GetComponentsInChildren<Text>();
                posicao += r.nivel == nivel_anterior ? 0 : 1;
                texts[0].text = index == ranking.Count - 1 &&
                    r.nick_name == PlayerPrefs.GetString("usuario") ?
                    "" : posicao.ToString();
                texts[1].text = r.nick_name;
                texts[2].text = r.nivel.ToString();
                nivel_anterior = r.nivel;
                index++;
            }
        }

        private void CarregarRankingNivel()
        {
            var ranking = RankingController.ConsultarNivel();
            var posicao = 0;
            var nivel_anterior = 0;
            var index = 0;
            foreach (var r in ranking)
            {
                var panel = Instantiate(panelRaking, content.transform);
                var image = panel.GetComponent<Image>();
                var color = index % 2 == 0 ? new Color32(142, 85, 85, 100) :
                    new Color32(146, 146, 146, 100);
                color = r.nick_name != PlayerPrefs.GetString("usuario") ? color :
                    new Color32(151, 169, 255, 255);
                image.color = color;
                var texts = panel.GetComponentsInChildren<Text>();
                posicao += r.nivel == nivel_anterior ? 0 : 1;
                texts[0].text = index == ranking.Count -1 &&
                    r.nick_name == PlayerPrefs.GetString("usuario") ? 
                    "" : posicao.ToString();
                texts[1].text = r.nick_name;
                texts[2].text = r.nivel.ToString();
                nivel_anterior = r.nivel;
                index++;
            }
        }

        private void CarregarRankingSustentavel()
        {
            var ranking = RankingController.ConsultarSustentavel();
            var posicao = 0;
            var nivel_anterior = 0;
            var index = 0;
            foreach (var r in ranking)
            {
                var panel = Instantiate(panelRaking, content.transform);
                var image = panel.GetComponent<Image>();
                var color = index % 2 == 0 ? new Color32(142, 85, 85, 100) :
                    new Color32(146, 146, 146, 100);
                color = r.nick_name != PlayerPrefs.GetString("usuario") ? color :
                    new Color32(151, 169, 255, 255);
                image.color = color;
                var texts = panel.GetComponentsInChildren<Text>();
                posicao += r.nivel == nivel_anterior ? 0 : 1;
                texts[0].text = index == ranking.Count - 1 &&
                    r.nick_name == PlayerPrefs.GetString("usuario") ?
                    "" : posicao.ToString();
                texts[1].text = r.nick_name;
                texts[2].text = r.nivel.ToString();
                nivel_anterior = r.nivel;
                index++;
            }
        }

        private void CarregarRankingSabedoria()
        {
            var ranking = RankingController.ConsultarSabedoria();
            var posicao = 0;
            var nivel_anterior = 0;
            var index = 0;
            foreach (var r in ranking)
            {
                var panel = Instantiate(panelRaking, content.transform);
                var image = panel.GetComponent<Image>();
                var color = index % 2 == 0 ? new Color32(142, 85, 85, 100) :
                    new Color32(146, 146, 146, 100);
                color = r.nick_name != PlayerPrefs.GetString("usuario") ? color :
                    new Color32(151, 169, 255, 255);
                image.color = color;
                var texts = panel.GetComponentsInChildren<Text>();
                posicao += r.nivel == nivel_anterior ? 0 : 1;
                texts[0].text = index == ranking.Count - 1 &&
                    r.nick_name == PlayerPrefs.GetString("usuario") ?
                    "" : posicao.ToString();
                texts[1].text = r.nick_name;
                texts[2].text = r.nivel.ToString();
                nivel_anterior = r.nivel;
                index++;
            }
        }

        void Voltar()
        {
            GameManager.instance.LoadTribo();
        }

        void AlterarSpriteBotoes(int idBotao)
        {
            switch (idBotao)
            {
                case 1:
                    btnRankingNivel.image.sprite = btnRankingNivel.spriteState.selectedSprite;
                    btnRankingSustentavel.image.sprite = btnRankingSustentavel.spriteState.disabledSprite;
                    btnRankingSabedoria.image.sprite = btnRankingSabedoria.spriteState.disabledSprite;
                    break;
                case 2:
                    btnRankingNivel.image.sprite = btnRankingNivel.spriteState.disabledSprite;
                    btnRankingSustentavel.image.sprite = btnRankingSustentavel.spriteState.selectedSprite;
                    btnRankingSabedoria.image.sprite = btnRankingSabedoria.spriteState.disabledSprite;
                    break;
                case 3:
                    btnRankingNivel.image.sprite = btnRankingNivel.spriteState.disabledSprite;
                    btnRankingSustentavel.image.sprite = btnRankingSustentavel.spriteState.disabledSprite
;
                    btnRankingSabedoria.image.sprite = btnRankingSabedoria.spriteState.selectedSprite;
                    break;
            }
        }

        void Limpar()
        {
            foreach (Transform child in content.transform)
            {
                Destroy(child.gameObject);
            }
            content.transform.DetachChildren();
        }

    }
}
