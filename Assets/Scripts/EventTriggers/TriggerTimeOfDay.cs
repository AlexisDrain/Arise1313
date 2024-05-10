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

    [Header("Other")]
    public List<GameObject> objectOutro1;

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
        DisableAllMembers(objectMorning);
        DisableAllMembers(objectEvening);
        DisableAllMembers(objectMidnight);
        DisableAllMembers(objectMorning2);
        DisableAllMembers(objectEvening2);
        DisableAllMembers(objectMidnight2);
        DisableAllMembers(objectOutro1);

        // enabled last so that objects listed in more than morning list does not get removed
        if (GameManager.currentTimeOfDay == TimeOfDay.Morning) {
            
            if (GameManager.currentDayOfWeek == DayOfWeek.DayOne) {
                EnableAllMembers(objectMorning); 
            } else if (GameManager.currentDayOfWeek == DayOfWeek.DayTwo) {
                EnableAllMembers(objectMorning2);
            }
        } else if (GameManager.currentTimeOfDay == TimeOfDay.Evening) {
            if (GameManager.currentDayOfWeek == DayOfWeek.DayOne) {
                EnableAllMembers(objectEvening);
            } else if (GameManager.currentDayOfWeek == DayOfWeek.DayTwo) {
                EnableAllMembers(objectEvening2);
            }
        } else if (GameManager.currentTimeOfDay == TimeOfDay.Midnight) {

            if (GameManager.currentDayOfWeek == DayOfWeek.DayOne) {
                EnableAllMembers(objectMidnight);
            } else if (GameManager.currentDayOfWeek == DayOfWeek.DayTwo) {
                EnableAllMembers(objectMidnight2);
            }
        }

        if (GameManager.currentDayOfWeek == DayOfWeek.Outro) {
            EnableAllMembers(objectOutro1);
        }
    }
}
