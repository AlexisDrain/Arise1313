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

    public bool mustGetFoodFirst = false;

    void Start() {

    }

    public void TriggerThisObject() {
        if(mustGetFoodFirst) {
            if (GameManager.currentTimeOfDay == TimeOfDay.Morning && GameManager.playerGotBreakfast == false) {
                GameManager.ShowMessage("You must get breakfast first.");
                return;
            } else if (GameManager.currentTimeOfDay == TimeOfDay.Evening && GameManager.playerGotDinner == false) {
                GameManager.ShowMessage("You must get dinner first.");
                return;
            }
        }

        onTriggerUse.Invoke();
    }
    /*
    public void ShowMessage(string messageToShow) {
        GameManager.ShowMessage(messageToShow);
    }
    */
}
