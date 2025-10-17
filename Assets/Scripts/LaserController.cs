using System;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;

public class LaserController : MonoBehaviour
{

    public float speed = 5f;
    public float time = 3f;
    public Rigidbody2D rb;
    public bool isPlayerLaser = true;

    public AudioSource audioSource;
    public AudioClip laser;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource.PlayOneShot(laser);
        rb.linearVelocity = Vector2.up * speed;

        Destroy(gameObject, time);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && isPlayerLaser)
        {
           // Debug.Log("collided with enemy");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameController.gcInstance.AddScore();
        }
        if (collision.CompareTag("Player") && !isPlayerLaser)
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.DamageTaken();
        }
    }


}
