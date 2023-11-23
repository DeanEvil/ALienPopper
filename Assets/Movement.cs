using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject pinPrefab;
    public float jumpForce = 10f; // Adjust this value to control jump height
    public Transform pinSpawnPoint;
    public float pinForce = 10f;

    private Animator animator;
    private bool isGrounded; // Check if the player is on the ground

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovementInput();
        HandleShootingInput();

        // Check for jump input
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Set the horizontal input value to control the walking animation
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Move the player left or right
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Flip the player sprite when moving left
        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-8.005514f, 13.65625f, 3);
        }
        // Flip the player sprite when moving right
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(8.005514f, 13.65625f, 3);
        }
    }

    void HandleShootingInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Check if the player is grounded
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGrounded = false;
        }
    }

    void Shoot()
    {
        // Trigger the shooting animation
        animator.SetTrigger("Shoot");

        // Instantiate a new pin at the pinSpawnPoint
        GameObject pin = Instantiate(pinPrefab, pinSpawnPoint.position, pinSpawnPoint.rotation);

        // Apply force to the pin in the forward direction
        Rigidbody2D pinRb = pin.GetComponent<Rigidbody2D>();
        if (pinRb != null)
        {
            pinRb.AddForce(pinSpawnPoint.right * pinForce, ForceMode2D.Impulse);
        }
    }
}
