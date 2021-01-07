using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstacaoInformacao : MonoBehaviour
{
    [SerializeField] private Text valorProducao;
    [SerializeField] private Text valorConsumo;
    [SerializeField] private Text nomeEstacao;
    [SerializeField] private Text NivelEstacao;
    // Start is called before the first frame update
    public void GetValores(int estacao)
    {
        switch (estacao) {
            case 1:
                nomeEstacao.text = "Água Nv.";
                valorProducao.text = ScoreManager.instance.ProducaoAgua.ToString();
                valorConsumo.text = ScoreManager.instance.ConsumoAgua.ToString();
                break;
            case 2:
                nomeEstacao.text = "Fazenda Nv.";
                valorProducao.text = ScoreManager.instance.ProducaoComida.ToString();
                valorConsumo.text = ScoreManager.instance.ConsumoComida.ToString();
                break;
            case 3:
                nomeEstacao.text = "Pesquisa Nv.";
                valorProducao.text = ScoreManager.instance.ProducaoAgua.ToString();
                valorConsumo.text = ScoreManager.instance.ConsumoAgua.ToString();
                break;
            case 4:
                nomeEstacao.text = "Energia Nv.";
                valorProducao.text = ScoreManager.instance.ProducaoEnergia.ToString();
                valorConsumo.text = ScoreManager.instance.ConsumoEnergia.ToString();
                break;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
