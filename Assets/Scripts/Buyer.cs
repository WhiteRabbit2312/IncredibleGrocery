using UnityEngine;

public class Buyer : MonoBehaviour
{
    public GameObject cloud;

    public static bool triggerMenu;
    public static bool triggerGenerator;
    public static bool goAway;

    // Start is called before the first frame update
    void Start()
    {
        triggerMenu = false;
        triggerGenerator = false; 
        goAway = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (goAway)
        {
            gameObject.GetComponent<Animator>().Play("BuyerGoAwayAnimation");
        }
    }

    public void BuyerAnimation()
    {
        RestartManager.buyerCloud = Instantiate(cloud);
        triggerMenu = true;
    }

    public void GenerateFood()
    {
        triggerGenerator = true;
    }
}
