using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResetMainMenu : MonoBehaviour
{
    public UnityEvent onResetMenu;
    public void InvokeMainMenu()
    {
        onResetMenu.Invoke();
    }

}
