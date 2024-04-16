using Krivodeling.UI.Effects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkController : MonoBehaviour
{

    // Note: bluring the camera when not blinking is disabled because it's annoying and performs badly on WebGL.
    // Otherwise, you can uncomment the lines

    /*
    public UIBlur blurImage;
    public GameObject blurMessage;
    public float defaultTimeToBlink = 7f;
    private float currentTimeToBlink = 7f;
    */

    public Camera blinkCam;
    [Header("Read only")]
    public bool _eyesClosed = false;
    void Start()
    {

        GetComponent<Animator>().SetBool("EyesOpen", true);
        blinkCam.enabled = false;

        // game blur mechanic
        /*
        currentTimeToBlink = defaultTimeToBlink;
        blurImage.Intensity = 0f;
        blurImage.Multiplier = 0f;
        */
    }

    private IEnumerator ActivateBlinkCam() {
        yield return new WaitForSeconds(0.2f);
        blinkCam.enabled = true;
        _eyesClosed = true;
        GameManager.EyesClosedEvent.Invoke();
    }
    private IEnumerator DeactivateBlinkCam() {
        yield return new WaitForSeconds(0.1f);
        blinkCam.enabled = false;
        _eyesClosed = false;
        GameManager.EyesOpenEvent.Invoke();
    }
    /*
     * Game blur mechanic
     * 
    private void FixedUpdate() {

        if (GameManager.playerInBed || GameManager.playerInNovelOrSayonara || GameManager.playerInFoodQuestionnaire || GameManager.playerInTabMenu) {
            return;
        }
        if(currentTimeToBlink > 0f) {
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
    */
    void LateUpdate()
    {

        /*
        if (Input.GetButton("Blink")) {
            currentTimeToBlink = defaultTimeToBlink;
        }
        */


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
