using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerFuncTimeOfDay : MonoBehaviour {


    public UnityEvent onEveryTimeChange;
    [Header("Day1")]
    public UnityEvent funcMorning;
    public UnityEvent funcEvening;
    public UnityEvent funcMidnight;

    [Header("Day2")]
    public UnityEvent funcMorning2;
    public UnityEvent funcEvening2;
    public UnityEvent funcMidnight2;

    [Header("Other")]
    public UnityEvent funcOutro1;
    void Start()
    {
        GameManager.changeTimeOfDayEvent.AddListener(OnTimeChange);
    }

    // Update is called once per frame
    void OnTimeChange()
    {
        onEveryTimeChange.Invoke();
        if (GameManager.currentTimeOfDay == TimeOfDay.Morning) {

            if (GameManager.currentDayOfWeek == DayOfWeek.DayOne) {
                funcMorning.Invoke();
            } else if (GameManager.currentDayOfWeek == DayOfWeek.DayTwo) {
                funcMorning2.Invoke();
            }
        } else if (GameManager.currentTimeOfDay == TimeOfDay.Evening) {
            if (GameManager.currentDayOfWeek == DayOfWeek.DayOne) {
                funcEvening.Invoke();
            } else if (GameManager.currentDayOfWeek == DayOfWeek.DayTwo) {
                funcEvening2.Invoke();
            }
        } else if (GameManager.currentTimeOfDay == TimeOfDay.Midnight) {

            if (GameManager.currentDayOfWeek == DayOfWeek.DayOne) {
                funcMidnight.Invoke();
            } else if (GameManager.currentDayOfWeek == DayOfWeek.DayTwo) {
                funcMidnight2.Invoke();
            }
        }
    }
}
