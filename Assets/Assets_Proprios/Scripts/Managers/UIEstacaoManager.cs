using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIEstacaoManager : MonoBehaviour
{
    [SerializeField] private Button btnEstacao, btnEntrar;
    [SerializeField] private Text informacoes;
    [SerializeField] private GameObject controllerAnimator;
    [SerializeField] private int estacao;
    // Use this for initialization
    void Start()
    {
        btnEstacao.onClick.AddListener(ExibirPanel);
        btnEntrar.onClick.AddListener(EntrarEstacao);
    }

    void ExibirPanel()
    {
        controllerAnimator.GetComponent<Animator>().Play("ESTACAO_EXIBIR");
    }

    void EntrarEstacao()
    {
        SceneManager.LoadScene("Estacao" + estacao);
    }

}
