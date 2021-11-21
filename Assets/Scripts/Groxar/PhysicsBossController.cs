using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsBossController : MonoBehaviour {

    public GameObject debriParticles;
    public GameObject player;

    private GameObject gameCamera;

    private bool shaking;
    private float shakeTime, cooldown;
    private Vector3 shakeVector;

    // Start is called before the first frame update
    void Start() {
        shakeVector = new Vector3(100f, 0f, 0f);
        gameCamera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update() {
        float delta = Time.deltaTime;
        Vector2 force = new Vector2(750f * delta, 0f);

        HandleMovement(force);
        HandleAttack();
        HandleShaking(delta);

        cooldown = Mathf.Max(cooldown - delta, 0f);
    }

    private void HandleMovement(Vector2 force) {
        if (shaking) {
            return;
        }
        if (player.transform.position.x < transform.position.x) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(-force);
        }
        if (player.transform.position.x > transform.position.x) {
            gameObject.GetComponent<Rigidbody2D>().AddForce(force);
        }
    }
    private void HandleAttack() {
        if (cooldown != 0f) {
            return;
        }
        float playerX = player.transform.position.x;
        float bossX = transform.position.x;
        if (playerX < bossX + 10f && playerX > bossX - 10f) {
            gameObject.GetComponent<Animator>().SetBool("attacking", true);
            cooldown = 3f;
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

    public void StartShaking() {
        shaking = true;
    }

    public void StopShaking() {
        shaking = false;
    }

    public void SpawnParticles() {
        Vector3 position = transform.position;
        position.y -= GetComponent<SpriteRenderer>().size.y / 2;
        GameObject particles = Instantiate(debriParticles, position, new Quaternion());
        particles.transform.parent = null;

        gameCamera.GetComponent<CameraShake>().Shake();
    }

    public void SetPlayer(GameObject player) {
        this.player = player;
    }
}