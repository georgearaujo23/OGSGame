using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using SceneLoading;

namespace Managers.UI
{
    public class UIManager : MonoBehaviour
    {
        public static bool atualizarUI = false;
        private float orthoSize = 5;
        public float aspect = 1.66f;
        [SerializeField] private  Button mapa, closeMapa, skill, closeSkill;
        [SerializeField] private GameObject panelMapa, panelSkill;
        [SerializeField] private Text txtNivel, txtNivelContador;
        [SerializeField] private Text[] txtNivelEstacoes;
        [SerializeField] private Image imgSkillMoeda, imgSkillSabedoria, imgSkillSustentabilidade, imgSkillPopulacao, imgSkillAgua, imgSkillEnergia, imgSkillComida;
        [SerializeField] private Image barraLevel;
        [SerializeField] private Image imgComida, imgAgua, imgEnergia, imgPopulacao, imgMoedas;

        // Use this for initialization
        void Start()
        {
            //Camera.main.orthographicSize = Camera.main.orthographicSize;
            mapa.onClick.AddListener(delegate
            {
                AcessarMapa();
                AudioManager.instance.PlayButtonClick();
            });
            skill.onClick.AddListener( delegate
            {
                AcessarSkill();
                AudioManager.instance.PlayButtonClick();
            });
            closeMapa.onClick.AddListener( delegate
            {
                FecharPanelMapa();
                AudioManager.instance.PlayButtonClick();
            });
            closeSkill.onClick.AddListener( delegate
            {
                FecharPanelSkill();
                AudioManager.instance.PlayButtonClick();
            });
            
            
        }

        public void PreencherScoresUI() 
        {

            imgSkillSustentabilidade.GetComponentsInChildren<Text>()[0].text =  ScoreManager.instance.NivelSustentabilidade;
            imgSkillSabedoria.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.NivelSabedoria.ToString();
            txtNivel.text = "Tribo Nv." + ScoreManager.instance.Nivel;
            txtNivelEstacoes[0].text = ScoreManager.instance.GetEstacaoPorTipo(1).nivel.ToString();
            txtNivelEstacoes[1].text = ScoreManager.instance.GetEstacaoPorTipo(2).nivel.ToString();
            txtNivelEstacoes[2].text = ScoreManager.instance.GetEstacaoPorTipo(3).nivel.ToString();
            txtNivelEstacoes[3].text = ScoreManager.instance.GetEstacaoPorTipo(4).nivel.ToString();
            txtNivelContador.text = ScoreManager.instance.NivelContador;
            imgPopulacao.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillPopulacao;
            imgSkillPopulacao.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillPopulacao.ToString();
            imgAgua.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillAgua;
            imgSkillAgua.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillAgua.ToString();
            imgEnergia.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillEnergia;
            imgSkillEnergia.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillEnergia.ToString();
            imgComida.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillComida;
            imgSkillComida.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillComida.ToString();
            imgMoedas.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.Moedas.ToString();
            imgSkillMoeda.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.Moedas.ToString(); 
            barraLevel.fillAmount =  float.Parse(ScoreManager.instance.Experiencia.ToString()) / ScoreManager.instance.Experiencia_Prox;
        }

        void FixedUpdate()
        {
            if (UIManager.atualizarUI)
            {
                PreencherScoresUI();
            }
        }

        private void AcessarMapa()
        {
            panelMapa.GetComponent<Animator>().Play("Mapa_exibe");
        }

        private void FecharPanelMapa()
        {
            panelMapa.GetComponent<Animator>().Play("Mapa_recolhe");
        }

        private void AcessarSkill()
        {
            Camera.main.GetComponentInParent<CameraManager>().estaAtivaMovimentacao = false;
            panelSkill.GetComponent<Animator>().Play("Skill_exibe");
        }

        private void FecharPanelSkill()
        {
            Camera.main.GetComponentInParent<CameraManager>().estaAtivaMovimentacao = true;
            panelSkill.GetComponent<Animator>().Play("Skill_recolhe");
        }

    }
}