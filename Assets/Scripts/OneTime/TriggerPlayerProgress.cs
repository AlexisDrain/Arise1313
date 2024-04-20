using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerProgress : MonoBehaviour
{
    public bool trackTherapy = false;
    public bool trackGroup = false;
    public bool trackPrayer = false;

    public List<GameObject> progressObjects = new List<GameObject>();
    void Start()
    {
        GameManager.changeTimeOfDayEvent.AddListener(UpdateObjects);
    }

    // Update is called once per frame
    void UpdateObjects()
    {
        int progress = 0;
        if (trackTherapy) {
            progress = GameManager.numberOfTherapists;
        }
        if (trackGroup) {
            progress = GameManager.numberOfGroups;
        }
        if (trackPrayer) {
            progress = GameManager.numberOfPrayer;
        }

        // disable all progressObjects except the one with the same progress value
        for (int i = 0; i < progressObjects.Count; i++) {
            progressObjects[i].SetActive(false);
        }
        if(progress < progressObjects.Count) {
            progressObjects[progress].SetActive(true);
        }
    }
}
