using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum Breakfast_main {
    None,
    Oatmeal,
    ScrambledEggs,
    FrenchToast
};
public enum Breakfast_bev {
    None,
    AppleJuice,
    CranberryJuice,
    OrangeJuice,
    DecafCoffee
};
public enum Dinner_main {
    None,
    Pizza,
    Burger
};
public enum Dinner_side {
    None,
    Hummus,
    Rice,
    MacAndCheese
};
public enum Dinner_bev {
    None,
    AppleJuice,
    Milk,
    DecafCoffee
};


public class FoodQuestionare : MonoBehaviour
{

    public ToggleGroup currentBreakfastMainToggle;
    public ToggleGroup currentBreakfastBevToggle;
    public ToggleGroup currentDinnerMainToggle;
    public ToggleGroup currentDinnerSideToggle;
    public ToggleGroup currentDinnerBevToggle;

    [Header("Read Only")]
    public Breakfast_main _currentBreakfastMain = Breakfast_main.Oatmeal;
    public Breakfast_bev _currentBreakfastBev = Breakfast_bev.AppleJuice;
    public Dinner_main _currentDinnerMain = Dinner_main.Pizza;
    public Dinner_side _currentDinnerSide = Dinner_side.Hummus;
    public Dinner_bev _currentDinnerBev = Dinner_bev.AppleJuice;


    public void ChangeMeal()
    {
        _currentBreakfastMain = currentBreakfastMainToggle.ActiveToggles().First().GetComponent<SetQuestionnaire>().currentBreakfastMain;
        _currentBreakfastBev = currentBreakfastBevToggle.ActiveToggles().First().GetComponent<SetQuestionnaire>().currentBreakfastBev;
        _currentDinnerMain = currentDinnerMainToggle.ActiveToggles().First().GetComponent<SetQuestionnaire>().currentDinnerMain;
        _currentDinnerSide = currentDinnerSideToggle.ActiveToggles().First().GetComponent<SetQuestionnaire>().currentDinnerSide;
        _currentDinnerBev = currentDinnerBevToggle.ActiveToggles().First().GetComponent<SetQuestionnaire>().currentDinnerBev;
    }
}
