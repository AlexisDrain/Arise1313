using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnClick : MonoBehaviour
{
    public bool deactivateOnStart = false;
    public bool deactivateAfterEndOfClick = false;
    public bool deactivateThisComponentAtEnd = false;
    void Start()
    {
        if(deactivateOnStart) {
            gameObject.SetActive(false);
        }
    }

    private void Deactivate() {
        if(deactivateThisComponentAtEnd) {
            GetComponent<DeactivateOnClick>().enabled = false;
        }
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(deactivateAfterEndOfClick) {
            if (Input.GetMouseButtonUp(0)) {
                StartCoroutine("LateDeactivateCountdown");
            }
        } else {
            if (Input.GetMouseButtonDown(0)) {
                Deactivate();
            }

        }
    }
    IEnumerator LateDeactivateCountdown() {
        yield return new WaitForSecondsRealtime(0.1f);
        Deactivate();
    }
}
