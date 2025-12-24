using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class ScoreHudManager : MonoBehaviour
{
    public static ScoreHudManager instance;
    [SerializeField] TextMeshProUGUI charNameText;
    [SerializeField] TextMeshProUGUI scoreCounterText;
    [SerializeField] TextMeshProUGUI coinsCounterText;
    [SerializeField] TextMeshProUGUI timeCounterText;
    [SerializeField] TextMeshProUGUI phaseCounterText;


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
    public void SetCharName(string charName)
    {
        charNameText.text = charName;
    }

    public void SetScore(int score)
    {
        charNameText.text = score.ToString().PadLeft(6,'0');
    }

    public void SetCoins(int coins)
    {
        coinsCounterText.text = coins.ToString().PadLeft(2,'0');
    }

    public void SetPhaseCounter(int world, int phase)
    {
        phaseCounterText.text = world.ToString() + "-" + phase.ToString();
    }
    public void SetTimeCounter(float time)
    {
        timeCounterText.text = time.ToString();
    }
}
