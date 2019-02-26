using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitScript : MonoBehaviour
{
    Transform Player;
    public float highScoreDistance, medScoreDistance, longScoreDistance;


    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }
    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + highScoreDistance, transform.position.y + highScoreDistance, transform.position.z));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            addScore(Vector3.Distance(other.transform.position, transform.position)); 
            other.gameObject.SetActive(false);
            transform.position = Random.insideUnitSphere * 5;
            transform.LookAt(Player);
        }
    }

    public void addScore(float distance)
    {
        if (distance < highScoreDistance)
        {
            //Add the highest score bulls eye score. 
            ScoreScript.score += 5;
        }
        else if (distance > highScoreDistance && distance < medScoreDistance)
        {
            //Add medium score. 
            ScoreScript.score += 2; 
        }
        else
        {
            //Add lowest score.
            ScoreScript.score += 1; 
        }
        Debug.Log(ScoreScript.score);
    }
}
