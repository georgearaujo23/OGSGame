using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    class PanelLoad : MonoBehaviour
    {
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



    }
}
