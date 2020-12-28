using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestaoManager : MonoBehaviour
{
    private Text textfield;
    private Button btnResposta;
    private bool isCorrect = false;
    private int idQuestao = 0;

    public string TextoOpcao { get => textfield.text; set => textfield.text = value; }
    public bool IsCorrect { get => isCorrect; set => isCorrect = value; }
    public int IdQuestao { get => idQuestao; set => idQuestao = value; }

    // Start is called before the first frame update
    void Awake()
    {
        textfield = gameObject.GetComponentInChildren<Text>();
        btnResposta = gameObject.GetComponent<Button>();
        btnResposta.onClick.AddListener(RespostaQuestao);
    }

    void RespostaQuestao()
    {
        UIEstacao3Manager.instance.PainelQuestaoDisabled(this);
       

    }

    public void SetColorButton(Color32 cor) {
        ColorBlock cb = btnResposta.colors;
        cb.disabledColor = cor;
        btnResposta.colors = cb;
    }

    public void SetInteractable(bool isInteractable) {
        btnResposta.interactable = isInteractable;
    }




}
