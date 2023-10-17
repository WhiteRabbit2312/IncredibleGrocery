using UnityEngine;

public class GetSprite : MonoBehaviour
{
    public GameObject emotionSprite;
    public Sprite like;
    public Sprite mad;

    void Start()
    {
        MusicManager.bubbleAppearS.Play();
    }

    void Update()
    {
        if (CompleteOrder.correctAnswer == BuyerCloud.numberOfFood)
        {
            emotionSprite.GetComponent<SpriteRenderer>().sprite = like;
        }

        else emotionSprite.GetComponent<SpriteRenderer>().sprite = mad;
    }

    public void CloudDisappear()
    {
        MusicManager.bubbleDisappearS.Play();
    }
}
