using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonMovement : MonoBehaviour
{
    public float moveSpeed = 5f;      // Adjust the speed as needed
    public float collisionCooldown = 0.5f;  // Cooldown period in seconds
    public float sizeGrowthRate = 0.1f; // Rate at which the balloon grows per second
    public float maxSize = 5f; // Maximum size before the balloon disappears
    private float lastCollisionTime;
    private bool isBalloonActive = true;
    private Vector2 currentDirection;
    private Rigidbody2D rb;
    private Transform balloonVisual;
    private Transform balloonCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        balloonVisual = transform.Find("Visual"); // Assuming the visual is a child named "Visual"
        balloonCollider = transform.Find("Collider"); // Assuming the collider is a child named "Collider"
        // Set an initial random direction
        SetRandomDirection();
    }

    void FixedUpdate()
    {
        if (isBalloonActive)
        {
            // Move the balloon based on the current direction
            rb.velocity = currentDirection * moveSpeed;

            // Increase the size of the balloon over time
            IncreaseSize();

            // Check if the balloon exceeds the maximum size
            if (balloonVisual.localScale.x > maxSize)
            {
                // Balloon is too big, disappear
                isBalloonActive = false;
                // You can add any other effects or actions here

                // Restart the level (you can replace this with any action you want)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a 2D collider
        if (isBalloonActive && collision.collider.CompareTag("Obstacle") && Time.time - lastCollisionTime > collisionCooldown)
        {
            // Change direction when colliding with the box collider
            SetRandomDirection();
            lastCollisionTime = Time.time;
        }
    }

    void SetRandomDirection()
    {
        // Generate a random angle between 0 and 360 degrees using UnityEngine.Random
        float randomAngle = UnityEngine.Random.Range(0f, 360f);

        // Convert the angle to a direction vector
        currentDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad));

        // Set the sprite's rotation based on the new direction
        float spriteRotation = Mathf.Atan2(currentDirection.y, currentDirection.x) * Mathf.Rad2Deg;
        balloonVisual.rotation = Quaternion.Euler(0f, 0f, spriteRotation);
    }

    void IncreaseSize()
    {
        // Increase the size of the balloon over time
        Vector3 newSize = balloonVisual.localScale + Vector3.one * sizeGrowthRate * Time.deltaTime;
        balloonVisual.localScale = newSize;

        // Adjust the size of the collider if necessary
        balloonCollider.localScale = balloonVisual.localScale;
    }
}
