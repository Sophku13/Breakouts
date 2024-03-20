using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BallBrickCollision
{
    [UnityTest]
    public IEnumerator BrickCollision()
    {
         // Creating the ball and adding a Rigidbody2D for physics 
        var ballGameObject = new GameObject("Ball");
        var ballRigidbody = ballGameObject.AddComponent<Rigidbody2D>();
        ballRigidbody.gravityScale = 1; // Ensure the ball is affected by gravity
        ballGameObject.transform.position = new Vector2(0, 2);

        var brickGameObject = new GameObject("Brick"); // Create brick object, add ccollider and tag
        brickGameObject.AddComponent<BoxCollider2D>();
        brickGameObject.tag = "Brick";
        var brickRigidbody = brickGameObject.AddComponent<Rigidbody2D>();
        brickRigidbody.bodyType = RigidbodyType2D.Static; // The brick won't move
        brickGameObject.transform.position = new Vector2(0, 0); 

        // Wait for physics to run
        yield return new WaitForSeconds(1f);

        // Check if the brick has been destroyed by the collision
        bool brickDestroyed = brickGameObject == null;

        if (ballGameObject != null) Object.DestroyImmediate(ballGameObject);
        if (brickGameObject != null) Object.DestroyImmediate(brickGameObject);

        // Assert
        Assert.IsTrue(brickDestroyed);
    }
}