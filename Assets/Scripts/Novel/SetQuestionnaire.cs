using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetQuestionnaire : MonoBehaviour
{
    // this goes into each food UI toggle, and changed manually there.
    public Breakfast_main currentBreakfastMain = Breakfast_main.None;
    public Breakfast_bev currentBreakfastBev = Breakfast_bev.None;
    public Dinner_main currentDinnerMain = Dinner_main.None;
    public Dinner_side currentDinnerSide = Dinner_side.None;
    public Dinner_bev currentDinnerBev = Dinner_bev.None;

    public void ToggleValueChanged() {
        if (GetComponent<Toggle>().isOn) {
            GameManager.foodQuestionnaire.GetComponent<FoodQuestionare>().UsePencilOnce();
        }
    }
    public void DisableValue() {
        GetComponent<Toggle>().isOn = false;
    }
}
