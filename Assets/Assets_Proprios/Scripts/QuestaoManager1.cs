using Controller;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Classes;

public class QuestaoManager1 : MonoBehaviour
{
    private Questao questao;

    [SerializeField] private TextMeshProUGUI txtEnunciado;
    [SerializeField] Image imagemRelogio;
    [SerializeField] Text textoRelogio;
    [SerializeField] Button buttonSubmit;
    [SerializeField] private Transform panelAlternativas;
    [SerializeField] private GameObject prfAlternativa;


    void Start()
    {
        questao = QuestaoController.questaoPorId(1);
        txtEnunciado.text = questao.enunciado;
        FillList();
        StartCoroutine(Temporizador());
    }

    void FillList()
    {
        var grid = panelAlternativas.GetComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(grid.cellSize.x, questao.alternativas.Count >= 4 ? 30f : 55f);

        foreach (QuestaoAlternativa qa in questao.alternativas)
        {
            GameObject alternativa = Instantiate(prfAlternativa) as GameObject;
            alternativa.transform.SetParent(panelAlternativas, false);
            var txtAlternativa = alternativa.GetComponentInChildren<TextMeshProUGUI>();
            txtAlternativa.SetText(qa.texto);
            alternativa.GetComponent<Button>().onClick.AddListener(HabilitarResposta);
        }
    }

    private IEnumerator Temporizador()
    {
        while (int.Parse(textoRelogio.text) > 0)
        {
            imagemRelogio.fillAmount -= 1f / 60f;
            textoRelogio.text = (int.Parse(textoRelogio.text) - 1).ToString();
            yield return new WaitForSeconds(1);

        }
    }

    public void HabilitarResposta()
    {
        buttonSubmit.interactable = true;
        buttonSubmit.image.enabled = true;
    }


}
