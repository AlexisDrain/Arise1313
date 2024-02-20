using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSayonara : MonoBehaviour, IPointerExitHandler, IPointerMoveHandler {

    public SayonaraController sayonaraController;
    public Image sign;
    public bool giveHealth = true;
    public float waitUntilRemoveDefault = 1.5f;
    private float waitUntilRemoveCurrent = 1.5f;

    void OnEnable()
    {
        waitUntilRemoveCurrent = waitUntilRemoveDefault;
        sign.enabled = false;
    }

    public void OnPointerMove(PointerEventData pointerEventData) {
        sign.enabled = true;
    }
    public void OnPointerExit(PointerEventData pointerEventData) {
        sign.enabled = false;
    }

    public void ClickSayonara() {
        GetComponent<Button>().interactable = false;
        GetComponent<Button>().interactable = true; // hack so that the button looks unhighlighted after clicking

        if (giveHealth==true) {
            sayonaraController.GiveHealth();
        } else if (giveHealth == false) {
            sayonaraController.RemoveHealth();
        }

        gameObject.SetActive(false);
        sign.enabled = false;
    }
    public void FixedUpdate() {
        if (waitUntilRemoveCurrent > 0f) {
            waitUntilRemoveCurrent -= Time.deltaTime;
        } else {
            waitUntilRemoveCurrent = waitUntilRemoveDefault;

            gameObject.SetActive(false);
            sign.enabled = false;
        }
    }

}
