using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHitScript : MonoBehaviour
{
    Transform Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player").transform; 
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            other.gameObject.SetActive(false);
            transform.position = Random.insideUnitSphere * 5;
            transform.LookAt(Player);
        }
    }
}
