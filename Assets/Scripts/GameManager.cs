using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool windowOpen = false;
    public float timer;
    public int segment;
    public int questionIndex;
    public int goodAnswers;
    public int gameHealth;
    public int windowHealth = 5;
    public bool phoneRang = false;
    public bool firstScreenInteraction = true;
    public bool badBuy = false;
    public bool bird = false;
    public bool kids = false;
    public bool isLightON = true;
    public int badGuyLevel = 0;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}