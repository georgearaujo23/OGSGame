using UnityEngine;
using UnityEngine.UI;
using Classes;
using System;
using System.Collections;
using Controller;
using UnityEngine.SceneManagement;
using SceneLoading;

namespace Managers.UI
{

    public class UIEstacaoManager : MonoBehaviour
    {
        [SerializeField] private Button btnEstacao, btnDetalhes, btnMelhoria;
        [SerializeField] private int idEstacaoTipo;
        [SerializeField] private GameObject panelInfo, panelUp, timer;
        [SerializeField] private Text txtTime;
        [SerializeField] private Image imgTimeFilled;
        private bool estaConstruindo = false;
        private Estacao estacao;
        private EstacaoMelhoriaEstacao estacaoMelhoriaEstacao;

        public bool EstaConstruindo
        {
            get { return estaConstruindo; }
            set { estaConstruindo = value; }
        }

        // Use this for initialization
        void Start()
        {
            StopCoroutine(ITimer());
            btnEstacao.onClick.AddListener(ExibirPanel);

            btnDetalhes.onClick.AddListener(delegate {
                DetalhesEstacao();
                AudioManager.instance.PlayButtonClick();
            });
            btnMelhoria.onClick.AddListener(delegate {
                MelhoriaEstacao();
                AudioManager.instance.PlayButtonClick();
            });
            estacao = ScoreManager.instance.GetEstacaoPorTipo(idEstacaoTipo);
            VerificarMelhoria();
        }

        public void VerificarMelhoria()
        {
            try
            {
                estacaoMelhoriaEstacao = EstacaoMelhoriaEstacaoController.ConsultarEstacaoEmConstrucao(estacao.id_estacao);
                if (!(estacaoMelhoriaEstacao is null))
                {
                    if (!estaConstruindo && estacaoMelhoriaEstacao.esta_construindo)
                    {
                        estaConstruindo = true;
                        StartCoroutine(ITimer());
                    }
                }
            }
            catch (Exception e)
            {
                ScoreManager.instance.ExibirPanelErro(VerificarMelhoria, e.Message);
            }
        }

        void ExibirPanel()
        {
            gameObject.GetComponent<Animator>().Play("ESTACAO_EXIBIR");
        }

        void DetalhesEstacao()
        {
            try
            {
                panelInfo.GetComponent<PanelEstacao>().Abrir(idEstacaoTipo, this);
            }
            catch (Exception e)
            {
                ScoreManager.instance.ExibirPanelErro(DetalhesEstacao, e.Message);
            }
        }

        void MelhoriaEstacao()
        {
            try
            {
                panelUp.GetComponent<PanelEstacao>().Abrir(idEstacaoTipo, this);
            }
            catch (Exception e)
            {
                ScoreManager.instance.ExibirPanelErro(MelhoriaEstacao, e.Message);
            }
        }

        private IEnumerator ITimer()
        {
            timer.SetActive(true);
            var tempo = DateTime.Parse(estacaoMelhoriaEstacao.fim_construcao).Subtract(DateTime.UtcNow);
            var tempoInicial = float.Parse(DateTime.Parse(estacaoMelhoriaEstacao.fim_construcao).Subtract(DateTime.Parse(estacaoMelhoriaEstacao.inicio_construcao)).TotalSeconds.ToString());

            while (tempo.TotalSeconds > 0)
            {
                txtTime.text = tempo.ToString(@"hh\:mm\:ss");
                imgTimeFilled.fillAmount = float.Parse(tempo.TotalSeconds.ToString()) / tempoInicial;
                yield return new WaitForSeconds(1);
                tempo = DateTime.Parse(estacaoMelhoriaEstacao.fim_construcao).Subtract(DateTime.UtcNow);
            }
            try
            {
                timer.SetActive(false);
                ScoreManager.instance.Tribo =
                    EstacaoMelhoriaEstacaoController.AtualizarConstrucao(
                        estacaoMelhoriaEstacao.id_estacao_melhoria_estacao);
                AudioManager.instance.PlayConstrucaoUP();
                estacaoMelhoriaEstacao.esta_construindo = false;
                estaConstruindo = false;
            }
            catch (Exception e)
            {
                estaConstruindo = false;
                ScoreManager.instance.ExibirPanelErro(VerificarMelhoria, e.Message);
                yield break;
            }
            yield return null;
        }

        }
}