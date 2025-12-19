using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("UI Elements")]
    public TMP_Text ScoreText;
    public TMP_Text MultiplierText;

    public TMP_Text TimeText;
    [Header("Score Values")]
    public int score = 0;
    public int multiplier = 1;
    private float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score.ToString();
        MultiplierText.text = "Multiplier: x" + multiplier.ToString();
        time += Time.deltaTime;
        TimeText.text = "Time: " + Mathf.FloorToInt(time).ToString();

    }
    public void AddScore(int amount)
    {
        score += amount*multiplier;
    }
    public void AddMultiplier(int amount)
    {
        multiplier += amount;
    }
}
