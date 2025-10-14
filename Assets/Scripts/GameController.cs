using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController gameController;

    void Awake()
    {
        if (gameController == null)
        {
            gameController = this;
            
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
