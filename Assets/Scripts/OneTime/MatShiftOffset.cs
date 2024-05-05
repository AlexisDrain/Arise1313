using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatShiftOffset : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float xOffset = 0f;
    float pos1 = 0f;
    float pos2 = 0.3f;
    float pos3 = 0.6f;
    float pos4 = 0.4f;
    void LateUpdate()
    {
        xOffset = (xOffset + Time.deltaTime * 2f) % 1.2f;
        if(xOffset < .3f && xOffset > 0f) {
            GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(pos1, 0f);
        } else if (xOffset < .6f && xOffset > .3f) {
            GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(pos2, 0f);
        } else if (xOffset < .9f) {
            GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(pos3, 0f);
        } else {
            GetComponent<MeshRenderer>().material.mainTextureOffset = new Vector2(pos4, 0f);
        }

    }
}
