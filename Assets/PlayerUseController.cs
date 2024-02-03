using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseController : MonoBehaviour
{
    public float holdingBlink;
    public TriggerUse objectHighlighted;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Usable")) {
            objectHighlighted = other.GetComponent<TriggerUse>();
            GameManager.displayUseText.Highlight(objectHighlighted.useText);
        }
    }
    private void OnTriggerExit(Collider other) {
        objectHighlighted = null;
        GameManager.displayUseText.HideDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        // use button
        if(objectHighlighted != null && Input.GetButtonDown("Use")) {
            objectHighlighted.TriggerThisObject();
        }
        /*
        RaycastHit hit;
        Physics.Linecast(transform.position, transform.position + transform.forward * 2f, out hit);

        // show
        if(hit.collider && hit.collider.CompareTag("Usable")) {
            objectHighlighted = hit.collider.GetComponent<TriggerUse>();
            GameManager.displayUseText.Highlight(objectHighlighted.useText);
        }
        // hide
        if(objectHighlighted != null && (hit.collider == null || hit.collider.GetComponent<TriggerUse>() != objectHighlighted)) {
            GameManager.displayUseText.HideDisplay();
        }
        */

    }
}
