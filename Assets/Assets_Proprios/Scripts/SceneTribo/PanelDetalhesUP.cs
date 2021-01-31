using Classes;
using Controller;
using SceneLoading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.UI
{
    class PanelDetalhesUP : TextoPaginacao
    {
        [SerializeField] private Button btnConfirmar;
        [SerializeField] private GameObject ContentValores ;
        [SerializeField] private GameObject panelCustos;
        [SerializeField] private UIEstacaoManager uiEstacaoManager;

        public void SetValores (EstacaoMelhoria em, UIEstacaoManager uie)
        {
            uiEstacaoManager = uie;
            LimparValores();

            if (uiEstacaoManager.EstaConstruindo)
            {
                btnConfirmar.enabled = true;
                btnConfirmar.image.sprite = btnConfirmar.spriteState.disabledSprite;
            }

            btnConfirmar.onClick.AddListener(delegate {
                Confirmar(em);
                AudioManager.instance.PlayConstrucao();
            });
            txtTexto.text = em.descricao;
            txtTexto.pageToDisplay = 1;
            txtTexto.ForceMeshUpdate();
            txtPaginacao.text = txtTexto.pageToDisplay.ToString() + "/" + txtTexto.textInfo.pageCount;



            var pc = Instantiate(panelCustos, ContentValores.transform);
            var texts = pc.GetComponentsInChildren<Text>();
            texts[0].text = "Comida";
            texts[1].text = em.comida.ToString();
            texts[1].color = em.comida > 0 ? Color.blue : Color.red;

            pc = Instantiate(panelCustos, ContentValores.transform);
            texts = pc.GetComponentsInChildren<Text>();
            texts[0].text = "Água";
            texts[1].text = em.agua.ToString();
            texts[1].color = em.agua > 0 ? Color.blue : Color.red;

            pc = Instantiate(panelCustos, ContentValores.transform);
            texts = pc.GetComponentsInChildren<Text>();
            texts[0].text = "Energia";
            texts[1].text = em.energia.ToString();
            texts[1].color = em.energia > 0 ? Color.blue : Color.red;

            pc = Instantiate(panelCustos, ContentValores.transform);
            texts = pc.GetComponentsInChildren<Text>();
            texts[0].text = "Moedas";
            texts[1].text = em.custo_moedas.ToString();
            texts[1].color = em.custo_moedas > 0 ? Color.blue : Color.red;

            pc = Instantiate(panelCustos, ContentValores.transform);
            texts = pc.GetComponentsInChildren<Text>();
            texts[0].text = "Reputação";
            texts[1].text = em.populacao.ToString();
            texts[1].color = em.populacao > 0 ? Color.blue : Color.red;

            pc = Instantiate(panelCustos, ContentValores.transform);
            texts = pc.GetComponentsInChildren<Text>();
            texts[0].text = "Sustentabilidade";
            texts[1].text = em.sustentabilidade.ToString();
            texts[1].color = em.sustentabilidade > 0 ? Color.blue : Color.red ;

        }

        public void LimparValores()
        {
            btnConfirmar.onClick.RemoveAllListeners();
            foreach (Transform child in ContentValores.transform)
            {
                Destroy(child.gameObject);
            }
            ContentValores.transform.DetachChildren();

            txtTexto.text = "";
            txtPaginacao.text = "";
        }

        void Confirmar(EstacaoMelhoria em)
        {
            if (!uiEstacaoManager.EstaConstruindo)
            {
                btnConfirmar.enabled = true;
                btnConfirmar.image.sprite = btnConfirmar.spriteState.disabledSprite;
                var id_estacao = ScoreManager.instance.GetIdEstacao(em.id_estacao_tipo);
                var tribo = EstacaoMelhoriaEstacaoController.Inserir(id_estacao, em.id_estacao_melhoria);
                ScoreManager.instance.Tribo = tribo;
                uiEstacaoManager.VerificarMelhoria();
                uiEstacaoManager.EstaConstruindo = true;
            }   
        }

    }
}
