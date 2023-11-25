using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int totalBalloons;

    void Start()
    {
        // Count the total number of balloons in the level
        totalBalloons = GameObject.FindGameObjectsWithTag("Balloon").Length;
    }

    public void BalloonPopped()
    {
        totalBalloons--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (totalBalloons <= 0)
        {
            // All balloons popped, transition to the next level
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
