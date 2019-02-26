using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomizer : MonoBehaviour
{

    public Transform Player;
    public GameObject[] targets; 

    // Start is called before the first frame update
    void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("Target");
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = AssignTargetPosition(targets[i]); 
        }
    }


    public Vector3 retRandLocation()
    {
        return Random.insideUnitSphere * 5;
    }

    public GameObject AssignTargetPosition(GameObject target)
    {
        target.transform.position = retRandLocation();
        target.transform.LookAt(Player);
        return target;
    } 
}
