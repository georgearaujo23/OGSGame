using Controller;
using Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    Tribo tribo;
    private string nivelScore;
    private int scoreAtual =1, scoreNextLevel = 2;


    public string Nivel
    {
        get {
            return tribo.nivel.ToString();
        }
    }

    public string NivelSustentabilidade
    {
        get
        {
            return tribo.nivel_sustentavel.ToString();
        }
    }

    public string NivelScore
    {
        get {
            return scoreAtual.ToString() + "/" + scoreNextLevel.ToString();
        }
    }

    public int ScoreAtual
    {
        get { return scoreAtual; }
    }

    public int ScoreNextLevel
    {
        get { return scoreNextLevel; }
    }

    public string SkillPopulacao
    {
        get {
            return tribo.reputacao.ToString() + "%";
        }
    }

    public string SkillAgua
    {
        get {
            return tribo.consumo_agua.ToString() + "/" + tribo.producao_agua.ToString();
        }
    }

    public string SkillEnergia
    {
        get {
            return tribo.consumo_energia.ToString() + "/" + tribo.producao_energia.ToString();
        }
    }

    public string SkillComida
    {
        get {
            return tribo.consumo_comida.ToString() + "/" + tribo.producao_comida.ToString();
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        tribo = TriboController.TriboPorId(1);

    }
    
}
