using System;
using UnityEditor.Build.Content;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    public float speed = 5f;
    public float time = 3f;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * speed;

        Destroy(gameObject, time);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
           // Debug.Log("collided with enemy");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameController.gcInstance.AddScore();
        }
        if (collision.CompareTag("Player"))
        {
            
        }
    }


}
