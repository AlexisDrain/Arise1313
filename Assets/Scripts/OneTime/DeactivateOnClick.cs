using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0)) {
            gameObject.SetActive(false);
        }
    }
}
