using SceneLoading;
using UnityEngine;
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
            if (AudioManager.instance.Ativo)
            {
                btnAudio.image.sprite = btnAudio.spriteState.highlightedSprite;
            }
            else
            {
                btnAudio.image.sprite = btnAudio.spriteState.disabledSprite;
            }
        }

        void GerenteAudio()
        {
            if (AudioManager.instance.Ativo)
            {
                AudioManager.instance.SetAtivo(false);
                btnAudio.image.sprite = btnAudio.spriteState.disabledSprite;
            }
            else
            {
                AudioManager.instance.SetAtivo( true);
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
