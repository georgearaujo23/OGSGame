using Classes;
using Controller;
using SceneLoading;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SceneDesafio
{
    class PanelQuestao : MonoBehaviour
    {
        private List<Questao> questoes;
        private DesafioJogador desafioJogador;
        [SerializeField] private TextMeshProUGUI txtEnunciado;
        [SerializeField] Image imagemRelogio;
        [SerializeField] Text textoRelogio;
        [SerializeField] Button buttonSubmit;
        [SerializeField] private GameObject contentAlternativas, panelResultado;
        [SerializeField] private GameObject prfAlternativa;
        [SerializeField] private Image imgQuestoes;
        [SerializeField] private Text txtQuestoesRespondidas;
         private int indexQuestoes, qtdQuestoesDesafio, qtdAcertosNecessarios;


        public void CarregarDesafio(int idDesafio, int quantidadeQuestoes, int acertosNecessarios)
        {
            qtdQuestoesDesafio = quantidadeQuestoes;
            qtdAcertosNecessarios = acertosNecessarios;
            buttonSubmit.gameObject.SetActive(false);
            desafioJogador = DesafioJogadorController.Inserir(ScoreManager.instance.Id_jogador, idDesafio);
            questoes = QuestaoController.ConsultarQuestoesDesafio(
                quantidadeQuestoes - desafioJogador.quantidade_respondida,
                desafioJogador.id_desafio_jogador);
            indexQuestoes = -1;
            if(questoes.Count > 0)
                CarregarQuestoes();
        }

        void CarregarQuestoes()
        {
            imgQuestoes.fillAmount = float.Parse((desafioJogador.quantidade_respondida +1).ToString()) /qtdQuestoesDesafio;
            txtQuestoesRespondidas.text = (desafioJogador.quantidade_respondida + 1).ToString() + "/" + qtdQuestoesDesafio.ToString();
            indexQuestoes++;
            var questao = questoes[indexQuestoes];
            var ultimaQuestaoDesafio =
                desafioJogador.quantidade_respondida + 1 == qtdQuestoesDesafio ;
            txtEnunciado.text = questao.enunciado;
            CarregarAlternativas(questao, ultimaQuestaoDesafio);
            StartCoroutine(Temporizador());
        }

        void CarregarAlternativas(Questao questao, bool ultima)
        {
            LimparAlternativas();
            foreach (QuestaoAlternativa qa in questao.alternativas)
            {
                var alternativa = Instantiate(prfAlternativa, contentAlternativas.transform) as GameObject;
                
                var txtAlternativa = alternativa.GetComponentInChildren<TextMeshProUGUI>();
                txtAlternativa.SetText(qa.texto);
                alternativa.GetComponent<Button>().onClick.AddListener(delegate {
                    AudioManager.instance.PlayButtonClick();
                    HabilitarResposta(qa.id_questao, qa.id_questao_alternativa, qa.correta, ultima);
                });
            }
        }

        void RegistrarResposta(int idDesafioJogador, int idQuestao, int idQuestaoAlternativa, bool terminou, bool acertou)
        {
            ScoreManager.instance.Tribo =
            QuestaoDesafioJogadorController.Inserir(idDesafioJogador, idQuestao,desafioJogador.id_desafio, ScoreManager.instance.Id_tribo, idQuestaoAlternativa, terminou, acertou);
        }

        public void HabilitarResposta(int idQuestao, int idQuestaoAlternativa, bool correta, bool ultima)
        {
            buttonSubmit.onClick.RemoveAllListeners();
            buttonSubmit.gameObject.SetActive(true);
            buttonSubmit.onClick.AddListener(delegate
            {
                RegistrarResposta(
                        desafioJogador.id_desafio_jogador,
                        idQuestao,
                        idQuestaoAlternativa,
                        ultima,
                        correta);
                desafioJogador.quantidade_respondida++;
                desafioJogador.quantidade_acertos += correta ? 1 : 0;
                if (correta)
                {
                    AudioManager.instance.PlaySucesso(); 
                }
                else
                {
                    AudioManager.instance.PlayErro();
                }
                StopCoroutine(Temporizador());
                buttonSubmit.gameObject.SetActive(false);
                if (indexQuestoes + 1 < questoes.Count)
                {
                    CarregarQuestoes();
                }
                else
                {
                    ScoreManager.instance.RecarregarTribo();
                    gameObject.SetActive(false);
                    panelResultado.SetActive(true);
                    var texts = panelResultado.GetComponentsInChildren<Text>();
                    texts[1].text = qtdAcertosNecessarios.ToString();
                    texts[3].text = desafioJogador.quantidade_acertos.ToString();
                    if(qtdAcertosNecessarios <= desafioJogador.quantidade_acertos)
                    {
                        texts[4].text = @"PARABÉNS!
CONHECIMENTO É PODER";
                        AudioManager.instance.PlayConstrucaoUP();
                    }
                    else
                    {
                        texts[4].text = @"NÃO FOI DESSA VEZ!
CONTINUE NA BATALHA";
                        AudioManager.instance.PlayLoser();
                    }
                }
                    
            });
        }

        private IEnumerator Temporizador()
        {
            textoRelogio.text = "120";
            imagemRelogio.fillAmount = 1;
            while (int.Parse(textoRelogio.text) > 0)
            {
                imagemRelogio.fillAmount -= 1f / 120f;
                textoRelogio.text = (int.Parse(textoRelogio.text) - 1).ToString();
                yield return new WaitForSeconds(1);

            }
        }

        public void LimparAlternativas()
        {
            foreach (Transform child in contentAlternativas.transform)
            {
                Destroy(child.gameObject);
            }
            contentAlternativas.transform.DetachChildren();
        }

    }
}
