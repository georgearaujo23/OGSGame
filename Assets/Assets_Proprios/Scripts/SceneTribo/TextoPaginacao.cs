using SceneLoading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.UI
{
    class TextoPaginacao : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI txtTexto;
        [SerializeField] protected Button btnAvancar;
        [SerializeField] protected Button btnVoltar;
        [SerializeField] protected Text txtPaginacao;

        void Start()
        {
            btnAvancar.onClick.AddListener(delegate {
                AvancarPagina();
                AudioManager.instance.PlayButtonClick();
            });
            btnVoltar.onClick.AddListener(delegate {
                VoltarPagina();
                AudioManager.instance.PlayButtonClick();
            });
        }

        protected void VoltarPagina()
        {
            if (txtTexto.pageToDisplay > 1)
            {
                txtTexto.pageToDisplay -= 1;
            }
            txtPaginacao.text = txtTexto.pageToDisplay.ToString() + "/" + txtTexto.textInfo.pageCount;

        }

        protected void AvancarPagina()
        {
            if (txtTexto.pageToDisplay < txtTexto.textInfo.pageCount)
            {
                txtTexto.pageToDisplay += 1;
            }
            txtPaginacao.text = txtTexto.pageToDisplay.ToString() + "/" + txtTexto.textInfo.pageCount;

        }
    }
}
