using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShake : MonoBehaviour
{

    public Vector2 randomRange = new Vector2(-4f, 4f);
    public float shakeSpeedDefault = 0.01f;
    public bool startShaking = false;

    private bool shakeButtonState;
    private Vector3 originalPos;
    private float shakeSpeedCurrent = 0f;
    void Start()
    {
        UpdateNewLocation(transform.localPosition);

        if(startShaking == true) {
            ShakeButtonState(true);
        }
    }
    public void ShakeButtonState(bool newShakeState) {
        shakeButtonState = newShakeState;
    }
    public void UpdateNewLocation(Vector3 newLocation) {
        originalPos = transform.localPosition;
    }

    void LateUpdate()
    {
        if(shakeButtonState == true) {

            if(shakeSpeedCurrent > 0f) {
                shakeSpeedCurrent -= Time.deltaTime;
                return;
            } else {
                shakeSpeedCurrent = shakeSpeedDefault;
                
                transform.localPosition = new Vector3(originalPos.x + Random.Range(randomRange.x, randomRange.y),
                                                originalPos.y + Random.Range(randomRange.x, randomRange.y),
                                                originalPos.z);
            }

        } else {
            transform.localPosition = originalPos;
        }
    }
}
