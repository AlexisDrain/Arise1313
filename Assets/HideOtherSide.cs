using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HideOtherSide : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    private TextMeshProUGUI myText;
    void Start()
    {
        if(GetComponent<SpriteRenderer>()) {
            mySpriteRenderer = GetComponent<SpriteRenderer>();
        }
        if (GetComponent<TextMeshProUGUI>()) {
            myText = GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 relativePos = GameManager.mainCamera.transform.position - transform.position;
        bool inFront = Vector3.Dot(transform.forward, relativePos) > 0.0f;

        if(mySpriteRenderer) {
            if (inFront && mySpriteRenderer.enabled == false) {
                mySpriteRenderer.enabled = true;
            } else if (inFront == false && mySpriteRenderer.enabled == true) {
                mySpriteRenderer.enabled = false;
            }
        }
        if(myText) {
            if (inFront && myText.enabled == false) {
                myText.enabled = true;
            } else if (inFront == false && myText.enabled == true) {
                myText.enabled = false;
            }
        }

    }
}
