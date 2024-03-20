using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the behavior of the bouncy ball, including physics interactions,
/// game state changes (score, lives), and triggering game over/win conditions.
/// </summary>

public class BouncyBall : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;

    private Rigidbody2D rb;

    public Text scoreTxt;
    public GameObject[] hearts;

    public GameObject gameOverScreen;
    public GameObject gameWonScreen;
    
    public int score = 0;
    private int lives = 5;
    private int brickCounter;

    /// Initialization of the ball's physics and setting up the initial game state.
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brickCounter = FindObjectOfType<LevelGenerator>().transform.childCount;  // Counts the initial number of bricks to determine when the game has been won.
        rb.velocity = Vector2.down * 8f; // Sets initial downward velocity.
    }
    /// <summary>
    /// Updates the ball's behavior each frame, checking for game over conditions
    /// and enforcing maximum velocity constraints.
    /// </summary>
    void Update()
    {
        if(transform.position.y < minY) // Checks if the ball has dropped below the minimum Y threshold.
        {
            if(lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = Vector3.zero; // Resets the ball's position and velocity, and decrements lives.
                rb.velocity = Vector2.down * 8f;
                lives --; //goes below the floor/ minimum y position
                hearts[lives].SetActive(false);
            }
        }
        if(rb.velocity.magnitude > maxVelocity) // Enforces a maximum velocity on the ball.
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }
    /// <summary>
    /// Handles collision with bricks, destroying them, updating the score,
    /// and checking for win conditions.
    /// </summary>
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
                Debug.Log("Victory!");
            }
        }
    }
    void GameOver()  // Triggers the game over state, displaying the game over screen.
    {
        Debug.Log("Game Over :(");
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
