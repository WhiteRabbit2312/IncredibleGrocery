using System.Collections;
using UnityEngine;

public class TickEnable : MonoBehaviour
{
    public GameObject emotion;
    public GameObject cashierCloud;
    public static bool goAway;

    void Start()
    {
        goAway = false;
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("TickEnable") && !goAway)
        {
            StartCoroutine(BuyerGoAway());
        }
    }
    private IEnumerator BuyerGoAway()
    {
        goAway = true;

        int waitAnswer = BuyerCloud.numberOfFood;
        yield return new WaitForSeconds(waitAnswer);
        Buyer.goAway = true;
        RestartManager.emotionCloud = Instantiate(emotion);
        MoneyManager.PriceCount();
    }
}
