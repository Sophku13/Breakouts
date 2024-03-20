using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class ScoreUpdateTest
{
    [UnityTest]
    public IEnumerator ScoreUpdate()
    {
        //ball setup from previous tests
        var ballGameObject = new GameObject("Ball");
        var ballRigidbody = ballGameObject.AddComponent<Rigidbody2D>();
        ballGameObject.AddComponent<CircleCollider2D>();
        var bouncyBall = ballGameObject.AddComponent<BouncyBall>();
        ballRigidbody.gravityScale = 0; // Prevent the ball from falling 

        // initially set the score to 0 
        bouncyBall.score = 0;

        // Setup the brick with a Collider2D
        var brickGameObject = new GameObject("Brick");
        brickGameObject.tag = "Brick";
        var brickCollider = brickGameObject.AddComponent<BoxCollider2D>();
        brickGameObject.transform.position = new Vector2(0, 1); // position the brick within collision range of the ball

        // manually create collision by moving the ball to the brick
        ballGameObject.transform.position = brickGameObject.transform.position;

        // wait to allow the physics engine to process the collision
        yield return null;

        // check if the score has been updated correctly
        Assert.AreEqual(5, bouncyBall.score);
        
        //clean up
        GameObject.DestroyImmediate(ballGameObject);
        GameObject.DestroyImmediate(brickGameObject);
    }
}
