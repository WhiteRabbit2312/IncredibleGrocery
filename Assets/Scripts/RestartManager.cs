using UnityEngine;


public class RestartManager : MonoBehaviour
{
    public static GameObject buyer;
    public static GameObject cashierCloud;
    public static GameObject emotionCloud;
    public static GameObject buyerCloud;

    public void BuyerIsOut()
    {
        Destroy(buyer);
        Destroy(cashierCloud);
        Destroy(emotionCloud);
        Destroy(buyerCloud);
        TickEnable.goAway = false;
        Menu.RestartMenu();
        BuyerCloud.foodInOrder.Clear();
    }
}

