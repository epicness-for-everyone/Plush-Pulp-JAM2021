using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBossController : MonoBehaviour {

    private bool canJump;
    private bool shaking;
    private float shakeTime;
    private Vector3 shakeVector;

    // Start is called before the first frame update
    void Start() {
        shakeVector = new Vector3(100f, 0f, 0f);
    }

    // Update is called once per frame
    void Update() {
        float delta = Time.deltaTime;
        Vector2 force = new Vector2(1000f * delta, 0f);

        HandleMovement(force);

        if (Input.GetKeyDown("space") && canJump) {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
        }
        if (Input.GetKeyDown("up")) {
            gameObject.GetComponent<Animator>().SetBool("attacking", true);
        }
        HandleShaking(delta);
    }

    private void HandleMovement(Vector2 force) {
        if (shaking) {
            return;
        }
        if (Input.GetKey("left")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(-force);
        }
        if (Input.GetKey("right")) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }

    private void HandleShaking(float delta) {
        if (!shaking) {
            return;
        }
        shakeTime += delta;
        if (shakeTime > 0.03f) {
            shakeVector = -shakeVector;
            shakeTime -= 0.03f;
        }
        transform.Translate(shakeVector * delta);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Ground") {
            canJump = true;
        }
    }

    public void StartShaking() {
        shaking = true;
    }

    public void StopShaking() {
        shaking = false;
    }
}