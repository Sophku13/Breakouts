using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncyBall : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;

    private Rigidbody2D rb;

    public TextMeshProUGUI scoreTxt;
    public GameObject[] hearts;

    public GameObject gameOverScreen;
    public GameObject gameWonScreen;
    
    private int score = 0;
    private int lives = 5;
    private int brickCounter;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brickCounter = FindObjectOfType<LevelGenerator>().transform.childCount;
        rb.velocity = Vector2.down * 8f;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY)
        {
            if(lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = Vector3.zero;
                rb.velocity = Vector2.down * 8f;
                lives --; //goes below the floor/ minimum y position
                hearts[lives].SetActive(false);
            }
        }
        if(rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            Debug.Log("Brick destroyed");
            score += 5;
            scoreTxt.text = score.ToString("00000");
            brickCounter--;
            if( brickCounter <= 0)
            {
                gameWonScreen.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
    void GameOver()
    {
        Debug.Log("Game Over :(");
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
