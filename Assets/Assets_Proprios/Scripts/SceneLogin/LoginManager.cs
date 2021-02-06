﻿using Classes;
using Controller;
using SceneLoading;
using System;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

namespace SceneLogin
{
    public class LoginManager : MonoBehaviour
    {
        [SerializeField]
        private InputField usuario;
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
            try
            {
                var versao = VersaoApkController.ConsultarVersaoAtiva();
                if (!Application.version.Equals(versao.numero))
                {
                    ScoreManager.instance.ExibirPanelErro(GameManager.instance.Logoff, "Existe uma nova atualização do jogo. Baixe a nova versão e instale para continuar jogando");

                }
                else
                {
                    APIRequest.Autenticar(usuario.text, senha.text);
                    ScoreManager.instance.BuscarTribo();
                    if (PlayerPrefs.HasKey("usuario"))
                    {
                        AnalyticsSessionInfo.customUserId = PlayerPrefs.GetString("usuario");
                        GameManager.instance.AdicionarEventoAnalytics("Login", "Usuario", PlayerPrefs.GetString("usuario"));
                    }
                    GameManager.instance.LoadTribo();
                }
                
            }
            catch (WebException webExcp)
            {
                
                erro.text = "Erro ao conectar ao servidor";
                if (webExcp.Status == WebExceptionStatus.ProtocolError)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)webExcp.Response;
                    StreamReader reader = new StreamReader(httpResponse.GetResponseStream());
                    var str = reader.ReadToEnd();
                    Debug.Log(str);
                    if (!str.Equals(String.Empty))
                    {
                        erro.text = JsonUtility.FromJson<ResponseAPI>(str).message;
                    }
                }
                loadingPanel.SetActive(false);
                AudioManager.instance.PlayErro();
                erro.enabled = true;

            }
            catch (Exception e)
            {
                loadingPanel.SetActive(false);
                AudioManager.instance.PlayErro();
                erro.text = "Erro ao conectar ao servidor";
                erro.enabled = true;
            }
            yield return null;
        }


    }
}