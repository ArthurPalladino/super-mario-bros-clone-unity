using UnityEngine;

public class ScoreController : MonoBehaviour
{
    int coins;
    int score;
    int time;
    PhaseScoreController scoreController;

    void Start()
    {
        scoreController = Object.FindFirstObjectByType<PhaseScoreController>();
    }
    public void addCoin()
    {
        coins+=1;
        scoreController.SetCoins(coins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
