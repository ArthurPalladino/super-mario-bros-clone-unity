using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    void Awake()
    {
        if(instance == null)
        {
            
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    int coins;
    int score;
    int time;

    void Start()
    {
    }
    public void addCoin()
    {
        coins+=1;
        ScoreHudManager.instance.SetCoins(coins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
