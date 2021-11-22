using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private bool canJump;

    void Start() {

    }

    void Update() {
        float delta = Time.deltaTime;
        Vector2 force = new Vector2(1500f * delta, 0f);

        HandleMovement(force);

        if (Input.GetKeyDown("space") && canJump) {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 300f));
        }
    }
    private void HandleMovement(Vector2 force) {
        if (Input.GetKey("left")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(-force);
        }
        if (Input.GetKey("right")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Ground") {
            canJump = true;
        } else {
            Debug.Log(collision.transform.tag == "Finish");
        }
    }
}