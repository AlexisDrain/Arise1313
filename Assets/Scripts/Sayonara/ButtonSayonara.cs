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
    private bool mouseIsHovering = false;

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
        mouseIsHovering = true;
        sign.enabled = true;
    }
    public void OnPointerExit(PointerEventData pointerEventData) {
        waitUntilRemoveCurrent += 0.2f; // a little coyote time. if the player hovers over the mouse a little and misses, this gives some time to recover.
        mouseIsHovering = false;

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
            // time is over. cannot kill button when mouse is hovering over it.
            if (mouseIsHovering == false) {
                waitUntilRemoveCurrent = waitUntilRemoveDefault;

                Destroy(gameObject);
            }
        }
    }

}
