using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public RowUi rowUi;
    public ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        if (PersistentData.Instance != null)
        {
            string playerName = PersistentData.Instance.GetName();
            int playerScore = PersistentData.Instance.GetScore();

            scoreManager.AddScore(new Score(playerName, playerScore));
        }
        scoreManager.AddScore(new Score("Dummy1", 0));
        scoreManager.AddScore(new Score("Dummy2", 0));
        scoreManager.AddScore(new Score("Dummy3", 0));
        scoreManager.AddScore(new Score("Dummy4", 0));
        scoreManager.AddScore(new Score("Dummy5", 0));

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            row.rank.text = (i + 1).ToString();
            row.named.text = scores[i].named;
            row.score.text = scores[i].score.ToString();
        }
    }
}
