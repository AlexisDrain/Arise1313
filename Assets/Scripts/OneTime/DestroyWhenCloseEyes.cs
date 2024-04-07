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
    private void FixedUpdate() {
        if(countDown == true) {
            blinkTimeTillDeactivate -= Time.deltaTime;
        }
        if(blinkTimeTillDeactivate < 0f) {
            Destroy(gameObject);
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
