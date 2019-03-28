using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform destination; 
    public float speed = 0.6f;
    public float stoppoingDistance = 1.0f;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveMosterWithCam();
    }

    private void MoveMosterWithCam()
    {
        if (Vector3.Distance(transform.position, destination.transform.position) > stoppoingDistance)
        {
            Vector3 dir =  destination.transform.position-transform.position;
            dir = dir.normalized;
            transform.LookAt(dir);
            transform.position = Vector3.SmoothDamp(transform.position, destination.transform.position, ref velocity, speed);
        }
        else
        {
            transform.LookAt(Camera.main.transform); 
        }
    }
}
