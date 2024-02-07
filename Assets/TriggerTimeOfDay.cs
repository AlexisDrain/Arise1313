using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class TriggerTimeOfDay : MonoBehaviour
{
    public GameObject objectMorning;
    public GameObject objectEvening;
    public GameObject objectMidnight;

    void Start()
    {
        GameManager.changeTimeOfDayEvent.AddListener(UpdateTimeOfDay);
        UpdateTimeOfDay();
    }


    void UpdateTimeOfDay()
    {
        if (GameManager.currentTimeOfDay == TimeOfDay.Morning) {
            
            objectMorning.SetActive(true);
            objectEvening.SetActive(false);
            objectMidnight.SetActive(false);
        } else if (GameManager.currentTimeOfDay == TimeOfDay.Evening) {

            objectMorning.SetActive(false);
            objectEvening.SetActive(true);
            objectMidnight.SetActive(false);
        } else if (GameManager.currentTimeOfDay == TimeOfDay.Midnight) {

            objectMorning.SetActive(false);
            objectEvening.SetActive(false);
            objectMidnight.SetActive(true);
        }
    }
}
