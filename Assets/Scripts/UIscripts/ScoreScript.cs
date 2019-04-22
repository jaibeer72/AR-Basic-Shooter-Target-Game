using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

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
        if (score < 0) { score = 0; }
        scoreText.text = "Score = "+ score.ToString(); 
    }   
    public void TotalScore()
    {
        totalScore.text = "Your Score Is " + score; 
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }
}
