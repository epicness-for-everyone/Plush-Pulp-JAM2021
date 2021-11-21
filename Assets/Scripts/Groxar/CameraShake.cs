using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    // How long the object should shake for.
    public float shakeDuration = 1f;

    private float internalDuration;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;

    private bool shakeEnabled;

    Vector3 originalPos;

    void OnEnable() {
        originalPos = transform.localPosition;
    }

    void Update() {
        if (!shakeEnabled) {
            return;
        }
        if (internalDuration > 0) {
            transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            internalDuration -= Time.deltaTime;
        } else {
            internalDuration = 0f;
            transform.localPosition = originalPos;
            shakeEnabled = false;
        }
    }

    public void Shake() {
        internalDuration = shakeDuration;
        shakeEnabled = true;
    }
}