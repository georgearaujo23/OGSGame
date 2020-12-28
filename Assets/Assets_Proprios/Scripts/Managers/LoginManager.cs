using Classes;
using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    [SerializeField]
    private InputField email;
    [SerializeField]
    private InputField senha;
    [SerializeField]
    private Text erro;

    private Button btnEntrar;

    private void Start()
    {
        btnEntrar = gameObject.GetComponentInChildren<Button>();
        btnEntrar.onClick.AddListener(Login);
    }

    void Login()
    {
        Autentication aut = new Autentication();
        ResponseAPI rApi = aut.Autenticar(email.text, senha.text);
        if (rApi.status)
        {
            SceneManager.LoadScene( 1);
        }
        else
        {
            var audios = Camera.main.GetComponentsInChildren<AudioSource>();
            audios[1].Play();
            erro.text = rApi.message;
            erro.enabled = true;
        }
    }
}
