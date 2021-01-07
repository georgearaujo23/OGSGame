using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Managers.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;
        [SerializeField] private GameObject panelErro;
        public static GameObject erro;
        private static AudioSource[] audios;
        private static float orthoSize = 5;
        public static float aspect = 1.66f;
        [SerializeField] private Button mapa, closeMapa, skill, closeSkill;
        [SerializeField] private GameObject panelMapa, panelSkill;
        [SerializeField] private Text txtNivel, txtSustentabilidade, txtNivelScore, txtSkillPopulacao, txtSkillPopulacaoMin, txtSkillAgua, txtSkillAguaMin, txtSkillEnergia, txtSkillEnergiaMin, txtSkillComida, txtSkillComidaMin;
        [SerializeField] private Image barraLevel;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            audios = Camera.main.GetComponentsInChildren<AudioSource>();
            erro = Instantiate(panelErro, gameObject.transform);
            erro.SetActive(false);
        }

        // Use this for initialization
        void Start()
        {

            Camera.main.projectionMatrix = Matrix4x4.Ortho(orthoSize * -aspect, orthoSize * aspect, -orthoSize, orthoSize, Camera.main.nearClipPlane, Camera.main.farClipPlane);
            mapa.onClick.AddListener(AcessarMapa);
            skill.onClick.AddListener(AcessarSkill);
            closeMapa.onClick.AddListener(FecharPanelMapa);
            closeSkill.onClick.AddListener(FecharPanelSkill);

            txtNivel.text = ScoreManager.instance.Nivel;
            txtNivelScore.text = ScoreManager.instance.NivelScore;
            txtSkillPopulacao.text = ScoreManager.instance.SkillPopulacao.ToString();
            txtSkillPopulacaoMin.text = ScoreManager.instance.SkillPopulacao.ToString();
            txtSkillAgua.text = ScoreManager.instance.SkillAgua.ToString();
            txtSkillAguaMin.text = ScoreManager.instance.SkillAgua.ToString();
            txtSkillEnergia.text = ScoreManager.instance.SkillEnergia.ToString();
            txtSkillEnergiaMin.text = ScoreManager.instance.SkillEnergia.ToString();
            txtSkillComida.text = ScoreManager.instance.SkillComida.ToString();
            txtSkillComidaMin.text = ScoreManager.instance.SkillComida.ToString();
            barraLevel.fillAmount = ScoreManager.instance.ScoreAtual / ScoreManager.instance.ScoreNextLevel;
        }

        void FixedUpdate()
        {

            txtNivel.text = ScoreManager.instance.Nivel;
            txtSustentabilidade.text = ScoreManager.instance.NivelSustentabilidade;
            txtNivelScore.text = ScoreManager.instance.NivelScore;
            txtSkillPopulacao.text = ScoreManager.instance.SkillPopulacao.ToString();
            txtSkillPopulacaoMin.text = ScoreManager.instance.SkillPopulacao.ToString();
            txtSkillAgua.text = ScoreManager.instance.SkillAgua.ToString();
            txtSkillAguaMin.text = ScoreManager.instance.SkillAgua.ToString();
            txtSkillEnergia.text = ScoreManager.instance.SkillEnergia.ToString();
            txtSkillEnergiaMin.text = ScoreManager.instance.SkillEnergia.ToString();
            txtSkillComida.text = ScoreManager.instance.SkillComida.ToString();
            txtSkillComidaMin.text = ScoreManager.instance.SkillComida.ToString();
            barraLevel.fillAmount = ScoreManager.instance.ScoreAtual / ScoreManager.instance.ScoreNextLevel;

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
            panelSkill.GetComponent<Animator>().Play("Skill_exibe");
        }

        private void FecharPanelSkill()
        {
            panelSkill.GetComponent<Animator>().Play("Skill_recolhe");
        }

        public void Erro(UnityEngine.Events.UnityAction ac)
        {
            erro.SetActive(true);
            audios[1].Play();
            var btnConectar = erro.GetComponentInChildren<Button>();
            btnConectar.onClick.AddListener(ac);
        }

    }
}