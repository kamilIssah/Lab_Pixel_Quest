using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private Rigidbody2D rb; // Controls player physics
    public int speed = 5; // Controls player speed
    private SpriteRenderer sr1; // Controls player image
    // Start is called before the first frame update
    void Start()
    {
        sr1 = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
   
    }

    // Update is called once per frame
    void Update()
    {
        //Get player player movement form player button press
        float xInput = Input.GetAxis("Horizontal");

        if (xInput < 0)
        {
            sr1.flipX = false; //facing right
        }
        else if (xInput > 0)
        {
            sr1.flipX = true; //facing left
        }
        // Give the speed to the rigid body
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }

}
