using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Managers.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject panelErro;
        public static GameObject erro;
        public static bool atualizarUI = false;
        private float orthoSize = 5;
        public float aspect = 1.66f;
        [SerializeField] private  Button mapa, closeMapa, skill, closeSkill;
        [SerializeField] private GameObject panelMapa, panelSkill;
        [SerializeField] private Text txtNivel, txtNivelContador;
        [SerializeField] private Image imgSkillMoeda, imgSkillSabedoria, imgSkillSustentabilidade, imgSkillPopulacao, imgSkillAgua, imgSkillEnergia, imgSkillComida;
        [SerializeField] private Image barraLevel;
        [SerializeField] private Image imgComida, imgAgua, imgEnergia, imgPopulacao, imgMoedas;

        private void Awake()
        {
            erro = Instantiate(panelErro, gameObject.transform);
            erro.SetActive(false);
        }

        // Use this for initialization
        void Start()
        {

            Camera.main.projectionMatrix = Matrix4x4.Ortho(orthoSize * -aspect, orthoSize * aspect, -orthoSize, orthoSize, Camera.main.nearClipPlane, Camera.main.farClipPlane);
            mapa.onClick.AddListener(delegate
            {
                AcessarMapa();
                Camera.main.GetComponents<AudioSource>()[2].Play();
            });
            skill.onClick.AddListener( delegate
            {
                AcessarSkill();
                Camera.main.GetComponents<AudioSource>()[2].Play();
            });
            closeMapa.onClick.AddListener( delegate
            {
                FecharPanelMapa();
                Camera.main.GetComponents<AudioSource>()[2].Play();
            });
            closeSkill.onClick.AddListener( delegate
            {
                FecharPanelSkill();
                Camera.main.GetComponents<AudioSource>()[2].Play();
            });
            
            
        }

        public void PreencherScoresUI() 
        {

            imgSkillSustentabilidade.GetComponentsInChildren<Text>()[0].text =  ScoreManager.instance.NivelSustentabilidade;
            imgSkillSabedoria.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.Nivel_sabedoria.ToString();
            txtNivel.text = "Tribo Nv." + ScoreManager.instance.Nivel;
            txtNivelContador.text = ScoreManager.instance.NivelContador;
            imgPopulacao.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillPopulacao;
            imgSkillPopulacao.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillPopulacao.ToString();
            imgAgua.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillAgua;
            imgAgua.GetComponentsInChildren<Text>()[0].color = ScoreManager.instance.SaldoAguaPositivo ? Color.black : Color.red;
            imgSkillAgua.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillAgua.ToString();
            imgEnergia.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillEnergia;
            imgEnergia.GetComponentsInChildren<Text>()[0].color = ScoreManager.instance.SaldoEnergiaPositivo ? Color.black : Color.red;
            imgSkillEnergia.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillEnergia.ToString();
            imgComida.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillComida;
            imgComida.GetComponentsInChildren<Text>()[0].color = ScoreManager.instance.SaldoComidaPositivo ? Color.black : Color.red;
            imgSkillComida.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.SkillComida.ToString();
            imgMoedas.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.Moedas.ToString();
            imgMoedas.GetComponentsInChildren<Text>()[0].color = ScoreManager.instance.Moedas >= 0 ? Color.black : Color.red;
            imgSkillMoeda.GetComponentsInChildren<Text>()[0].text = ScoreManager.instance.Moedas.ToString(); 
            barraLevel.fillAmount =  float.Parse(ScoreManager.instance.Experiencia.ToString()) / ScoreManager.instance.Experiencia_Prox;
        }

        void FixedUpdate()
        {
            if (SceneManager.GetActiveScene().buildIndex == 1 && atualizarUI)
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

        public static void Erro(UnityEngine.Events.UnityAction ac)
        {
            erro.SetActive(true);
            Camera.main.GetComponents<AudioSource>()[1].Play();
            var btnConectar = erro.GetComponentInChildren<Button>();
            btnConectar.onClick.AddListener(delegate
            {
                ac();
                Camera.main.GetComponents<AudioSource>()[2].Play();
            });
        }

    }
}