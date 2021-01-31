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
        [SerializeField] private Text txtTime, txtNivel;
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
            txtNivel.text = estacao.nivel.ToString();
            VerificarMelhoria();
        }

        public void VerificarMelhoria()
        {
            estacaoMelhoriaEstacao = EstacaoMelhoriaEstacaoController.ConsultarEstacaoEmConstrucao(estacao.id_estacao);
            if (!(estacaoMelhoriaEstacao is null)) {
                if (!estaConstruindo && estacaoMelhoriaEstacao.estaConstruindo)
                {
                    estaConstruindo = true;
                    StartCoroutine(ITimer());
                }
            }
        }

        void ExibirPanel()
        {
            gameObject.GetComponent<Animator>().Play("ESTACAO_EXIBIR");
        }

        void DetalhesEstacao()
        {
            panelInfo.GetComponent<PanelEstacao>().Abrir(idEstacaoTipo, this);
        }

        void MelhoriaEstacao()
        {
            panelUp.GetComponent<PanelEstacao>().Abrir(idEstacaoTipo, this);
        }

        private IEnumerator ITimer()
        {
            timer.SetActive(true);
            var tempo = DateTime.Parse(estacaoMelhoriaEstacao.fimConstrucao).Subtract(DateTime.UtcNow);
            var tempoInicial = float.Parse(DateTime.Parse(estacaoMelhoriaEstacao.fimConstrucao).Subtract(DateTime.Parse(estacaoMelhoriaEstacao.inicioConstrucao)).TotalSeconds.ToString());

            while (tempo.TotalSeconds > 0) {
                txtTime.text = tempo.ToString(@"hh\:mm\:ss");
                imgTimeFilled.fillAmount = float.Parse(tempo.TotalSeconds.ToString())/tempoInicial;
                yield return new WaitForSeconds(1);
                tempo = DateTime.Parse(estacaoMelhoriaEstacao.fimConstrucao).Subtract(DateTime.UtcNow);
            }
            timer.SetActive(false);
            ScoreManager.instance.Tribo =
                EstacaoMelhoriaEstacaoController.AtualizarConstrucao(
                    estacaoMelhoriaEstacao.id_estacao_melhoria_estacao);
            AudioManager.instance.PlayConstrucaoUP();
            estacaoMelhoriaEstacao.estaConstruindo = false;
            estaConstruindo = false;
            yield return null;
        }

    }
}