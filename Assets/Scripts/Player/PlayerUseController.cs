using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseController : MonoBehaviour
{

    [Header("Read only")]
    public TriggerUse _objectHighlighted;

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Usable")) {
            _objectHighlighted = other.GetComponent<TriggerUse>();
            GameManager.displayUseText.Highlight(_objectHighlighted.useText);
        }
    }
    private void OnTriggerExit(Collider other) {
        _objectHighlighted = null;
        GameManager.displayUseText.HideDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        // use button
        if (_objectHighlighted != null && Input.GetButtonDown("Use")) {
            _objectHighlighted.TriggerThisObject();
        }
        if (GameManager.playerInBed || GameManager.playerInNovelOrSayonara) {
            _objectHighlighted = null;
            GameManager.displayUseText.HideDisplay();
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
