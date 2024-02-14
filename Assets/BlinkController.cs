using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkController : MonoBehaviour
{
    public Camera blinkCam;
    public UIBlur blurImage;
    public GameObject blurMessage;
    public float defaultTimeToBlink = 7f;
    private float currentTimeToBlink = 7f;
    [Header("Read only")]
    public bool _eyesClosed = false;
    void Start()
    {

        GetComponent<Animator>().SetBool("EyesOpen", true);
        blinkCam.enabled = false;

        currentTimeToBlink = defaultTimeToBlink;
        blurImage.Intensity = 0f;
        blurImage.Multiplier = 0f;
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
    private void FixedUpdate() {
        if(currentTimeToBlink > 0f || GameManager.playerInBed) {
            currentTimeToBlink -= Time.deltaTime;
            currentTimeToBlink = Mathf.Clamp(currentTimeToBlink, -1f, defaultTimeToBlink);
            blurImage.Intensity = Mathf.Lerp(blurImage.Intensity, 0f, 0.1f);
            blurImage.Multiplier = Mathf.Lerp(blurImage.Intensity, 0f, 0.1f);
        }
        else if(currentTimeToBlink <= 0f) {
            blurImage.Intensity = Mathf.Lerp(blurImage.Intensity, 2f, 0.005f);
            blurImage.Multiplier = Mathf.Lerp(blurImage.Intensity, 2f, 0.005f);
        }

        if(blurImage.Intensity >= 1.3f) {
            if(blurMessage.activeSelf == false) {
                blurMessage.SetActive(true);
            }
        } else {
            if (blurMessage.activeSelf == true) {
                blurMessage.SetActive(false);
            }
        }
    }
    void LateUpdate()
    {

        if (Input.GetButton("Blink")) {
            currentTimeToBlink = defaultTimeToBlink;
        }

        if (Input.GetButtonDown("Blink")) {
            GetComponent<Animator>().SetBool("EyesOpen", false);
            StartCoroutine("ActivateBlinkCam");
            StopCoroutine("DeactivateBlinkCam");
        }
        if (Input.GetButtonUp("Blink")
            && Input.GetButton("Blink") == false) { // the second conditional is because there are 2 blink buttons and they can interfere with each other
            GetComponent<Animator>().SetBool("EyesOpen", true);
            StopCoroutine("ActivateBlinkCam");
            StartCoroutine("DeactivateBlinkCam");
        }    
    }

}
