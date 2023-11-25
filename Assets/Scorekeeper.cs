using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text sceneText;
    [SerializeField] TMP_Text nameText;
    [SerializeField] int level;
    [SerializeField] int scoreThresholdForThisLevel;

    public const int DEFAULT_POINTS = 5;

    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        //score = PersistentData.Instance.GetScore();
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
        UnityEngine.Debug.Log("score: " + score);
        DisplayScore();
        PersistentData.Instance.SetScore(score);
    }

    public void AddPoints()
    {
        AddPoints(DEFAULT_POINTS);

    }

    private void DisplayName()
    {
        nameText.text = "Hello " + PersistentData.Instance.GetName() + "!";
    }

    private void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void DisplayScene()
    {
        sceneText.text = "Level: " + level;
    }
}
