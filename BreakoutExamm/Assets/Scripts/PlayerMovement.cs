using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float borderX = 7.5f;
    private float movementHorizontal;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if((movementHorizontal > 0 && transform.position.x < borderX) || (movementHorizontal < 0 && transform.position.x > -borderX))
        {
            transform.position += Vector3.right * movementHorizontal * speed * Time.deltaTime; //frame rate adjusted for each device
        }
    }
}
