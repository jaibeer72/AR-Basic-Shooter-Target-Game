using UnityEngine;


public enum MonsterState
{
    idel,isEating
}; 
public class MonsterController : MonoBehaviour
{
    public Transform destination; 
    public float speed = 0.6f;
    public float stoppoingDistance = 1.0f;
    private Vector3 velocity = Vector3.zero;
    public MonsterState monsterState = MonsterState.idel;
    Animation animation;   
    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animation>(); 
    }

    // Update is called once per frame
    void Update()
    {
        switch (monsterState)
        {
            case MonsterState.idel:
                MoveMosterWithCam();
                if (!animation.IsPlaying("Anim_Idle"))
                {
                    animation.Play("Anim_Idle"); 
                }
                break;
            case MonsterState.isEating:
                if (animation.IsPlaying("Anim_Attack"))
                {
                    if (animation["Anim_Attack"].normalizedTime > 0.8f)
                    {
                        
                        monsterState = MonsterState.idel; 
                    }
                }
                else
                {
                    animation.Play("Anim_Attack"); 
                }
                break;
            default:
                Debug.Log("monster state switch case error"); 
                break;
        }
        
    }

    private void MoveMosterWithCam()
    {
        if (Vector3.Distance(transform.position, destination.transform.position) > stoppoingDistance)
        {
            Vector3 dir = destination.transform.position - transform.position;
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
