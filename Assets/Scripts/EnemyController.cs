using Unity.Mathematics;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public PolygonCollider2D polyCollider;
    public float speed;
    public Rigidbody2D rb;
    public int health;

    //0 = straight, 1 = sine wave
    public int movementType;
    public float amplitude;
    public float frequency;
    public float sineCenterX;
    public float xSpeed;
    public float leftBound;
    public float rightBound;
    public float offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sineCenterX = transform.position.x;
        rb.linearVelocity = Vector2.down * speed;
        //offset = Random.Range(0f, Mathf.PI * 2f);
        if(movementType == 0)
        {
            float randX = UnityEngine.Random.Range(leftBound, rightBound);
            rb.MovePosition(new Vector2(randX, rb.position.y));
        }
    }

    void FixedUpdate()
    {
        if (movementType == 0) //Straight
        {
            //Debug.Log("move = straight");
        }
        else if(movementType == 1) // Sine Wave
        {
            //Debug.Log("move = sine");

            Vector2 pos = transform.position;
            float sine = Mathf.Sin(pos.y * frequency) * amplitude;
            pos.x = sine;
            transform.position = pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.DamageTaken();
        }
    }

    public void SetType(int type)
    {
        movementType = type;
    }

    public void SetSpeed(float spd)
    {
        speed = spd;
    }

    public void SetHealth(int h)
    {
        health = h;
    }
    
    public void SetAmpFrq(float amp, float frq)
    {
        amplitude = amp;
        frequency = frq;
    }

}
