using Classes;
using Controller;
using SceneLoading;
using System;
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
        [SerializeField]
        private Sprite imgComida, imgAgua, imgEnergia,
            imgMoeda, imgSustentavel, imgSabedoria, imgReputacao;
        private int id_estacao_tipo, id_estacao_melhoria;
        private bool temSaldoRecursos = false;

        public void SetValores (EstacaoMelhoria em, UIEstacaoManager uie)
        {
            uiEstacaoManager = uie;
            btnConfirmar.image.sprite = btnConfirmar.spriteState.highlightedSprite;
            LimparValores();

            btnConfirmar.onClick.AddListener(delegate {
                Confirmar(em);
            });
            txtTexto.text = em.descricao;
            txtTexto.pageToDisplay = 1;
            txtTexto.ForceMeshUpdate();
            txtPaginacao.text = txtTexto.pageToDisplay.ToString() + "/" + txtTexto.textInfo.pageCount;

            var visivel = Math.Abs(em.comida) < ScoreManager.instance.ConsumoComida ||
                em.comida > 0;
            temSaldoRecursos = visivel;
            CriarPanelRecurso(imgComida, em.comida.ToString(), visivel);

            visivel = Math.Abs(em.agua) < ScoreManager.instance.ConsumoAgua ||
                    em.agua > 0;
            temSaldoRecursos = temSaldoRecursos && visivel;
            CriarPanelRecurso(imgAgua, em.agua.ToString(), visivel);

            visivel = Math.Abs(em.energia) < ScoreManager.instance.ConsumoEnergia ||
                    em.energia > 0;
            temSaldoRecursos = temSaldoRecursos && visivel;
            CriarPanelRecurso(imgEnergia, em.energia.ToString(), visivel);

            visivel = Math.Abs(em.custo_moedas) < ScoreManager.instance.Moedas;
            temSaldoRecursos = temSaldoRecursos && visivel;
            CriarPanelRecurso(imgMoeda, em.custo_moedas.ToString(), visivel);

            CriarPanelRecurso(imgReputacao, em.populacao.ToString(), true);
            CriarPanelRecurso(imgSustentavel, em.sustentabilidade.ToString(), true);
            if(em.id_estacao_tipo == 3)
            {
                visivel = Math.Abs(em.sabedoria_pesquisa) < ScoreManager.instance.SabedoriaSaldo;
                temSaldoRecursos = temSaldoRecursos && visivel;
                CriarPanelRecurso(imgSabedoria, em.sabedoria_pesquisa.ToString(), visivel);
            }
            else
            {
                CriarPanelRecurso(imgSabedoria, em.sabedoria.ToString(), true);
            }

            if (uiEstacaoManager.EstaConstruindo || !temSaldoRecursos)
            {
                btnConfirmar.enabled = false;
                btnConfirmar.image.sprite = btnConfirmar.spriteState.disabledSprite;
            }
            else
            {
                btnConfirmar.enabled = true;
                btnConfirmar.image.sprite = btnConfirmar.spriteState.highlightedSprite;
            }

        }

        void CriarPanelRecurso(Sprite sprite, string valor, bool visivel)
        {
            var pc = Instantiate(panelCustos, ContentValores.transform);
            var texto = pc.GetComponentInChildren<Text>();
            var imgs = pc.GetComponentsInChildren<Image>();
            texto.text = valor;
            imgs[1].sprite = sprite;
            imgs[1].preserveAspect = true;
            texto.color = visivel ? Color.blue : Color.red;
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
            try
            { 
                if (!uiEstacaoManager.EstaConstruindo)
                {
                    id_estacao_tipo = em.id_estacao_tipo;
                    id_estacao_melhoria = em.id_estacao_melhoria;
                    RegistraMelhoria();
                }
            }
            catch (Exception e)
            {
                btnConfirmar.enabled = true;
                btnConfirmar.image.sprite = btnConfirmar.spriteState.highlightedSprite;
                ScoreManager.instance.ExibirPanelErro(RegistraMelhoria, e.Message);
            }
        }

        private void RegistraMelhoria()
        {
            btnConfirmar.enabled = false;
            btnConfirmar.image.sprite = btnConfirmar.spriteState.disabledSprite;
            var id_estacao = ScoreManager.instance.GetIdEstacao(id_estacao_tipo);
            var tribo = EstacaoMelhoriaEstacaoController.Inserir(id_estacao, id_estacao_melhoria);
            ScoreManager.instance.Tribo = tribo;
            AudioManager.instance.PlayConstrucao();
            uiEstacaoManager.VerificarMelhoria();
        }
    }
}
