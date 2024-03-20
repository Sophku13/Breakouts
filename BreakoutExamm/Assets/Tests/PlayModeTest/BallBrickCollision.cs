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
         // creating the ball and adding a Rigidbody2D for physics 
        var ballGameObject = new GameObject("Ball");
        var ballRigidbody = ballGameObject.AddComponent<Rigidbody2D>();
        ballRigidbody.gravityScale = 1; // ensure the ball is affected by gravity
        ballGameObject.transform.position = new Vector2(0, 2);

        var brickGameObject = new GameObject("Brick"); // create brick object, add ccollider and tag
        brickGameObject.AddComponent<BoxCollider2D>();
        brickGameObject.tag = "Brick";
        var brickRigidbody = brickGameObject.AddComponent<Rigidbody2D>();
        brickRigidbody.bodyType = RigidbodyType2D.Static; // brick won't move
        brickGameObject.transform.position = new Vector2(0, 0); 

        // wait for physics to run
        yield return new WaitForSeconds(1f);

        // check if the brick has been destroyed by the collision
        bool brickDestroyed = brickGameObject == null;

        // clean up
        if (ballGameObject != null) Object.DestroyImmediate(ballGameObject);
        if (brickGameObject != null) Object.DestroyImmediate(brickGameObject);

        // Assert
        Assert.IsTrue(brickDestroyed);
    }
}