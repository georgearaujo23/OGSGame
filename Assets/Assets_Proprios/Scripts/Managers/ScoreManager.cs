using Controller;
using Classes;
using UnityEngine;
using System;
using Managers.UI;

public class ScoreManager : MonoBehaviour {
    
    public static ScoreManager instance;
    private static Tribo tribo;
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
            return tribo.estacoes[0].consumo.ToString() + "/" + tribo.estacoes[0].producao.ToString();
        }
    }

    public string SkillEnergia
    {
        get {
            return tribo.estacoes[3].consumo.ToString() + "/" + tribo.estacoes[3].producao.ToString();
        }
    }

    public string SkillComida
    {
        get {
            return tribo.estacoes[1].consumo.ToString() + "/" + tribo.estacoes[1].producao.ToString();
        }
    }

    public int ConsumoAgua {
        get {
            return tribo.estacoes[0].consumo;
        }
    }

    public int ConsumoEnergia
    {
        get
        {
            return tribo.estacoes[3].consumo;
        }
    }

    public int ConsumoComida
    {
        get
        {
            return tribo.estacoes[2].consumo;
        }
    }

    public int ProducaoAgua
    {
        get
        {
            return tribo.estacoes[0].producao;
        }
    }

    public int ProducaoEnergia
    {
        get
        {
            return tribo.estacoes[3].producao;
        }
    }

    public int ProducaoComida
    {
        get
        {
            return tribo.estacoes[2].producao;
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
        BuscarTribo();
    }
    
    public static void BuscarTribo()
    {
        try
        {
            UIManager.erro.SetActive(false);
            tribo = TriboController.TriboPorEmail("george.ifrn@gmail.com");
        }
        catch (Exception e)
        {
            tribo = new Tribo();
            UIManager.instance.Erro(ScoreManager.BuscarTribo);
        }
    }

}
