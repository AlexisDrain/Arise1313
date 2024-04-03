using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerUse : MonoBehaviour
{
    [TextArea(2, 30)]
    public string notes;

    public UnityEvent onTriggerUse;
    [TextArea(2, 30)]
    public string useText = "Bed: Press E or left mouse to use.";

    public bool mustGetBreakfastFirst = false;
    public bool mustGetDinnerFirst = false;

    void Start() {

    }

    public void TriggerThisObject() {
        if(mustGetBreakfastFirst && GameManager.playerGotBreakfast == false) {
            GameManager.ShowMessage("You must get breakfast first.");
            return;
        } else if (mustGetDinnerFirst && GameManager.playerGotDinner == false) {
            GameManager.ShowMessage("You must get dinner first.");
            return;
        }
        onTriggerUse.Invoke();
    }
    /*
    public void ShowMessage(string messageToShow) {
        GameManager.ShowMessage(messageToShow);
    }
    */
}
