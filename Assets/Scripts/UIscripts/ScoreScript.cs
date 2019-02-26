using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreScript : MonoBehaviour
{
    public static int score;
    public Text scoreText;

    private void Start()
    {
        score = 0; 
    }

    private void Update()
    {
        scoreText.text = "Score = "+ score; 
    }
}
