using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    class PanelConfiguracao : MonoBehaviour
    {
        [SerializeField] private Button btnAudio;
        [SerializeField] private Button btnSair;
        private SpriteState ssBtnAudio;
        private void Start()
        {
            ssBtnAudio = btnAudio.spriteState;
            btnAudio.onClick.AddListener(GerenteAudio);
            btnSair.onClick.AddListener(Sair);
        }

        void GerenteAudio()
        {
            if (Camera.main.GetComponent<AudioListener>().enabled)
            {
                Camera.main.GetComponent<AudioListener>().enabled = false;
                btnAudio.image.sprite = btnAudio.spriteState.disabledSprite;
            }
            else
            {
                Camera.main.GetComponent<AudioListener>().enabled = true;
                btnAudio.image.sprite = btnAudio.spriteState.highlightedSprite;
            }
            ssBtnAudio.selectedSprite = btnAudio.image.sprite;
            btnAudio.spriteState = ssBtnAudio;
        }

        void Sair()
        {
            GameManager.instance.Logoff();
        }

    }
}
