using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    public void Logoff()
    {
        Debug.Log("GameManager.Logoff");
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Debug.Log("GameManager.Logoff");
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadTribo()
    {
        SceneManager.LoadSceneAsync(2);
    }

}
