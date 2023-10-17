using System.Collections.Generic;
using UnityEngine;

public class BuyerCloud : MonoBehaviour
{
    public GameObject[] order;

    public static int numberOfFood;
    public static List<Sprite> foodInOrder = new List<Sprite>();

    private int foodInMenu = 20;

    void Start()
    {
        
    }

    public void GenerateFood()
    {
        MusicManager.bubbleAppearS.Play();

        numberOfFood = Random.Range(1, 4);

        for (int i = 0; i < numberOfFood; i++)
        {
            int iterationFood;
            do
            {
                iterationFood = Random.Range(0, foodInMenu);

            }
            while (foodInOrder.Exists(item => item == FoodList.foodList[iterationFood]));


            foodInOrder.Add(FoodList.foodList[iterationFood]);
            order[i].GetComponent<SpriteRenderer>().sprite = FoodList.foodList[iterationFood];
            order[i].SetActive(true);
        }
    }
    public void CloudDisappear()
    {
        MusicManager.bubbleDisappearS.Play();
    }
}
