using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearBossController : MonoBehaviour {

    private float startingY;
    private bool canJump;

    // Start is called before the first frame update
    void Start() {
        startingY = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        float delta = Time.deltaTime;
        float translation = 50f * delta;
        if (Input.GetKey("left")) {
            gameObject.transform.Translate(-translation, 0f, 0f);
        }
        if (Input.GetKey("right")) {
            gameObject.transform.Translate(translation, 0f, 0f);
        }

        HandleJump();
    }

    void HandleJump() {
        if (gameObject.transform.position.y <= startingY) {
            canJump = true;
        }
        bool low = gameObject.transform.position.y < startingY + 15;
        if (Input.GetKey("up") && canJump && low) {
            gameObject.transform.Translate(0f, 50f * Time.deltaTime, 0f);
        } else {
            canJump = false;
            if (gameObject.transform.position.y > startingY) {
                gameObject.transform.Translate(0f, -50f * Time.deltaTime, 0f);
            }
        }
    }
}