using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource bubbleAppear;
    public AudioSource bubbleDisappear;
    public AudioSource buttonClick;
    public AudioSource money;
    public AudioSource musicLoop;
    public AudioSource productSelect;

    public static AudioSource bubbleAppearS;
    public static AudioSource bubbleDisappearS;
    public static AudioSource buttonClickS;
    public static AudioSource moneyS;
    public static AudioSource musicLoopS;
    public static AudioSource productSelectS;

    void Awake()
    {
        bubbleAppearS = bubbleAppear;
        bubbleDisappearS = bubbleDisappear;
        buttonClickS = buttonClick;
        moneyS = money;
        musicLoopS = musicLoop;
        productSelectS = productSelect;
    }
}
