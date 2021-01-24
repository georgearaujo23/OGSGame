using Controller;
using Classes;
using UnityEngine;
using System;
using Managers.UI;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour {
    
    public static ScoreManager instance;
    private  Tribo tribo;
    private string nivelScore;
    private int scoreAtual =1, scoreNextLevel = 2;

    public Tribo Tribo
    {
        set { tribo = value; }
    }
    public int Id_tribo
    {
        get { return tribo.id_tribo; }
    }
    public string Nivel
    {
        get {
            return tribo.nivel.ToString();
        }
    }

    public string NivelSustentabilidade
    {
        get { return tribo.nivel_sustentavel.ToString(); }
    }

    public string NivelContador
    {
        get { return tribo.experiencia.ToString() + "/" + tribo.experiencia_prox.ToString(); }
    }

    public int Experiencia
    {
        get { return tribo.experiencia; }
    }

    public int Experiencia_Prox
    {
        get { return tribo.experiencia_prox; }
    }

    public string SkillPopulacao
    {
        get { return tribo.reputacao.ToString() + "%"; }
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
        get { return tribo.estacoes[0].consumo; }
    }

    public int ConsumoEnergia
    {
        get { return tribo.estacoes[3].consumo; }
    }

    public int ConsumoPesquisa
    {
        get { return tribo.estacoes[2].consumo; }
    }

    public int ConsumoComida
    {
        get { return tribo.estacoes[1].consumo; }
    }

    public int ProducaoAgua
    {
        get { return tribo.estacoes[0].producao; }
    }

    public int ProducaoEnergia
    {
        get { return tribo.estacoes[3].producao; }
    }

    public int ProducaoComida
    {
        get { return tribo.estacoes[1].producao; }
    }

    public int ProducaoPesquisa
    {
        get { return tribo.estacoes[2].producao; }
    }


    public int Moedas 
    {
        get { return tribo.moedas; }
    }

    public bool SaldoAguaPositivo
    {
        get { return tribo.estacoes[0].producao > tribo.estacoes[0].consumo; }
    }

    public bool SaldoPesquisaPositivo
    {
        get { return tribo.estacoes[4].producao > tribo.estacoes[4].consumo; }
    }

    public bool SaldoEnergiaPositivo
    {
        get { return tribo.estacoes[3].producao > tribo.estacoes[3].consumo; }
    }

    public bool SaldoComidaPositivo
    {
        get { return tribo.estacoes[1].producao > tribo.estacoes[1].consumo; }
    }

    public int Nivel_sabedoria {
        get { return tribo.nivel_sabedoria; }
    }

    public Estacao GetEstacaoPorTipo(int id_estacao_tipo)
    {
        switch (id_estacao_tipo)
        {
            case 1: return tribo.estacoes[0];
            case 2: return tribo.estacoes[1];
            case 3: return tribo.estacoes[2];
            case 4: return tribo.estacoes[3];
            default: return tribo.estacoes[0];
        }
    }

    public int GetIdEstacao(int id_estacao_tipo)
    {
        switch (id_estacao_tipo)
        {
            case 1: return tribo.estacoes[0].id_estacao;
            case 2: return tribo.estacoes[1].id_estacao;
            case 3: return tribo.estacoes[2].id_estacao;
            case 4: return tribo.estacoes[3].id_estacao;
            default: return 0;
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
    
    public void BuscarTribo()
    {
        try
        {
            tribo = TriboController.TriboPorEmail("george");
            UIManager.atualizarUI = true;
        }
        catch (Exception e)
        {
            tribo = new Tribo();
            UIManager.atualizarUI = false;
            throw e;
        }
    }

    public void RecarregarTribo()
    {
        try
        {
            UIManager.erro.SetActive(false);
            BuscarTribo();
        }
        catch (Exception e)
        {
            UIManager.Erro(ScoreManager.instance.BuscarTribo);
        }
    }

}
