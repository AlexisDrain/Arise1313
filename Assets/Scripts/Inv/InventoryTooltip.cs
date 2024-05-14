using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class InventoryTooltip : MonoBehaviour
{
    [Header("Read only")]
    public InventoryGridItem _selectedGridItem;

    [Header("Set once")]
    public TextMeshProUGUI tooltipLabel;
    public Button readButton;
    public Button eatButton;
    public Button drinkButton;
    public Button selfharmButton;
    public Button discardButton;
    public GameObject inventory;

    public AudioClip sfxEat;
    public AudioClip sfxDrink;

    void Start()
    {

    }

    public void Eat() {
        if (_selectedGridItem != null) {
            // use item
            GameManager.SpawnLoudAudio(sfxEat);
            if(_selectedGridItem.myInvItem == InvItem.Burger) {
                GameObject.Instantiate(GameManager.foodQuestionnaire.GetComponent<FoodQuestionare>().item_BurgerBread, GameManager.inventory.transform);
            }

            // remove item
            _selectedGridItem.DestroyGridItem(); // destroy first THEN unselect
            _selectedGridItem = null;

            // hide tooltip
            GetComponent<DeactivateOnClick>().enabled = false;
            gameObject.SetActive(false);
        }
    }
    public void Drink() {
        if (_selectedGridItem != null) {
            // use item
            GameManager.SpawnLoudAudio(sfxDrink);

            // remove item
            _selectedGridItem.DestroyGridItem(); // destroy first THEN unselect
            _selectedGridItem = null;

            // hide tooltip
            GetComponent<DeactivateOnClick>().enabled = false;
            gameObject.SetActive(false);
        }
    }
    public void Discard() {
        if (_selectedGridItem != null) {
            // use item
            print("SFX: discard sound / throwing away paper");

            // remove item
            _selectedGridItem.DestroyGridItem(); // destroy first THEN unselect
            _selectedGridItem = null;

            // hide tooltip
            GetComponent<DeactivateOnClick>().enabled = false;
            gameObject.SetActive(false);
        }
    }

    public void Selfharm() {
        if (_selectedGridItem != null) {
            // use item
            if (_selectedGridItem.myInvItem == InvItem.PencilDull) {
                print("summon sayonara");
            } else if (_selectedGridItem.myInvItem == InvItem.PencilSharp) {
                print("summon sayonara");
            }

            // remove item
            _selectedGridItem.DestroyGridItem(); // destroy first THEN unselect
            _selectedGridItem = null;

            // hide tooltip
            GetComponent<DeactivateOnClick>().enabled = false;
            gameObject.SetActive(false);
        }
    }

    /*
     * From InventoryGridItem.cs
     * 
    None,
            FuturePaper,
    PencilDull,
    PencilSharp,
    Drugs,
    Oatmeal,
    ScrambledEggs,
    FrenchToast,
    AppleJuice,
    CranberryJuice,
    OrangeJuice,
    DecafCoffee,
    Pizza,
    Burger,
    Hummus,
    Rice,
    MacAndCheese,
    Milk,
    BurgerBread,
    MilkChocolate
     * */
    public void SummonTooltip(InventoryGridItem invItem) {

        // handle tooltip showing and hiding
        gameObject.SetActive(true);
        GetComponent<DeactivateOnClick>().enabled = false;
        StartCoroutine("EnableTooltipDeactivate");
        GetComponent<RectTransform>().anchoredPosition = invItem.GetComponent<RectTransform>().anchoredPosition
            + inventory.GetComponent<RectTransform>().anchoredPosition
            + new Vector2(-175f, 0f);

        // update selected item
        _selectedGridItem = invItem;
        tooltipLabel.text = invItem.itemLabelName;

        if (invItem.myInvItem == InvItem.FuturePaper) {
            readButton.gameObject.SetActive(true);
            eatButton.gameObject.SetActive(false);
            drinkButton.gameObject.SetActive(false);
            selfharmButton.gameObject.SetActive(false);
            discardButton.gameObject.SetActive(false);
        } else if (invItem.myInvItem == InvItem.AppleJuice
                || invItem.myInvItem == InvItem.CranberryJuice
                || invItem.myInvItem == InvItem.OrangeJuice
                || invItem.myInvItem == InvItem.DecafCoffee
                || invItem.myInvItem == InvItem.Milk
                || invItem.myInvItem == InvItem.MilkChocolate) {
            readButton.gameObject.SetActive(false);
            eatButton.gameObject.SetActive(false);
            drinkButton.gameObject.SetActive(true);
            selfharmButton.gameObject.SetActive(false);
            discardButton.gameObject.SetActive(false);
        } else if (invItem.myInvItem == InvItem.Oatmeal
                || invItem.myInvItem == InvItem.ScrambledEggs
                || invItem.myInvItem == InvItem.FrenchToast
                || invItem.myInvItem == InvItem.Pizza
                || invItem.myInvItem == InvItem.Burger
                || invItem.myInvItem == InvItem.Hummus
                || invItem.myInvItem == InvItem.Rice
                || invItem.myInvItem == InvItem.MacAndCheese
                || invItem.myInvItem == InvItem.BurgerBread) {
            readButton.gameObject.SetActive(false);
            eatButton.gameObject.SetActive(true);
            drinkButton.gameObject.SetActive(false);
            selfharmButton.gameObject.SetActive(false);
            discardButton.gameObject.SetActive(false);
        } else if (invItem.myInvItem == InvItem.PencilDull
                || invItem.myInvItem == InvItem.PencilSharp) {
            readButton.gameObject.SetActive(false);
            eatButton.gameObject.SetActive(false);
            drinkButton.gameObject.SetActive(false);
            selfharmButton.gameObject.SetActive(false);
            discardButton.gameObject.SetActive(false);
        }  else {
            Debug.LogWarning("Inv item has no tooltip properties");
        }
    }

    private IEnumerator EnableTooltipDeactivate() {
        yield return new WaitForSecondsRealtime(0.01f);
        GetComponent<DeactivateOnClick>().enabled = true;
    }

}
