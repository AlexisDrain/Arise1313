using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSayonara : MonoBehaviour, IPointerExitHandler, IPointerMoveHandler {

    public Image sign;
    public bool giveHealth = true;
    public float waitUntilRemoveDefault = 1.5f;
    private float waitUntilRemoveCurrent = 1.5f;

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
        if (GameManager.sayonaraController.sayonaraTutorial == true) {
            GameManager.sayonaraController.sayonaraTutorial = false;
            GameManager.sayonaraController.sayonaraTutorialText.SetActive(false);
        }
        GetComponent<Button>().interactable = false;
        GetComponent<Button>().interactable = true; // hack so that the button looks unhighlighted after clicking

        if (giveHealth==true) {
            GameManager.sayonaraController.GiveHealth();
        } else if (giveHealth == false) {
            GameManager.sayonaraController.RemoveHealth();
        }

        Destroy(gameObject);
    }
    public void FixedUpdate() {

        if (GameManager.sayonaraController.sayonaraTutorial == true) {
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
