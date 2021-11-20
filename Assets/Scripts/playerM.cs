using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerM : MonoBehaviour
{
    float runSpeed = 8;
    float jumpSpeed = 12;
    Rigidbody rb2d;

    float life;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("danio"))
        {
            print("danio");
        }
    }
    void Start()
    {
        rb2d = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
        }
        else
        {
            if (Input.GetKey("a") || Input.GetKey("left"))
            {
                rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
            }
            else
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
            }
        }
        if (Input.GetKey("space") && checkGroundM.isGround)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
    }
}