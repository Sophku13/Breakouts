using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages the horizontal movement of the player's paddle within defined boundaries.
/// </summary>

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float borderX = 7.5f;
    private float movementHorizontal;

    /// Handles the input and movement of the paddle each frame, ensuring it stays within the horizontal boundaries.
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal"); // Gets the horizontal axis input.
        if((movementHorizontal > 0 && transform.position.x < borderX) || (movementHorizontal < 0 && transform.position.x > -borderX))
        {// Moves the paddle based on player input and ensures movement is consistent across different frame rates.
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime; //frame rate adjusted for each device
        }
    }
}
