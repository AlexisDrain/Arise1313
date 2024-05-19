using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleColorBlind : MonoBehaviour
{
    public GameObject labelOff;
    public GameObject labelOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ToggleMode(bool newState) {
        if (newState == false) {
            labelOff.SetActive(true);
            labelOn.SetActive(false);
            GameManager.sayonaraColorBlind = false;
        } else if (newState == true) {
            labelOff.SetActive(false);
            labelOn.SetActive(true);
            GameManager.sayonaraColorBlind = true;
        }
    }
}
