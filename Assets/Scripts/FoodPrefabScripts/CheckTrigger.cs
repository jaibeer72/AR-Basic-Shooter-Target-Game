using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public bool isEaten = false;
    public Vector3 rotateAround = new Vector3(0,1,0);
    public float rotationSpeed=20f; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateAround, 5 * Time.deltaTime * rotationSpeed); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponentInParent<AudioSource>().Play();
            
            other.GetComponentInParent<MonsterController>().monsterState = MonsterState.isEating;
            other.transform.LookAt(this.transform);
            isEaten = true; 
        }
    }
}
