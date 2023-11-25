using System.Diagnostics;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;

public class BalloonController : MonoBehaviour
{
    [SerializeField] GameObject controller;
    public float moveSpeed = 10.0f;        // Speed of the Balloon's vertical movement
    public float minSize = 3.0f;          //minimal size of balloon
    public float maxSize = 4.0f;          // Maximum size of the Balloon before level restart
    public int maxPoints = 5;        //Amount of points if balloon is popped while its size is still less than minSize  
    public int minPoints = 3;        //Amount of points if balloon is popped while its size is more than minSize  
    public float sizeIncreaseRate = 0.5f; // Rate at which the Balloon size increases over time
    public AudioClip popSound;
    public int index = 1;

    private Animator popAnimator;
    private float moveDirection = 1.0f;        // 1 for moving up, -1 for moving down
    private AudioSource audioSource;
    private float estimatedAnimTime = 1.0f;

    void Start()
    {
        if (controller == null)
        {
            controller = GameObject.FindGameObjectWithTag("GameController");
        }
        // Assuming you have an Animator component attached to the same GameObject as this script
        popAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        MoveBalloon();
        CheckCollision();
        IncreaseSize();
        CheckSizeLimit();
    }

    void MoveBalloon()
    {
        // Move the Balloon vertically
        transform.Translate(Vector3.up * moveDirection * moveSpeed * Time.deltaTime);
    }

    void CheckCollision()
    {

        // Check if the Balloon collides with objects tagged as "Obstacle"
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale / 2, 0);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Bullet"))
            {   
                int level = SceneManager.GetActiveScene().buildIndex;
                PopBalloon();
                SceneManager.LoadScene(level + 1);
            }
        }
    }

    void IncreaseSize()
    {
        // Increase the size of the Balloon over time
        transform.localScale += new Vector3(sizeIncreaseRate, sizeIncreaseRate, 0) * Time.deltaTime;
    }

    void CheckSizeLimit()
    {
        // Check if the Balloon size exceeds the specified limit for level restart
        if (transform.localScale.y > maxSize)
        {
            // Add your code here for level restart
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            UnityEngine.Debug.Log("Level Restarted");
        }
    }

    void PopBalloon()
    {
        // Trigger the "Pop" animation
        if (popAnimator != null)
        {
            float balloonSize = transform.localScale.y;

            if (balloonSize < minSize)
            {
                // Balloon size is less than minSize, add  maxPoints
                controller.GetComponent<Scorekeeper>().AddPoints(maxPoints);
            }
            else if (balloonSize >= minSize && balloonSize < maxSize)
            {
                // Balloon size is between minSize and maxSize, add  minPoints
                controller.GetComponent<Scorekeeper>().AddPoints(3);
            }

            popAnimator.SetTrigger("Pop");

            if (audioSource != null && popSound != null)
            {
                AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
            }

            // Destroy the GameObject after the animation is finished
            Destroy(gameObject, estimatedAnimTime);
        }

    }
        
}
