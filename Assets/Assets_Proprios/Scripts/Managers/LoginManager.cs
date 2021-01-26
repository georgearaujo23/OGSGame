using Classes;
using Controller;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
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
    [SerializeField]
    private Image loadingImage;
    [SerializeField]
    private GameObject loadingPanel;

    private void FixedUpdate()
    {
        if (loadingImage.fillAmount > 0)
        {
            loadingImage.fillAmount -= 1f / 60f;
        }
        else
        {
            loadingImage.fillAmount = 1f;
        }
    }

    public void Login()
    {
        loadingPanel.SetActive(true);
        loadingImage.fillAmount = 1f;
        StartCoroutine(Loading());
        
    }

    private IEnumerator Loading()
    {
        
        var audios = Camera.main.GetComponentsInChildren<AudioSource>();
        try
        {
            APIRequest.Autenticar(email.text, senha.text);
            ScoreManager.instance.BuscarTribo();
            GameManager.instance.LoadTribo();
        }
        catch (WebException webExcp)
        {
            erro.text = "Erro ao conectar ao servidor";
            if (webExcp.Status == WebExceptionStatus.ProtocolError)
            {
                HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                StreamReader reader = new StreamReader(httpResponse.GetResponseStream());
                erro.text = JsonUtility.FromJson<ResponseAPI>(reader.ReadToEnd()).message;
            }
            loadingPanel.SetActive(false);
            audios[1].Play();
            erro.enabled = true;

        }
        catch (Exception e)
        {
            loadingPanel.SetActive(false);
            audios[1].Play();
            erro.text = "Erro ao conectar ao servidor";
            erro.enabled = true;
        }
        yield return null;
    }


}
