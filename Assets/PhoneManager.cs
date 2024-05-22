using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{
    [Header("read only")]
    public bool _calledRitualDadDay1;
    public bool _calledRitualDadDay2;
    public bool _calledParentsDay;
    public bool _calledParentsNight;
    public bool _calledSiblingsDay;

    public void RestartPhoneStats()
    {
        _calledRitualDadDay1 = false;
        _calledRitualDadDay2 = false;
        _calledParentsDay = false;
        _calledParentsNight = false;
        _calledSiblingsDay = false;
    }

    // Update is called once per frame
    public void StoryCallCorrectPerson()
    {
        if(GameManager.knowsStepOne) {
            if(GameManager.currentDayOfWeek == DayOfWeek.DayOne && _calledRitualDadDay1 == false) {
                // _calledRitualDadDay1 = true; // set in StoryType
                GameManager.StartNovel("telephone_dialWeirdNumber");
                return;
            }
            else if (GameManager.currentDayOfWeek == DayOfWeek.DayTwo && _calledRitualDadDay2 == false) {
                // _calledRitualDadDay2 = true; // set in StoryType
                GameManager.StartNovel("telephone_dialWeirdNumber");
                return;
            }
        }

        if(GameManager.currentTimeOfDay == TimeOfDay.Midnight) {
            if (_calledParentsNight == false) {
                // _calledParentsNight = true; // set in StoryType
                GameManager.StartNovel("telephone_night");
                return;
            }
        } else if (GameManager.currentTimeOfDay != TimeOfDay.Midnight) {
            if(_calledParentsDay == false) {
                // _calledParentsDay = true; // set in StoryType
                GameManager.StartNovel("telephone_1");
                return;
            }
            if (_calledSiblingsDay == false) {
                //_calledSiblingsDay = true; // set in StoryType
                GameManager.StartNovel("telephone_2");
                return;
            }
        }
        
        GameManager.StartNovel("telephone_noone");
    }
}
