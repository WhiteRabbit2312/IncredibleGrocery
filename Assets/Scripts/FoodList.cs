using System.Collections.Generic;
using UnityEngine;

public class FoodList : MonoBehaviour
{
    public Sprite[] foodSprites;
    public static List<Sprite> foodList = new List<Sprite>();

    void Awake()
    {
        for(int i = 0; i < foodSprites.Length; i++)
        {
            foodList.Add(foodSprites[i]);
        }
    }
}
