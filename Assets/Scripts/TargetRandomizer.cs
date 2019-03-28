using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRandomizer : MonoBehaviour
{

    public Transform Player;
    public GameObject[] foodPrefabs;
    public int maxFoodInScean = 5; 
    public Transform destination;
    public Vector2 maxMinAroundX = new Vector2(-45f, 45f);
    public Vector2 maxMinAroundY = new Vector2(0, 360f);
    float radius;
    Dictionary<int, GameObject> dictonaryInSceanFood = new Dictionary<int, GameObject>(); 

    // Start is called before the first frame update
    void Start()
    {
        radius = Vector3.Distance(Player.position, destination.position); 
        Screen.orientation = ScreenOrientation.Portrait;
        for (int i = 0; i < maxFoodInScean; i++)
        {
            dictonaryInSceanFood.Add(i, InstantiateFood()); 
        }
    }

    private void Update()
    {
        for (int i = 0; i < dictonaryInSceanFood.Count; i++)
        {
            if(dictonaryInSceanFood[i].GetComponent<CheckTrigger>().isEaten == true)
            {
                Destroy(dictonaryInSceanFood[i]); 
                dictonaryInSceanFood[i] = InstantiateFood();
                ScoreScript.score++; 
            } 
           
        }
    }

    public Vector3 retRandLocation()
    {
        float angleX = Random.Range(maxMinAroundX.x, maxMinAroundX.y); 
        float angleY = Random.Range(maxMinAroundY.x, maxMinAroundY.y); 
        Vector3 pointOnSphere = new Vector3();
        pointOnSphere.x = Player.transform.position.x + radius * Mathf.Cos(angleY) * Mathf.Cos(angleX);
        pointOnSphere.y = Player.transform.position.y + radius * Mathf.Sin(angleX);
        pointOnSphere.z = Player.transform.position.z + radius * Mathf.Sin(angleY) * Mathf.Cos(angleX);
        return pointOnSphere; 
        
    }

    public GameObject AssignTargetPosition(GameObject target)
    {

        target.transform.position = retRandLocation();
        target.transform.LookAt(Player);
        return target;
    } 

    public GameObject InstantiateFood()
    {
        int index = Random.Range(0, foodPrefabs.Length);
        GameObject food = Instantiate(foodPrefabs[index], retRandLocation(), transform.rotation, transform) as GameObject;
        food.transform.LookAt(Player.transform); 
        return food; 
    }
}
