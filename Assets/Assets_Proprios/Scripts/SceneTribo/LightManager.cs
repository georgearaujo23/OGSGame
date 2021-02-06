using UnityEngine;
using System.Collections;
using System;

public class LightManager : MonoBehaviour
{
    [SerializeField] private Light sol;
    [SerializeField] private Light[] luzesArtificiais;
    enum HoraDoDia { Amanhacer, Manha, MeioDia, Tarde, Anoitecer, Noite };
    public int testeluz = 0;
    private int horaAtual = -1;
    // Use this for initialization
    void Start()
    {
        InvokeRepeating( "PosicionarSol", 0, 3600);
    }

    void PosicionarSol()
    {
        int hora = System.DateTime.Now.Hour;
        if ((hora >= 18 || hora < 5) && horaAtual != (int)HoraDoDia.Noite )
        {
            sol.transform.localRotation = Quaternion.Euler( 0.0f , 0.0f, 0.0f);
            horaAtual = (int)HoraDoDia.Noite;
            GerenciarLuzes(true);
        }
        else if (hora >= 5 && hora < 7 && horaAtual != (int)HoraDoDia.Amanhacer)
        {
            sol.transform.localRotation = Quaternion.Euler( 15.0f , 0.0f, 0.0f);
            horaAtual = (int)HoraDoDia.Amanhacer;
            GerenciarLuzes(false);
        }
        else if (hora >= 7 && hora < 11 && horaAtual != (int)HoraDoDia.Manha)
        {
            sol.transform.localRotation = Quaternion.Euler(30.0f, 0.0f, 0.0f);
            horaAtual = (int)HoraDoDia.Manha;
        }
        else if (hora >= 11 && hora < 14 && horaAtual != (int)HoraDoDia.MeioDia)
        {
            sol.transform.localRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            horaAtual = (int)HoraDoDia.MeioDia;
        }
        else if (hora >= 14 && hora < 17 && horaAtual != (int)HoraDoDia.Tarde)
        {
            sol.transform.localRotation = Quaternion.Euler(150.0f, 0.0f, 0.0f);
            horaAtual = (int)HoraDoDia.Tarde;
        }
        else if (hora >= 17 && hora < 18 && horaAtual != (int)HoraDoDia.Anoitecer)
        {
            sol.transform.localRotation = Quaternion.Euler(170.0f , 0.0f, 0.0f);
            horaAtual = (int)HoraDoDia.Anoitecer;
        }
    }

    void GerenciarLuzes(bool comando)
    {
        foreach(Light l in luzesArtificiais )
        {
            l.enabled = comando;
        }
    }

}
