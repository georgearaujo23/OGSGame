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
using UnityEngine.UI;

namespace Managers.UI
{
    class PanelOpcaoPesquisa : MonoBehaviour
    {
        [SerializeField] private GameObject scrollBotoes, panelDetalhesUP;
        [SerializeField] private Button pfBtnOpcao;
        [SerializeField]  private List<Button> botoes;
        public void PreencherMelhorias(int id_estacao_tipo)
        {
            panelDetalhesUP.GetComponent<PanelDetalhesUP>().LimparValores(); ;
            foreach (Transform child in scrollBotoes.transform)
            {
                Destroy(child.gameObject);
            }

            botoes = new List<Button>();
            var estacao = ScoreManager.instance.GetEstacaoPorTipo(id_estacao_tipo);
            var esMelhorias = EstacaoMelhoriaController.ConsultarEstacaoMelhoria(id_estacao_tipo, estacao.nivel);
            foreach (var item in esMelhorias)
            {
                Button btn = Instantiate(pfBtnOpcao, scrollBotoes.transform);
                btn.GetComponentInChildren<Text>().text = item.nome;
                btn.image.sprite = btn.spriteState.disabledSprite;
                botoes.Add(btn);
                var index = botoes.Count - 1;
                btn.onClick.AddListener(delegate {
                    panelDetalhesUP.GetComponent<PanelDetalhesUP>().SetValores(item);
                    AlterarSpriteBotoes(index);
                    Camera.main.GetComponents<AudioSource>()[2].Play();
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
