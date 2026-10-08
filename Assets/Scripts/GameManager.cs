using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText.text = "Score: " + score;
    }

    public void CountScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        Debug.Log("Score = " + score);
    }
}
