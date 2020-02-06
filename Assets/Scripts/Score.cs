using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score : "+score.ToString();
    }
}
