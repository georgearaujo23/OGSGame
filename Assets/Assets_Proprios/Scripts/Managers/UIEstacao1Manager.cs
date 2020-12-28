using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIEstacao1Manager : MonoBehaviour
{
    public static UIEstacao1Manager instance;
    [SerializeField]
    private GameObject painelMelhoria, painelProducao;
    [SerializeField]
    private Button btnMelhoria, btnProducao;

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
        btnMelhoria.onClick.AddListener(ExibirPainelMelhoria);
        btnProducao.onClick.AddListener(ExibirPainelProducao);
        btnMelhoria.Select();
        painelMelhoria.active = true;
    }

    private void ExibirPainelMelhoria()
    {
        painelMelhoria.active = true;
        painelProducao.active = false;
    }

    private void ExibirPainelProducao()
    {
        painelMelhoria.active = false;
        painelProducao.active = true;
    }
}
