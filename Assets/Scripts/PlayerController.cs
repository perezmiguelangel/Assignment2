using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //
    public int health;
    public Rigidbody2D rb;
    public PolygonCollider2D polyCollider;
    public float speed = 5f;
    public InputAction playerMovement;
    public InputAction shoot;
    public InputAction pause;
    public float shotSpeed = 10f;
    public GameObject laser;
    public float time = 4f;
    Vector2 moveDir = Vector2.zero;

    public AudioSource audioSource;
    public AudioClip explosion;

    public Animator animator;

    public GameUIController gameUIController;


    private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        playerMovement.Enable();
        shoot.Enable();
        pause.Enable();
    }
    private void OnDisable()
    {
        playerMovement.Disable();
        shoot.Disable();
        pause.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        moveDir = playerMovement.ReadValue<Vector2>();
        if (shoot.triggered)
        {
            Shoot();
        }
        if (health == 0)
        {
            //Debug.Log("DEAD");
        }
        if (pause.triggered)
        {
            gameUIController.PauseMenu();
            GameController.gcInstance.paused = true;
        }

        float xPos = moveDir.x;
        animator.SetFloat("xPos", xPos);
        
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        //CheckGround();
    }

    void Shoot()
    {
        GameObject laserObject = Instantiate(laser, transform.position, transform.rotation);
        laserObject.GetComponent<LaserController>().isPlayerLaser = true;
    }

    public void DamageTaken()
    {
        health--;
        if(health <= 0)
        {
            //dead
            StartCoroutine(PlayerDeath());

            GameController.gcInstance.LoadScene("MainMenu");
        }
        //Debug.Log("player damaged");
    }

    IEnumerator PlayerDeath()
    {
        audioSource.PlayOneShot(explosion);
        yield return new WaitForSecondsRealtime(2f);
        
    }
}
