using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EnableVisualIfEyesClosed : MonoBehaviour
{

    void Start()
    {
        GameManager.EyesClosedEvent.AddListener(EnableVisual);
        GameManager.EyesOpenEvent.AddListener(DisableVisual);
        DisableVisual();
    }


    void DisableVisual()
    {
        if(GetComponent<Image>()) {
            GetComponent<Image>().enabled = false;
        }
    }
    void EnableVisual() {
        if (GetComponent<Image>()) {
            GetComponent<Image>().enabled = true;
        }
    }
}
