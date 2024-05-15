using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEatingManager : MonoBehaviour {

    public static string myLastMealIs = "- Nothing\n";
    public static int stomachSize = 3;

    public static bool ateAppleJuice = false;
    public static bool ateBurger = false;
    public static bool ateSomethingelse = false;

    void Start()
    {
        
    }

    public static void Consume(InventoryGridItem selectedGridItem) {
        // stomach size is set to 3 in timePass
        
        // reset stomach and last meal
        if (stomachSize == 3) {
            ateAppleJuice = false;
            ateBurger = false;
            ateSomethingelse = false;
            PlayerEatingManager.myLastMealIs = "";
        }

        if (stomachSize <= 0) {
            stomachSize = 0;
            GameManager.ShowMessage("You're too full to eat.\n\nYour last meal is:\n" + PlayerEatingManager.myLastMealIs);
            return;
        }

        if (selectedGridItem.myInvItem == InvItem.Burger) {
            ateBurger = true;
            GameObject.Instantiate(GameManager.foodQuestionnaire.GetComponent<FoodQuestionare>().item_BurgerBread, GameManager.inventory.transform);
        }
        else if (selectedGridItem.myInvItem == InvItem.AppleJuice) {
            ateAppleJuice = true;
            GameObject.Instantiate(GameManager.foodQuestionnaire.GetComponent<FoodQuestionare>().item_BurgerBread, GameManager.inventory.transform);
        } else {
            ateSomethingelse = true;
        }

        PlayerEatingManager.myLastMealIs = PlayerEatingManager.myLastMealIs + "- " + selectedGridItem.mealName + "\n";
        selectedGridItem.DestroyGridItem();

        GameManager.ShowMessage("Your last meal is:\n" + PlayerEatingManager.myLastMealIs);

        stomachSize -= 1;
    }
}
