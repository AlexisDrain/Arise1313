using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

public class TriggerTimeOfDay : MonoBehaviour
{
    [Header("Day1")]
    public List<GameObject> objectMorning;
    public List<GameObject> objectEvening;
    public List<GameObject> objectMidnight;

    [Header("Day2")]
    public List<GameObject> objectMorning2;
    public List<GameObject> objectEvening2;
    public List<GameObject> objectMidnight2;

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
            
            if (GameManager.currentDayOfWeek == DayOfWeek.DayOne) {
                DisableAllMembers(objectEvening);
                DisableAllMembers(objectMidnight);
                EnableAllMembers(objectMorning); // enabled last so that objects listed in more than morning list does not get removed
            } else if (GameManager.currentDayOfWeek == DayOfWeek.DayTwo) {
                DisableAllMembers(objectEvening2);
                DisableAllMembers(objectMidnight2);
                EnableAllMembers(objectMorning2); // enabled last so that objects listed in more than morning list does not get removed.
            }
        } else if (GameManager.currentTimeOfDay == TimeOfDay.Evening) {
            if (GameManager.currentDayOfWeek == DayOfWeek.DayOne) {
                DisableAllMembers(objectMidnight);
                DisableAllMembers(objectMorning);
                EnableAllMembers(objectEvening); // enabled last so that objects listed in more than morning list does not get removed.
            } else if (GameManager.currentDayOfWeek == DayOfWeek.DayTwo) {
                DisableAllMembers(objectMidnight2);
                DisableAllMembers(objectMorning2);
                EnableAllMembers(objectEvening2); // enabled last so that objects listed in more than morning list does not get removed.
            }
        } else if (GameManager.currentTimeOfDay == TimeOfDay.Midnight) {

            if (GameManager.currentDayOfWeek == DayOfWeek.DayOne) {
                DisableAllMembers(objectEvening);
                DisableAllMembers(objectMorning); 
                EnableAllMembers(objectMidnight); // enabled last so that objects listed in more than morning list does not get removed.
            } else if (GameManager.currentDayOfWeek == DayOfWeek.DayTwo) {
                DisableAllMembers(objectEvening2);
                DisableAllMembers(objectMorning2);
                EnableAllMembers(objectMidnight2); // enabled last so that objects listed in more than morning list does not get removed.
            }
        }
    }
}
