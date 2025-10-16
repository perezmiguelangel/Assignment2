using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController gcInstance;
    public int score;
    public int level;


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
        SceneManager.LoadScene("SampleScene");
    }

    void Update()
    {

    }

    public void AddScore()
    {
        score = score + 1000;
        //Debug.Log("score added, current:" + score);
    }

}
