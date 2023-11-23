using UnityEngine;

public class BalloonMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust the speed as needed
    private Vector2 currentDirection;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Set an initial random direction
        SetRandomDirection();
    }

    void Update()
    {
        // Move the balloon based on the current direction
        rb.velocity = currentDirection * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a 2D collider
        if (collision.collider.CompareTag("Obstacle"))
        {
            // Change direction when colliding with the box collider
            SetRandomDirection();
        }
    }

    void SetRandomDirection()
    {
        // Generate a random angle between 0 and 360 degrees
        float randomAngle = UnityEngine.Random.Range(0f, 360f);

        // Convert the angle to a direction vector
        currentDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        // Set the sprite's rotation based on the new direction
        float spriteRotation = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, spriteRotation);
    }
}
