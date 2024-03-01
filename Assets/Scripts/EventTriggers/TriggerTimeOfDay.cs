using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class TriggerTimeOfDay : MonoBehaviour
{
    [Header("Day3")]
    public List<GameObject> objectMorning;
    public List<GameObject> objectEvening;
    public List<GameObject> objectMidnight;

    void Start()
    {
        GameManager.changeTimeOfDayEvent.AddListener(UpdateTimeOfDay);
        UpdateTimeOfDay();
    }

    private void EnableAllMembers(List<GameObject> members) {
        for (int i = 0; i < members.Count; i++) {
            members[i].SetActive(true);
        }
    }
    public void DisableAllMembers(List<GameObject> members) {
        for (int i = 0; i < members.Count; i++) {
            members[i].SetActive(false);
        }
    }

    void UpdateTimeOfDay()
    {
        if (GameManager.currentTimeOfDay == TimeOfDay.Morning) {
            
            EnableAllMembers(objectMorning);
            DisableAllMembers(objectEvening);
            DisableAllMembers(objectMidnight);
        } else if (GameManager.currentTimeOfDay == TimeOfDay.Evening) {

            DisableAllMembers(objectMorning);
            EnableAllMembers(objectEvening);
            DisableAllMembers(objectMidnight);
        } else if (GameManager.currentTimeOfDay == TimeOfDay.Midnight) {

            DisableAllMembers(objectMorning);
            DisableAllMembers(objectEvening);
            EnableAllMembers(objectMidnight);
        }
    }
}
