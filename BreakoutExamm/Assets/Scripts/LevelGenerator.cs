using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Generates the level layout by instantiating bricks according to specified parameters.
/// </summary>

public class LevelGenerator : MonoBehaviour
{
    public Vector2Int size;  // Grid size for placing bricks.
    public Vector2 offset; // Offset between bricks for placement.
    public GameObject brickPrefab; 
    public Gradient gradient; // Gradient for coloring the bricks.

    /// <summary>
    /// Called when the script instance is being loaded.
    /// Generates the grid of bricks based on the provided size, offset, and colors them using the specified gradient.
    /// </summary>
    private void Awake() 
    {
        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + new Vector3((float)((size.x -1)* 0.5f - i) * offset.x, j * offset.y, 0);
                newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float) j / (size.y - 1));
            }
        }
    }
    public void Restart() // Restarts the current level by reloading the active scene.
    {
        Time.timeScale = 1; // Ensure the game is not paused.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the scene.

    }
}
