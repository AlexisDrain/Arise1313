using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenCloseEyes : MonoBehaviour
{
    private bool countDown = false;
    private float blinkTimeTillDeactivate = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OverrideEnable() {
        blinkTimeTillDeactivate = 2.5f;
        gameObject.SetActive(true);
    }
    private void FixedUpdate() {
        if(countDown == true) {
            blinkTimeTillDeactivate -= Time.deltaTime;
        }
        if(blinkTimeTillDeactivate < 0f) {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetButtonDown("Blink")) {
            countDown = true;
        }
        if (Input.GetButtonUp("Blink")
            && Input.GetButton("Blink") == false) { // the second conditional is because there are 2 blink buttons and they can interfere with each other
            countDown = false;
        }
    }
}
