using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CountDownTimer : MonoBehaviour
{

    [SerializeField]
    private Text uitimer;
    [SerializeField]
    private float mainTimer;
    float timer; 
    public bool canCount = true;
    public bool doOnce = false;
    public bool hasGameStarted = false;
    public GameObject disableMainGame;
    public GameObject displayTotalScore;
    public GameObject scoreScript; 
    // Start is called before the first frame update
    void Start()
    {
        timer = mainTimer; 
    }

    // Update is called once per frame
    void Update()
    {
        if (hasGameStarted)
        {
            if (timer >= 0.0f && canCount)
            {
                timer -= Time.deltaTime;
                uitimer.text = timer.ToString("F");

            }
            else if (timer <= 0.0f && !doOnce)
            {
                canCount = false;
                doOnce = true;
                uitimer.text = "0.00";
                timer = 0.0f;
                disableMainGame.SetActive(false);
                scoreScript.GetComponent<ScoreScript>().TotalScore(); 
                displayTotalScore.SetActive(true); 
            }
        }
    }

    public void ResetButton()
    {
        timer = mainTimer;
        canCount = true;
        doOnce = false; 
    }

    public void SetHasGameStarted(bool check)
    {
        hasGameStarted = check; 
    }
}
