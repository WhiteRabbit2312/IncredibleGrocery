using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text moneyText;

    public static readonly int priceOfFood = 10;
    public static int correctFood;
    public static int wholeSum;

    void Start()
    {
        wholeSum = PlayerPrefs.GetInt("WholeSum");
    }

    void Update()
    {
        moneyText.text = "$ " + wholeSum.ToString();
    }

    public static void PriceCount()
    {
        int money = CompleteOrder.correctAnswer * priceOfFood;
        if (CompleteOrder.correctAnswer == BuyerCloud.numberOfFood)
        {
            money *= 2;
        }

        wholeSum += money;

        PlayerPrefs.SetInt("WholeSum", wholeSum);

        if(CompleteOrder.correctAnswer != 0)
            MusicManager.moneyS.Play();

    }
}
