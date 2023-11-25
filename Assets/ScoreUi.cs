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
        scoreManager.AddScore(new Score("Ernando", 69));
        scoreManager.AddScore(new Score("Bozo", 50));

        var scores = scoreManager.GetHighScores().ToArray();
        for (int i = 0; i < scores.Length; i++)
        {
            var row = Instantiate(rowUi, transform).GetComponent<RowUi>();
            row.rank.text = (i + 1).ToString();
            row.name.text = scores[i].name;
            row.score.text = scores[i].score.ToString();
        }
    }
}
