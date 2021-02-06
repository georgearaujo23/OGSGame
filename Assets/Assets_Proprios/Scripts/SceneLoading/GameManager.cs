using Controller;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System.Collections.Generic;
using Unity.Notifications.Android;

namespace SceneLoading
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public AndroidNotificationChannel defaultChannel;
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

        private void Start()
        {
            defaultChannel = new AndroidNotificationChannel()
            {
                Id = "OGS channel",
                Name = "Guardiões do Saber Channel",
                Description = "Canal para notificações do jogo guardiões do Saber",
                Importance = Importance.Default
            };
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.RegisterNotificationChannel(defaultChannel);
            GameNotification();

            Application.logMessageReceived -= DelegateLog;
            try
            {
                var versao = VersaoApkController.ConsultarVersaoAtiva();
                if (!Application.version.Equals(versao.numero))
                {
                    ScoreManager.instance.ExibirPanelErro(Logoff, "Existe uma nova atualização do jogo. Baixe a nova versão e instale para continuar jogando");
                }
                else
                {
                    CarregamentoTribo();
                }
            }
            catch (Exception e)
            {
                Logoff();
                ScoreManager.instance.ExibirPanelErro(null, e.Message);
            }

            if (PlayerPrefs.HasKey("usuario"))
            {
                AnalyticsSessionInfo.customUserId = PlayerPrefs.GetString("usuario");
                AdicionarEventoAnalytics("Abriu_Jogo", "usuario", PlayerPrefs.GetString("usuario"));
            }
        }

        void GameNotification()
        {
            AndroidNotification notification = new AndroidNotification()
            {
                Title = "Hora de Jogar!",
                Text = "Não abandone a tribo, ela precisa de você!",
                FireTime = System.DateTime.Now.AddHours(12)
            };
            var id = AndroidNotificationCenter.SendNotification(notification, defaultChannel.Id);
        }

        private void DelegateLog(string message, string StackTraceLogType, LogType type)
        {
            if(type == LogType.Error || type == LogType.Exception)
            {
                AdicionarEventoAnalytics("game_error", "message", message);
            }
        }

        public void AdicionarEventoAnalytics(string nomeEvento, string chave, string valor)
        {
            Dictionary<string, object> extras = new Dictionary<string, object>();
            extras.Add(chave, valor);
            Analytics.CustomEvent(nomeEvento, extras);
        }

        public void CarregamentoTribo()
        {
            try
            {
                if (PlayerPrefs.HasKey("usuario"))
                {
                    ScoreManager.instance.BuscarTribo();
                    LoadTribo();
                }
                else
                {
                    Logoff();
                }
            }
            catch (Exception e)
            {
                Logoff();
                ScoreManager.instance.ExibirPanelErro(null, e.Message);
            }
        }

        public void Logoff()
        {
            if (PlayerPrefs.HasKey("usuario"))
            {
                AdicionarEventoAnalytics("Saiu_Jogo", "usuario", PlayerPrefs.GetString("usuario"));
            }
            else
            {
                AdicionarEventoAnalytics("Saiu_Jogo", "usuario", "");
            }
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            SceneManager.LoadSceneAsync(1);
        }

        public void LoadTribo()
        {
            if (PlayerPrefs.HasKey("usuario"))
            {
                AdicionarEventoAnalytics("Visualizou_Tribo", "usuario", PlayerPrefs.GetString("usuario"));
                var bonificacoes = BonificacaoController.Consultar(ScoreManager.instance.Id_tribo);
                ScoreManager.instance.panelBonificacao.SetActive(true);
                if (bonificacoes.Count > 0)
                {
                    ScoreManager.instance.panelBonificacaoDados.SetActive(true);
                    ScoreManager.instance.GetComponentInChildren<PanelBonificacao>().
                        CarregarBonificacoes(bonificacoes);
                }
                else
                {
                    ScoreManager.instance.panelBonificacao.SetActive(false);
                    ScoreManager.instance.panelBonificacaoDados.SetActive(false);
                }
            }
            else
            {
                AdicionarEventoAnalytics("Visualizou_Tribo", "usuario", "");
            }

            SceneManager.LoadSceneAsync(2);
        }

        public void LoadDesafios()
        {
            if (PlayerPrefs.HasKey("usuario"))
            {
                AdicionarEventoAnalytics("Visualizou_Desafio", "usuario", PlayerPrefs.GetString("usuario"));
            }
            else
            {
                AdicionarEventoAnalytics("Visualizou_Desafio", "usuario", "");
            }
            SceneManager.LoadSceneAsync(3);
        }

        public void LoadRanking()
        {
            if (PlayerPrefs.HasKey("usuario"))
            {
                AdicionarEventoAnalytics("Visualizou_Ranking", "usuario", PlayerPrefs.GetString("usuario"));
            }
            else
            {
                AdicionarEventoAnalytics("Visualizou_Ranking", "usuario", "");
            }
            SceneManager.LoadSceneAsync(4);
        }


    }
}
