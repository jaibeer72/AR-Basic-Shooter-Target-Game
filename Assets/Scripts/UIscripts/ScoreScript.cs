using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreScript : MonoBehaviour
{
    public static int score;
    public Text scoreText;
    public Text totalScore; 

    private void Start()
    {
        score = 0; 
    }

    private void Update()
    {
        scoreText.text = "Score = "+ score; 
    }   
    public void TotalScore()
    {
        totalScore.text = "Your Score Is " + score; 
    }
}
