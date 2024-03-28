using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class EnableVisualIfEyesClosed : MonoBehaviour
{
    public bool flipIfBehind = true;
    void Start()
    {
        GameManager.EyesClosedEvent.AddListener(EnableVisual);
        GameManager.EyesOpenEvent.AddListener(DisableVisual);
        DisableVisual();
    }

    private void LateUpdate() {
        Vector3 relativePos = GameManager.mainCamera.transform.position - transform.position;
        bool inFront = Vector3.Dot(transform.forward, relativePos) > 0.0f;

        if (inFront && transform.localScale.x == 1) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (inFront == false && transform.localScale.x == -1) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
    void DisableVisual()
    {
        
        if(GetComponent<Image>()) {
            GetComponent<Image>().enabled = false;
        }
        if(GetComponent<TextMeshProUGUI>()) {
            GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }
    void EnableVisual() {
        if (GetComponent<Image>()) {
            GetComponent<Image>().enabled = true;
        }
        if (GetComponent<TextMeshProUGUI>()) {
            GetComponent<TextMeshProUGUI>().enabled = true;
        }
    }
}
