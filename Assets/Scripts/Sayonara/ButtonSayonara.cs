using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSayonara : MonoBehaviour, IPointerExitHandler, IPointerMoveHandler {

    [HideInInspector]
    public SayonaraController currentSayonaraController;

    public Image sign;
    public bool giveHealth = true;
    public float waitUntilRemoveDefault = 1.5f;

    private float waitUntilRemoveCurrent = 1.5f;

    public void SetTimeToRemove(float newTime) {
        waitUntilRemoveDefault = newTime;
        waitUntilRemoveCurrent = newTime;
    }
    void OnEnable()
    {
        waitUntilRemoveCurrent = waitUntilRemoveDefault;
        if(GameManager.sayonaraColorBlind == true) {
            sign.enabled = true;
        } else {
            sign.enabled = false;
        }
    }

    public void OnPointerMove(PointerEventData pointerEventData) {
        sign.enabled = true;
    }
    public void OnPointerExit(PointerEventData pointerEventData) {

        if (GameManager.sayonaraColorBlind == true) {
            sign.enabled = true;
        } else {
            sign.enabled = false;
        }

    }

    public void ClickSayonara() {
        if (currentSayonaraController.sayonaraTutorial == true) {
            currentSayonaraController.sayonaraTutorial = false;
            currentSayonaraController.sayonaraTutorialText.SetActive(false);
        }
        GetComponent<Button>().interactable = false;
        GetComponent<Button>().interactable = true; // hack so that the button looks unhighlighted after clicking

        if (giveHealth==true) {
            currentSayonaraController.GiveHealth();
        } else if (giveHealth == false) {
            currentSayonaraController.RemoveHealth();
        }

        Destroy(gameObject);
    }
    public void FixedUpdate() {

        if (currentSayonaraController.sayonaraTutorial == true) {
            return;
        }

        if (waitUntilRemoveCurrent > 0f) {
            waitUntilRemoveCurrent -= Time.deltaTime;
        } else {
            waitUntilRemoveCurrent = waitUntilRemoveDefault;

            Destroy(gameObject);
        }
    }

}
