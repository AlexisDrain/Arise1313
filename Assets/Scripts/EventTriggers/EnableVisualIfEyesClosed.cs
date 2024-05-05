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
        if (flipIfBehind == false) {
            // transform.localScale = new Vector3(1f, 1f, 1f);
            return;
        }

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
            return;
        }
        if(GetComponent<TextMeshProUGUI>()) {
            GetComponent<TextMeshProUGUI>().enabled = false;
            return;
        }
        if (GetComponent<MeshRenderer>()) {
            GetComponent<MeshRenderer>().enabled = false;
            return;
        }
    }
    void EnableVisual() {
        if (GetComponent<Image>()) {
            GetComponent<Image>().enabled = true;
            return;
        }
        if (GetComponent<TextMeshProUGUI>()) {
            GetComponent<TextMeshProUGUI>().enabled = true;
            return;
        }
        if (GetComponent<MeshRenderer>()) {
            GetComponent<MeshRenderer>().enabled = true;
            return;
        }
    }
}
