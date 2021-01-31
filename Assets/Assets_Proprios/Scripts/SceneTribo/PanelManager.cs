using SceneLoading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Managers.UI
{
    class PanelManager : MonoBehaviour
    {
        [SerializeField] private Button btnFechar;
        [SerializeField] private Text titulo;

        // Use this for initialization
        void Start()
        {
            btnFechar.onClick.AddListener(delegate
            {
                FecharPanel();
                AudioManager.instance.PlayButtonClick();
            });
            Camera.main.GetComponentInParent<CameraManager>().estaAtivaMovimentacao = false;
        }

        private void FixedUpdate()
        {
            Camera.main.GetComponentInParent<CameraManager>().estaAtivaMovimentacao = !gameObject.active;
        }

        private void SetTitulo(string titulo)
        {
            this.titulo.text = titulo;
        }
            
        void FecharPanel()
        {
            Camera.main.GetComponentInParent<CameraManager>().estaAtivaMovimentacao = true;
            gameObject.SetActive(false);
        }
    }
}
