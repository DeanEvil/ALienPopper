using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int totalBalloons = 0;

    void Start()
    {
        // Count the total number of balloons in the level
        totalBalloons = GameObject.FindGameObjectsWithTag("Balloon").Length;
        Debug.Log(totalBalloons);
    }

    public void BalloonPopped()
    {
        while (totalBalloons > 0)
        {
            totalBalloons--;
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            if (totalBalloons < 1)
            {
                // All balloons popped, transition to the next level
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }
}
