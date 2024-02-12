using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkController : MonoBehaviour
{
    public Camera blinkCam;
    [Header("Read only")]
    public bool _eyesClosed = false;
    void Start()
    {

        GetComponent<Animator>().SetBool("EyesOpen", true);
        blinkCam.enabled = false;
    }

    private IEnumerator ActivateBlinkCam() {
        yield return new WaitForSeconds(0.2f);
        blinkCam.enabled = true;
        _eyesClosed = true;
    }
    private IEnumerator DeactivateBlinkCam() {
        yield return new WaitForSeconds(0.1f);
        blinkCam.enabled = false;
        _eyesClosed = false;
    }
    void LateUpdate()
    {
        
        if(Input.GetButtonDown("Blink")) {
            GetComponent<Animator>().SetBool("EyesOpen", false);
            StartCoroutine("ActivateBlinkCam");
            StopCoroutine("DeactivateBlinkCam");
        }
        if (Input.GetButtonUp("Blink")
            && Input.GetButton("Blink") == false) { // the second conditional is because there are 2 blink buttons and they can interfere with each other
            GetComponent<Animator>().SetBool("EyesOpen", true);
            StopCoroutine("ActivateBlinkCam");
            StartCoroutine("DeactivateBlinkCam");
        }    }

}
