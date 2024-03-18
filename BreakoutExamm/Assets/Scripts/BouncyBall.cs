using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    public float MinY = -5.5f;
    public float MaxVelocity = 15f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < MinY)
        {
            transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
        if(rb.velocity.magnitude > MaxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxVelocity);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
        }
    }
}
