using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpSpeed = 10f;
    private Rigidbody2D playerRb;

    public Animator playerAnim;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim.Play("Idle");
        playerAnim.Play("blink");
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovements();
    }

    public void PlayerMovements()
    {
        // Horizontal movement
        float moveInput = Input.GetAxis("Horizontal");
        playerRb.linearVelocity = new Vector2(moveInput * moveSpeed, playerRb.linearVelocity.y);

       
        if (moveInput < 0)
        {
            playerAnim.Play("Run");
            transform.localScale = new Vector3(-1, 1, 1); // Flip the sprite to the left
        }
        else if (moveInput > 0)
        {
            playerAnim.Play("Run");
            transform.localScale = new Vector3(1, 1, 1); // Flip the sprite to the right
        }
        else if (isGrounded)
        {
            playerAnim.Play("Idle");
        }

       
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            playerAnim.Play("Jump");
            playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, jumpSpeed);
            isGrounded = false; // Assumimg the player is not grounded after jumping
        }
    }

    // Detect when the player lands on the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}