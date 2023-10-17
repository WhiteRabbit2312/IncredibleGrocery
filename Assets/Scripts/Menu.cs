using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Animator close;

    public GameObject cashierCloud;
    public GameObject buyerCloud;

    public Button sellButton;

    public static int pressCount;
    public static List<string> chosenFood = new List<string>();
    public static GameObject menu;
    public static bool sellButtonPressed;

    private GameObject tikOnFood;

    void Start()
    {
        pressCount = 0;
        sellButton.enabled = false;
        menu = gameObject;
        sellButtonPressed = false;
    }

    void Update()
    {
        if (Buyer.triggerMenu)
        {
            StartCoroutine("MenuEnable");
            Buyer.triggerMenu = false;
        }

        //enable/disable sell button
        if (pressCount == BuyerCloud.numberOfFood && !sellButtonPressed)
        {
            sellButton.enabled = true;
            Image foodImage = sellButton.GetComponent<Image>();
            Color imageColor = foodImage.color;
            imageColor.a = 1f;
            foodImage.color = imageColor;
        }
        else
        {
            sellButton.enabled = false;
            Image foodImage = sellButton.GetComponent<Image>();
            Color imageColor = foodImage.color;
            imageColor.a = 0.5f;
            foodImage.color = imageColor;
        }  
    }

    private IEnumerator MenuEnable()
    {
        yield return new WaitForSeconds(5f);
        gameObject.GetComponent<Animator>().Play("MenuAnimation");
    }

    public void FoodButton(Button button)
    {
        for (int i = 0; i < FoodList.foodList.Count; i++)
        {
            if(button.tag == FoodList.foodList[i].name && !chosenFood.Contains(button.tag))
            {
                //make the button pressed (enable tick and 0.7 of transparency)
                if (pressCount < BuyerCloud.numberOfFood)
                {
                    chosenFood.Add(button.tag);
                    CompleteOrder.chosenFood.Add(FoodList.foodList[i]);

                    pressCount++;
                    Image foodImage = button.GetComponent<Image>();
                    Color imageColor = foodImage.color;
                    imageColor.a = 0.7f;
                    foodImage.color = imageColor;
                    tikOnFood.SetActive(true);
                    MusicManager.productSelectS.Play();
                }
            }

            else if (button.tag == FoodList.foodList[i].name && chosenFood.Contains(button.tag))
            {
                //return button to normal state 
                if (pressCount <= BuyerCloud.numberOfFood && tikOnFood.activeSelf)
                {
                    chosenFood.Remove(button.tag);
                    CompleteOrder.chosenFood.Remove(FoodList.foodList[i]);

                    pressCount--;
                    Image foodImage = button.GetComponent<Image>();
                    Color imageColor = foodImage.color;
                    imageColor.a = 1f;
                    foodImage.color = imageColor;
                    tikOnFood.SetActive(false);
                    MusicManager.productSelectS.Play();
                }
            }
        }
    }

    //get the tick on exact button
    public void Tik(GameObject tick)
    {
        tikOnFood = tick;
    }

    public void SellButton(Button sellButton)
    {
        gameObject.GetComponent<Animator>().Play("MenuCloseAnimation");
        RestartManager.cashierCloud = Instantiate(cashierCloud);
        sellButton.enabled = false;
        sellButtonPressed = true;
    }

    public static void RestartMenu()
    {
        pressCount = 0;
        GameObject[] ticks = GameObject.FindGameObjectsWithTag("Choose");
        
        for (int i = 0; i < ticks.Length; i++)
        {
            ticks[i].SetActive(false);
        }

        for (int i = 0; i < chosenFood.Count; i++)
        {
            GameObject pressedButton = GameObject.FindGameObjectWithTag(chosenFood[i]);
            Image foodImage = pressedButton.GetComponent<Image>();
            Color imageColor = foodImage.color;
            imageColor.a = 1f;
            foodImage.color = imageColor;  
        }

        sellButtonPressed = false;
        chosenFood.Clear();
        CompleteOrder.chosenFood.Clear();
    }
}
