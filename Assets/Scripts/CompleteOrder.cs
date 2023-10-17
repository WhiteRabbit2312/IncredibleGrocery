using System.Collections.Generic;
using UnityEngine;

public class CompleteOrder : MonoBehaviour
{
    public static List<Sprite> chosenFood = new List<Sprite>();
    public static int correctAnswer;

    public GameObject[] completeOrder;
    public GameObject[] correctFood;

    public Sprite tik;
    public Sprite cross;

    private bool once;

    void Start()
    {
        MusicManager.bubbleAppearS.Play();
        correctAnswer = 0;
        once = true;
    }

    void Update()
    {
        if (once)
        {
            CashierCloud();
            once = false;
        }
    }

    private void CashierCloud()
    {
        for (int i = 0; i < BuyerCloud.numberOfFood; i++)
        {
            completeOrder[i].GetComponent<SpriteRenderer>().sprite = chosenFood[i];

            completeOrder[i].SetActive(true);

            if(BuyerCloud.foodInOrder.Exists(item => item == chosenFood[i]))
            {
                correctFood[i].GetComponent<SpriteRenderer>().sprite = tik;
                correctAnswer++;   
            }
            else
            {
                correctFood[i].GetComponent<SpriteRenderer>().sprite = cross;
            }
        }
    }

    public void CorrectOrder()
    {
        for (int i = 0; i < BuyerCloud.numberOfFood; i++)
        {
            correctFood[i].SetActive(true);
        }
    }
}
