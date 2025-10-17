using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController gcInstance;
    public int score;
    public int level;

    public AudioSource audioSource;
  

    void Awake()
    {
        if (gcInstance == null)
        {
            gcInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        level = 1;
        audioSource.Play();
        SceneManager.LoadScene("MainMenu");

    }

    void Update()
    {

    }

    public void AddScore()
    {
        score = score + 1000;
        //Debug.Log("score added, current:" + score);
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void LoadScene(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void SetVolume(float v)
    {
        AudioListener.volume = v;
    }

}
