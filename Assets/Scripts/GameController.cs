using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController gcInstance;
    public int score;
    public int highscore;
    public int level;
    public bool paused;
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
        score += 100;
        if(score > highscore)
        {
            highscore = score;
        }
        //Debug.Log("score added, current:" + score);
    }

    public void ResetScore()
    {
        highscore = 0;
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
