using System;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public GameObject RamenMeatPrefab;
    public GameObject RamenPrefab;
    public float TimeBetweenIncreases = 30f;
    private float timer = 0f;
    public int rightLimit = 8;
    public int leftLimit = -8;
    public float spawnHeight = 5.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= TimeBetweenIncreases)
        {
            IncreaseDifficulty();
            timer = UnityEngine.Random.Range(0f, 10f);
        }
    }

    private void IncreaseDifficulty()
    {
        // Spawn additional Ramen Meat
        Vector2 meatPosition = new Vector2(UnityEngine.Random.Range(leftLimit, rightLimit), spawnHeight);
        Instantiate(RamenMeatPrefab, meatPosition, Quaternion.identity);

        // Spawn additional Ramen
        Vector2 ramenPosition = new Vector2(UnityEngine.Random.Range(leftLimit, rightLimit), spawnHeight);
        Instantiate(RamenPrefab, ramenPosition, Quaternion.identity);
    }
}
