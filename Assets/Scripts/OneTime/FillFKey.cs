using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillFKey : MonoBehaviour
{
    public Image keyImage;
    public Image keyYellowImage;
    public Image holdTextImage;
    public Image sleepFullscreenSolidBlack;
    private float blinkOutOfOne = 0f;
    void Start()
    {

    }


    void LateUpdate()
    {
        if(GameManager.playerInBed == false) {
            keyImage.enabled = false;
            keyYellowImage.enabled = false;
            holdTextImage.enabled = false;
            sleepFullscreenSolidBlack.enabled = false;
            return;
        }
        keyImage.enabled = true;
        keyYellowImage.enabled = true;
        holdTextImage.enabled = true;
        sleepFullscreenSolidBlack.enabled = true;

        if (GameManager.blinkController._eyesClosed && GameManager.playerInBed == true) {
            blinkOutOfOne += Time.deltaTime * 0.2f;
        } else {
            blinkOutOfOne -= Time.deltaTime * 1f;
        }

        blinkOutOfOne = Mathf.Clamp01(blinkOutOfOne);
        keyYellowImage.fillAmount = blinkOutOfOne;
        if(blinkOutOfOne > 0f) {
            sleepFullscreenSolidBlack.enabled = true;
            sleepFullscreenSolidBlack.color = new Color(0f, 0f, 0f, blinkOutOfOne);
        } else {
            sleepFullscreenSolidBlack.enabled = false;
        }

        if(blinkOutOfOne > 0.99f) {
            blinkOutOfOne = 0f;
            GameManager.PlayerLeaveBed();
            //keyImage.enabled = false;
            //keyYellowImage.enabled = false;
            //holdTextImage.enabled = false;
            //fullscreenSolidBlack.enabled = false;
            //fullscreenSolidBlack.color = new Color(0f, 0f, 0f, 0f);
        }
    }
}
