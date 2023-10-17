using UnityEngine;

public class SpawnerBuyers : MonoBehaviour
{
    public GameObject buyer;
    public static bool buyerOrder;
    public bool spawnBuyer;

    void Start()
    {
        buyerOrder = false;
        spawnBuyer = false;
    }

    void Update()
    {
        if (!GameObject.FindGameObjectWithTag("Buyer"))
        {
            RestartManager.buyer = Instantiate(buyer);
        }
    }
}
