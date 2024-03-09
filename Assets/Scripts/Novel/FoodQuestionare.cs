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

    [Header("Set once")]
    public ToggleGroup currentBreakfastMainToggle;
    public ToggleGroup currentBreakfastBevToggle;
    public ToggleGroup currentDinnerMainToggle;
    public ToggleGroup currentDinnerSideToggle;
    public ToggleGroup currentDinnerBevToggle;

    [Space]
    public GameObject breakfastEggs;

    [Header("Read Only")]
    public Breakfast_main _currentBreakfastMain = Breakfast_main.Oatmeal;
    public Breakfast_bev _currentBreakfastBev = Breakfast_bev.AppleJuice;
    public Dinner_main _currentDinnerMain = Dinner_main.Pizza;
    public Dinner_side _currentDinnerSide = Dinner_side.Hummus;
    public Dinner_bev _currentDinnerBev = Dinner_bev.AppleJuice;

    public void PlayerGiveMealBreakfast() {
        print("give breakfast");

        // todo
        print("TODO: remove breakfast eggs, add all other breakfast items inside the if statement");
        GameObject.Instantiate(breakfastEggs, GameManager.inventory.transform);

        if (_currentBreakfastMain == Breakfast_main.ScrambledEggs) {
            GameObject.Instantiate(breakfastEggs, GameManager.inventory.transform);
        }
    }
    public void PlayerGiveMealDinner() {
        print("give dinner");
    }

    public void ChangeMeal()
    {
        print("give meals");

        if(currentBreakfastMainToggle.ActiveToggles().Count() > 0) {
            _currentBreakfastMain = currentBreakfastMainToggle.ActiveToggles().First().GetComponent<SetQuestionnaire>().currentBreakfastMain;
        }
        if (currentBreakfastBevToggle.ActiveToggles().Count() > 0) {
            _currentBreakfastBev = currentBreakfastBevToggle.ActiveToggles().First().GetComponent<SetQuestionnaire>().currentBreakfastBev;
        }
        if (currentDinnerMainToggle.ActiveToggles().Count() > 0) {
            _currentDinnerMain = currentDinnerMainToggle.ActiveToggles().First().GetComponent<SetQuestionnaire>().currentDinnerMain;
        }
        if (currentDinnerSideToggle.ActiveToggles().Count() > 0) {
            _currentDinnerSide = currentDinnerSideToggle.ActiveToggles().First().GetComponent<SetQuestionnaire>().currentDinnerSide;
        }
        if (currentDinnerBevToggle.ActiveToggles().Count() > 0) {
            _currentDinnerBev = currentDinnerBevToggle.ActiveToggles().First().GetComponent<SetQuestionnaire>().currentDinnerBev;
        }
        GameManager.StopFoodQuestionnaire();
    }
}
