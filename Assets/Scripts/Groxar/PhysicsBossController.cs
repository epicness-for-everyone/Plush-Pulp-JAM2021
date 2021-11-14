using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBossController : MonoBehaviour {

    private bool canJump;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float delta = Time.deltaTime;
        Vector2 force = new Vector2(1000f * delta, 0f);
        if (Input.GetKey("left")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(-force);
        }
        if (Input.GetKey("right")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(force);
        }
        if (Input.GetKeyDown("up") && canJump) {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Ground") {
            canJump = true;
        }
    }
}