using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject pinPrefab;
    public float jumpForce = 10f;
    public Transform pinSpawnPoint;
    public float pinForce = 10f;

    private Animator animator;
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovementInput();
        HandleShootingInput();

        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-8.005514f, 13.65625f, 3);
        }
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
        animator.SetTrigger("Shoot");

        // Instantiate a new pin at the pinSpawnPoint
        GameObject pin = Instantiate(pinPrefab, pinSpawnPoint.position, pinSpawnPoint.rotation);

        // Adjust the sorting order to be in front of the player
        Renderer playerRenderer = GetComponent<Renderer>();
        Renderer pinRenderer = pin.GetComponent<Renderer>();

        //This is to ensure that the pin doesn't spawn behind the player
        if (playerRenderer.sortingOrder > pinRenderer.sortingOrder)
        {
            pinRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
        }

        Rigidbody2D pinRb = pin.GetComponent<Rigidbody2D>();
        if (pinRb != null)
        {
            // Adjust the force direction based on the player's facing direction
            float facingDirection = Mathf.Sign(transform.localScale.x);
            pinRb.AddForce(new Vector2(facingDirection, 0f) * pinForce, ForceMode2D.Impulse);
        }

        Destroy(pin, 2f);
    }

}