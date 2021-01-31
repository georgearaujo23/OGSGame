using SceneLoading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EstacaoInformacao : MonoBehaviour
{
    [SerializeField] private Text valorProducao;
    [SerializeField] private Text valorConsumo;
    // Start is called before the first frame update
    public void GetValores(int id_estacao_tipo)
    {
        switch (id_estacao_tipo) {
            case 1:
                
                valorProducao.text = ScoreManager.instance.ProducaoAgua.ToString();
                valorConsumo.text = ScoreManager.instance.ConsumoAgua.ToString();
                break;
            case 2:
                
                valorProducao.text = ScoreManager.instance.ProducaoComida.ToString();
                valorConsumo.text = ScoreManager.instance.ConsumoComida.ToString();
                break;
            case 3:
                valorProducao.text = ScoreManager.instance.ProducaoAgua.ToString();
                valorConsumo.text = ScoreManager.instance.ConsumoAgua.ToString();
                break;
            case 4:
                valorProducao.text = ScoreManager.instance.ProducaoEnergia.ToString();
                valorConsumo.text = ScoreManager.instance.ConsumoEnergia.ToString();
                break;
        }
        
    }
}
