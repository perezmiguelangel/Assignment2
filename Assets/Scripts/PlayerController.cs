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
    public float shotSpeed = 10f;
    public GameObject laser;
    public float time = 4f;
    Vector2 moveDir = Vector2.zero;
    public bool grounded;
    public LayerMask groundMask;

    private void OnEnable()
    {
        playerMovement.Enable();
        shoot.Enable();
    }
    private void OnDisable()
    {
        playerMovement.Disable();
        shoot.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        moveDir = playerMovement.ReadValue<Vector2>();
        if (shoot.triggered)
        {
            Shoot();
        }
        /*
        if(jump.triggered)
        {
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        if(grounded)
        {
            jumpsRemaining = 1;
        }
        */
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDir.x * speed, moveDir.y * speed);
        //CheckGround();
    }

    void Shoot()
    {
        Instantiate(laser, transform.position, transform.rotation);
    }

    public void DamageTaken()
    {
        health--;
    }


    void CheckGround()
    {
        //grounded = Physics2D.OverlapArea(groundBC.bounds.min, groundBC.bounds.max, groundMask) != null;
    }

}
