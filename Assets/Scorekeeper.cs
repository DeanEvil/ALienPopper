using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text sceneText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] int level;
    [SerializeField] int scoreThresholdForThisLevel;

    public const int DEFAULT_POINTS = 1;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        score = PersistentData.Instance.GetScore();
        DisplayName();
        DisplayScene();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    public void AddPoints(int points)
    {
        score += points;
        PersistentData.Instance.SetScore(score);
        DisplayScore();

        if(score >= scoreThresholdForThisLevel)
        {
            SceneManager.LoadScene(level + 1); //level is already 1 less than the index (e.g. 1 instead of 2)
        }
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);

    }

    private void DisplayName()
    {
        nameText.SetText("Hi, " + PersistentData.Instance.GetName() + "!");
    }

    private void DisplayScore()
    {
        scoreText.SetText("Score: " + score);
    }

    private void DisplayScene()
    {
        sceneText.SetText("Level: " + level);
    }
}