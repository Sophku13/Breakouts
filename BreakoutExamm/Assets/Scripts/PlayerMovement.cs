using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float BorderX = 7.5f;
    float movementHorizontal;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if((movementHorizontal > 0 && transform.position.x < BorderX) || (movementHorizontal < 0 && transform.position.x > -BorderX))
        {
            transform.position += Vector3.right * movementHorizontal * Speed * Time.deltaTime; //frame rate adjusted for each device
        }
    }
}
