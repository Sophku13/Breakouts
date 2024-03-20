using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BallPaddleTets
{
    [UnityTest]
    public IEnumerator BallPaddleCollision()
    {
        // create a paddle object with a box collider
        GameObject paddle = new GameObject("Paddle");
        BoxCollider2D paddleCollider = paddle.AddComponent<BoxCollider2D>();
        paddle.transform.position = new Vector2(0, -1); // Position the paddle

        // create a player GameObject with a Rigidbody and CircleCollider2D
        GameObject ball = new GameObject("Ball"); // eventhough in the game its a box, its better to see the sphere amongst the box components
        ball.AddComponent<Rigidbody2D>();
        CircleCollider2D ballCollider = ball.AddComponent<CircleCollider2D>();
        ball.transform.position = new Vector2(0, 0); // positioning the ball above the paddle

        // time for physics to simulate
        yield return new WaitForSeconds(0.5f);

        // check if the ball is now below the paddle to infer collision and bounce
        bool didCollide = ball.transform.position.y < paddle.transform.position.y;

        Assert.IsTrue(didCollide);

        // cleanup
        Object.DestroyImmediate(paddle);
        Object.DestroyImmediate(ball);
    }
}
