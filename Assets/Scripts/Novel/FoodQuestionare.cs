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
    public GameObject dullPencilText;

    [Space]
    public GameObject item_Oatmeal;
    public GameObject item_ScrambledEggs;
    public GameObject item_FrenchToast;
    public GameObject item_AppleJuice;
    public GameObject item_CranberryJuice;
    public GameObject item_OrangeJuice;
    public GameObject item_DecafCoffee;
    public GameObject item_Pizza;
    public GameObject item_Burger;
    public GameObject item_Hummus;
    public GameObject item_Rice;
    public GameObject item_MacAndCheese;
    public GameObject item_Milk;

    [Header("Read Only")]
    public Breakfast_main _currentBreakfastMain = Breakfast_main.Oatmeal;
    public Breakfast_bev _currentBreakfastBev = Breakfast_bev.AppleJuice;
    public Dinner_main _currentDinnerMain = Dinner_main.Pizza;
    public Dinner_side _currentDinnerSide = Dinner_side.Hummus;
    public Dinner_bev _currentDinnerBev = Dinner_bev.AppleJuice;
    public GameObject invItemPencilDull;
    public GameObject invItemPencilSharp;

    private int dullPencilCountdown = 5;

    public void UsePencilOnce() {
        dullPencilCountdown -= 1;
        if(dullPencilCountdown == 0) {
            GameManager.ShowMessage("Your new pencil became dull because you used it too much.");
        }
    }
    public void OnEnable() {
        dullPencilCountdown = 5;
        dullPencilText.SetActive(false);
    }

    public void PlayerGiveMealBreakfast() {
        GameManager.playerGotBreakfast = true; // set to false in player wake up

        // todo
        /*
         *     Oatmeal,
                ScrambledEggs,
                FrenchToast
         */
        if (_currentBreakfastMain == Breakfast_main.Oatmeal) {
            GameObject.Instantiate(item_Oatmeal, GameManager.inventory.transform);
        }
        if (_currentBreakfastMain == Breakfast_main.ScrambledEggs) {
            GameObject.Instantiate(item_ScrambledEggs, GameManager.inventory.transform);
        } 
        if (_currentBreakfastMain == Breakfast_main.FrenchToast) {
            GameObject.Instantiate(item_FrenchToast, GameManager.inventory.transform);
        }
        /*
 *         AppleJuice,
        CranberryJuice,
        OrangeJuice,
        DecafCoffee */
        if (_currentBreakfastBev == Breakfast_bev.AppleJuice) {
            GameObject.Instantiate(item_AppleJuice, GameManager.inventory.transform);
        }
        if (_currentBreakfastBev == Breakfast_bev.CranberryJuice) {
            GameObject.Instantiate(item_CranberryJuice, GameManager.inventory.transform);
        }
        if (_currentBreakfastBev == Breakfast_bev.OrangeJuice) {
            GameObject.Instantiate(item_OrangeJuice, GameManager.inventory.transform);
        }
        if (_currentBreakfastBev == Breakfast_bev.DecafCoffee) {
            GameObject.Instantiate(item_DecafCoffee, GameManager.inventory.transform);
        }

        GameManager.ShowMessage("You got breakfast. Press TAB to view & eat it.");

        // remove tutorial:
        GameManager.tutorialControls.SetActive(false);
    }
    public void PlayerGiveMealDinner() {
        GameManager.playerGotDinner = true; // set to false in player wake up

        /*
        * 
        Pizza,
        Burger
        */
        if (_currentDinnerMain == Dinner_main.Pizza) {
            GameObject.Instantiate(item_Pizza, GameManager.inventory.transform);
        }
        if (_currentDinnerMain == Dinner_main.Burger) {
            GameObject.Instantiate(item_Burger, GameManager.inventory.transform);
        }

        /*
            Hummus,
            Rice,
            MacAndCheese
        */
        if (_currentDinnerSide == Dinner_side.Hummus) {
            GameObject.Instantiate(item_Hummus, GameManager.inventory.transform);
        }
        if (_currentDinnerSide == Dinner_side.Rice) {
            GameObject.Instantiate(item_Rice, GameManager.inventory.transform);
        }
        if (_currentDinnerSide == Dinner_side.MacAndCheese) {
            GameObject.Instantiate(item_MacAndCheese, GameManager.inventory.transform);
        }

        /*
            AppleJuice,
            Milk,
            DecafCoffee
         */
        if (_currentDinnerBev == Dinner_bev.AppleJuice) {
            GameObject.Instantiate(item_AppleJuice, GameManager.inventory.transform);
        }
        if (_currentDinnerBev == Dinner_bev.Milk) {
            GameObject.Instantiate(item_Milk, GameManager.inventory.transform);
        }
        if (_currentDinnerBev == Dinner_bev.DecafCoffee) {
            GameObject.Instantiate(item_DecafCoffee, GameManager.inventory.transform);
        }
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

        // give dull or sharp pencil
        if (dullPencilCountdown <= 0) {
            GameObject.Instantiate(invItemPencilDull, GameManager.inventory.transform);
        } else {
            GameObject.Instantiate(invItemPencilSharp, GameManager.inventory.transform);
        }

        GameManager.StopFoodQuestionnaire();
        GameManager.ShowMessage("You got dinner. Press TAB to view & eat it."); // done here and not in PlayerGiveMealDinner(). hack
    }
}
