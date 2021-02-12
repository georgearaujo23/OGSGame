using UnityEngine;

namespace SceneLoading
{
    class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;
        private bool ativo;

        public bool Ativo { get => ativo; private set => ativo = value; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance.gameObject);
                Ativo = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SetAtivo(bool value)
        {
            Ativo = value;
            if (value)
            {
                PlayMusic();
            }
            else
            {
                GetComponents<AudioSource>()[0].Stop();
                GetComponents<AudioSource>()[1].Stop();
                GetComponents<AudioSource>()[2].Stop();
                GetComponents<AudioSource>()[3].Stop();
                GetComponents<AudioSource>()[4].Stop();
                GetComponents<AudioSource>()[5].Stop();
                GetComponents<AudioSource>()[6].Stop();
                GetComponents<AudioSource>()[7].Stop();
            }
        }

        public void PlayBonus()
        {
            GetComponents<AudioSource>()[7].Play();
        }

        public void PlayLoser()
        {
            GetComponents<AudioSource>()[6].Play();
        }

        public void PlaySucesso()
        {
            if (ativo)
                GetComponents<AudioSource>()[5].Play();
        }

        public void PlayErro()
        {
            if(ativo)
                GetComponents<AudioSource>()[1].Play();
        }

        public void PlayButtonClick()
        {
            if (ativo)
                GetComponents<AudioSource>()[2].Play();
        }

        public void PlayMusic()
        {
            if (ativo)
                GetComponents<AudioSource>()[0].Play();
        }

        public void PlayConstrucaoUP()
        {
            if (ativo)
                GetComponents<AudioSource>()[3].Play();
        }

        public void PlayConstrucao()
        {
            if (ativo)
                GetComponents<AudioSource>()[4].Play();
        }

    }
}
