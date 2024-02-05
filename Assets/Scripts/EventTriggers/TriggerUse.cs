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

    void Start() {

    }

    public void TriggerThisObject() {
        onTriggerUse.Invoke();
    }

}
