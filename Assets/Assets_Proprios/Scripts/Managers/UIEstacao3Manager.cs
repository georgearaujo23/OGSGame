using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEstacao3Manager : MonoBehaviour
{
    public static UIEstacao3Manager instance;
    [SerializeField]
    private GameObject btnOpocoes, painel;
    [SerializeField]
    private Transform baseConteudo;
    [SerializeField]
    private Text enunciado, opcao1, opcao2, opcao3, opcao4;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //var questao = new QuestaoModel();
        /*questao.ConsultarQuestao(1);
        enunciado.text = questao.Enunciado;
        criarBotao(questao.Opcao1, questao.Opcao_correta == 1, questao.Id);
        criarBotao(questao.Opcao2, questao.Opcao_correta == 2, questao.Id);
        if(questao.Id_tp_questao == 1)
        {
            criarBotao(questao.Opcao3, questao.Opcao_correta == 3, questao.Id);
            criarBotao(questao.Opcao4, questao.Opcao_correta == 4, questao.Id);
        }*/
    }

    void criarBotao(string opcaoTexto, bool isCorrect, int idQuestao)
    {
        GameObject btn = Instantiate(btnOpocoes) as GameObject;
        btn.transform.SetParent(baseConteudo, false);
        var questaoOpcao = btn.GetComponent<QuestaoManager>();
        questaoOpcao.TextoOpcao = opcaoTexto;
        questaoOpcao.IsCorrect = isCorrect;
        questaoOpcao.IdQuestao = idQuestao;
    }

    public void PainelQuestaoDisabled(QuestaoManager qmResposta)
    {
        var questaoManagers = instance.painel.GetComponentsInChildren<QuestaoManager>();
        
        foreach(var qm in questaoManagers)
        {
            
            if (qm.IsCorrect)
            {
                qm.SetColorButton(new Color32(68, 226, 27, 255));
            }
            else if (qm.Equals(qmResposta))
            {
                qm.SetColorButton(new Color32(255, 43, 10, 255));
            }
            
            qm.SetInteractable(false);

        }
    }
}
