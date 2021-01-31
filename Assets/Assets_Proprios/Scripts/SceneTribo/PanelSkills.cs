using Managers;
using SceneLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class PanelSkills : MonoBehaviour
    {
        [SerializeField] private GameObject scroolMelhorias, content;
        [SerializeField] private GameObject panelTribo, panelConfiguracao;
        [SerializeField] private Button pfBtnOpcao;
        private Button btnTribo, btnConfiguracao;

        private void Start()
        {
            
            btnTribo = Instantiate(pfBtnOpcao, content.transform);
            btnTribo.GetComponentInChildren<Text>().text = "Tribo";
            btnTribo.onClick.AddListener(delegate {
                ExibirPanel(1);
                AudioManager.instance.PlayButtonClick();
            });

            btnConfiguracao = Instantiate(pfBtnOpcao, content.transform);
            btnConfiguracao.GetComponentInChildren<Text>().text = "Config.";
            btnConfiguracao.onClick.AddListener(delegate {
                ExibirPanel(2);
                AudioManager.instance.PlayButtonClick();
            });

            
            btnTribo.onClick.Invoke();
        }

        public void ExibirPanel(int idPanel)
        {
            switch (idPanel)
            {
                case 1:
                    panelTribo.SetActive(true);
                    panelConfiguracao.SetActive(false);
                    btnTribo.image.sprite = btnTribo.spriteState.selectedSprite;
                    btnConfiguracao.image.sprite = btnTribo.spriteState.disabledSprite;
                    break;
                case 2:
                    panelTribo.SetActive(false);
                    panelConfiguracao.SetActive(true);
                    btnTribo.image.sprite = btnTribo.spriteState.disabledSprite;
                    btnConfiguracao.image.sprite = btnTribo.spriteState.selectedSprite;
                    break;
                case 3:
                    panelTribo.SetActive(true);
                    break;
            }
        }

    }
}
