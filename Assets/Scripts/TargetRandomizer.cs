using System.Collections; 
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 


[System.Serializable]
public struct FoodTypeManager
{
    public GameObject foodPrefab;
    public int score;
    public bool isEdible;

    public FoodTypeManager(GameObject  prefab, int Score , bool isPositive )
    {
        foodPrefab = prefab;
        score = Score;
        isEdible = isPositive; 
    }
}

public class TargetRandomizer : MonoBehaviour
{
    public Transform Player;
    public FoodTypeManager[] foodTypeManager;
    public int maxFoodInScean = 5; 
    public Transform destination;
    public Vector2 maxMinAroundX = new Vector2(-45f, 45f);
    public Vector2 maxMinAroundY = new Vector2(0, 360f);
    float radius;
    Dictionary<int, FoodTypeManager> dictonaryInSceanFood = new Dictionary<int, FoodTypeManager>();
    public Canvas canvasPrefab; 
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
            if(dictonaryInSceanFood[i].foodPrefab.GetComponent<CheckTrigger>().isEaten == true)
            {
                Destroy(dictonaryInSceanFood[i].foodPrefab);
                InstantiateCanvasScore(dictonaryInSceanFood[i].score,dictonaryInSceanFood[i].foodPrefab.transform);
                dictonaryInSceanFood[i] = InstantiateFood();
            } 
           
        }
    }

    private void InstantiateCanvasScore(int score, Transform transfrom)
    {
        Canvas scorePopUp = Instantiate(canvasPrefab, transfrom.position, transform.rotation) as Canvas;
        if (score < 0)
        {
            scorePopUp.GetComponentInChildren<Text>().color = Color.red; 
            scorePopUp.GetComponentInChildren<Text>().text = "" + score.ToString();
            
        }
        else
        {
            scorePopUp.GetComponentInChildren<Text>().color = Color.green;
            scorePopUp.GetComponentInChildren<Text>().text = "+" + score.ToString();
        }
        ScoreScript.score += score;
        Destroy(scorePopUp.gameObject,2f);
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

    public FoodTypeManager InstantiateFood()
    {
        int index = Random.Range(0, foodTypeManager.Length);
        GameObject food = Instantiate(foodTypeManager[index].foodPrefab, retRandLocation(), transform.rotation, transform) as GameObject;
        food.transform.LookAt(Player.transform);
        FoodTypeManager foodDictAdd = new FoodTypeManager(food, foodTypeManager[index].score, foodTypeManager[index].isEdible); 
        return foodDictAdd; 
    }
}
