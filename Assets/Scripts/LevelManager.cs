using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject enemy;
    public float speed = 5f;
   
   
   
   
   
    void Start()
    {
        Create();
    }

    void Update()
    {

    }
    
    void Create()
    {
        GameObject enemyObject = Instantiate(enemy, transform.position, transform.rotation);
        Rigidbody2D enemyRB = enemyObject.GetComponent<EnemyController>().rb;
        enemyRB.linearVelocity = Vector2.down * speed;
    }
}
