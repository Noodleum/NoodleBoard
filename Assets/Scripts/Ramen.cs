using UnityEngine;
using TMPro;
public class Ramen : MonoBehaviour
{
    public GameObject PlayerUI;
    public int value = 1;
    private ScoreManager scoreManager;

    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerUI = GameObject.Find("PlayerUI");
        scoreManager = PlayerUI.GetComponent<ScoreManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "NoodleBowl")
        {
            scoreManager.AddScore(value);
            Debug.Log("Ramen Collected!");
        }
        else if(collision.gameObject.name == "Ground")
        {
            RandomizeRamen();
        }
        //object pool
    }   
    void RandomizeRamen()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = new Vector2(Random.Range(-8f,8f),5.5f);
    }
}
