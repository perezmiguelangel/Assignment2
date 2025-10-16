using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public PolygonCollider2D polyCollider;
    public float speed = 6f;
    public Rigidbody2D rb;
    public int health;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void FixedUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.DamageTaken();
        }
    }

}
