using Controller;
using SceneLoading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.UI
{
    class PanelOpcaoPesquisa : MonoBehaviour
    {
        [SerializeField] private GameObject scrollBotoes, panelDetalhesUP;
        [SerializeField] private Button pfBtnOpcao;
        [SerializeField]  private List<Button> botoes;
        public void PreencherMelhorias(int idEstacaoTipo, UIEstacaoManager uIEstacaoManager)
        {
            panelDetalhesUP.GetComponent<PanelDetalhesUP>().LimparValores(); ;
            foreach (Transform child in scrollBotoes.transform)
            {
                Destroy(child.gameObject);
            }

            botoes = new List<Button>();
            var estacao = ScoreManager.instance.GetEstacaoPorTipo(idEstacaoTipo);
            var esMelhorias = EstacaoMelhoriaController.Consultar(idEstacaoTipo, ScoreManager.instance.Nivel_sabedoria);
            foreach (var item in esMelhorias)
            {
                Button btn = Instantiate(pfBtnOpcao, scrollBotoes.transform);
                btn.GetComponentInChildren<Text>().text = item.nome;
                btn.image.sprite = btn.spriteState.disabledSprite;
                botoes.Add(btn);
                var index = botoes.Count - 1;
                btn.onClick.AddListener(delegate {
                    panelDetalhesUP.GetComponent<PanelDetalhesUP>().SetValores(item, uIEstacaoManager);
                    AlterarSpriteBotoes(index);
                    AudioManager.instance.PlayButtonClick();
                });
            }

            if(botoes.Count > 0)
                botoes[0].onClick.Invoke();

        }

        void AlterarSpriteBotoes(int indexBotao)
        {
            foreach(var btn in botoes)
            {
                btn.image.sprite = btn.spriteState.disabledSprite;
            }
            botoes[indexBotao].image.sprite = botoes[indexBotao].spriteState.selectedSprite;

        }

    }
}
