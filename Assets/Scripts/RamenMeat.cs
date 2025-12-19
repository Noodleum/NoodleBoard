using UnityEngine;

public class RamenMeat : MonoBehaviour
{
    public bool givenMultiplier = false;
    public int multiplierValue = 1;
    public GameObject PlayerUI;
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            if(givenMultiplier)
            {
                scoreManager.AddMultiplier(-multiplierValue);
                givenMultiplier = false;
            }
            RandomizeMeat();
            Debug.Log("Meat Hit Ground! Multiplier Decreased!" + (-multiplierValue).ToString());
        }
        if(givenMultiplier)
            return;
        
        if(collision.gameObject.name == "NoodleBowl" && !givenMultiplier)
        {
            scoreManager.AddMultiplier(multiplierValue);
            givenMultiplier = true;
            Debug.Log("Multiplier Increased!");
        }
    }
    void RandomizeMeat()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = new Vector2(Random.Range(-8f,8f),5.5f);
    }
}
