using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public string named;
    public float score;

    public Score(string named, float score)
    {
        this.named = named;
        this.score = score;
    }
}
