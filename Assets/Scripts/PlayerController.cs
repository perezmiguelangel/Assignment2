using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //
    public Rigidbody2D rb;
    public BoxCollider2D PlayerBC;
    public CapsuleCollider2D groundBC;
    public float speed = 5f;
    public int jumpsRemaining = 1;
    public float jumpForce = 2f;
    public InputAction playerMovement;
    public InputAction jump;
    Vector2 moveDir = Vector2.zero;
    public bool grounded;
    public LayerMask groundMask;

    private void OnEnable()
    {
        playerMovement.Enable();
        jump.Enable();
    }
    private void OnDisable()
    {
        playerMovement.Disable();
        jump.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        moveDir = playerMovement.ReadValue<Vector2>();
        if(jump.triggered && jumpsRemaining > 0)
        {
            --jumpsRemaining;
            rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
        }
        if(grounded)
        {
            jumpsRemaining = 1;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveDir.x * speed, rb.linearVelocityY);
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapArea(groundBC.bounds.min, groundBC.bounds.max, groundMask) != null;
    }

}
