using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Managers.UI;

namespace Managers.UI
{

    public class UIEstacaoManager : MonoBehaviour
    {
        [SerializeField] private Button btnEstacao, btnDetalhes, btnMelhoria;
        [SerializeField] private int estacao;
        [SerializeField] private GameObject panelInfo, panelUp;

        // Use this for initialization
        void Start()
        {
            btnEstacao.onClick.AddListener(ExibirPanel);
            btnDetalhes.onClick.AddListener(DetalhesEstacao);
            btnMelhoria.onClick.AddListener(MelhoriaEstacao);
        }

        void ExibirPanel()
        {
            gameObject.GetComponent<Animator>().Play("ESTACAO_EXIBIR");
        }

        void DetalhesEstacao()
        {
            panelInfo.GetComponent<PanelEstacao>().Abrir(estacao);
        }

        void MelhoriaEstacao()
        {
            panelUp.GetComponent<PanelEstacao>().Abrir(estacao);
        }
    }
}