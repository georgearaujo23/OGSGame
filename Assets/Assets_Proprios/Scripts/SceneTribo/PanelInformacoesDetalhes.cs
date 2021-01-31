using Classes;
using SceneLoading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.UI
{
    class PanelInformacoesDetalhes : TextoPaginacao
    {
        [SerializeField] private GameObject scroolMelhorias, contentMelhorias;
        [SerializeField] private GameObject panelCustos;
        [SerializeField] private GameObject panelValores;
        [SerializeField] private GameObject panelTexto;
        [SerializeField] private Image imgXpContator;
        [SerializeField] private Text txtXpContador;


        public void SetValores(List<EstacaoMelhoriaEstacao> emeS, EstacaoTipo et)
        {
            LimparValores();
            txtTexto.text = et.descricao;
            txtTexto.pageToDisplay = 1;
            var estacao = ScoreManager.instance.GetEstacaoPorTipo(et.id_estacao_tipo);
            imgXpContator.fillAmount = float.Parse(estacao.experiencia.ToString()) / estacao.experiencia_prox;
            txtXpContador.text = estacao.experiencia + "/" + estacao.experiencia_prox;

            foreach (var item in emeS)
            {
                var pc = Instantiate(panelCustos, contentMelhorias.transform);
                var texts = pc.GetComponentsInChildren<Text>();
                texts[0].text = item.estacao_melhoria.nome;
                texts[1].text = item.quantidade.ToString();
                
            }
        }

        public void LimparValores()
        {
            foreach (Transform child in contentMelhorias.transform)
            {
                Destroy(child.gameObject);
            }
            contentMelhorias.transform.DetachChildren();

            txtTexto.text = "";
            txtPaginacao.text = "";
        }
        
        public void ExibirPanel(int idPanel)
        {
            switch (idPanel)
            {
                case 1:
                    panelTexto.SetActive(true);
                    txtTexto.ForceMeshUpdate();
                    txtPaginacao.text = txtTexto.pageToDisplay.ToString() + "/" + txtTexto.textInfo.pageCount;
                    panelValores.SetActive(false);
                    contentMelhorias.SetActive(false);
                    scroolMelhorias.SetActive(false);
                    break;
                case 2:
                    panelTexto.SetActive(false);
                    panelValores.SetActive(true);
                    contentMelhorias.SetActive(false);
                    scroolMelhorias.SetActive(false);
                    break;
                case 3:
                    panelTexto.SetActive(false);
                    panelValores.SetActive(false);
                    contentMelhorias.SetActive(true);
                    scroolMelhorias.SetActive(true);
                    break;
            }
        }
    }
}
