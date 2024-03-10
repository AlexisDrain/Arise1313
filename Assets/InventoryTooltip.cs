using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryTooltip : MonoBehaviour
{
    [Header("Read only")]
    public InventoryGridItem _selectedGridItem;

    [Header("Set once")]
    public TextMeshProUGUI tooltipLabel;
    public Button readButton;
    public Button eatButton;
    public Button selfharmButton;
    public Button discardButton;
    public GameObject inventory;

    void Start()
    {

    }

    public void Eat() {
        if (_selectedGridItem != null) {
            // use item
            print("SFX: eat sound");

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

    public void SummonTooltip(InventoryGridItem invItem) {

        // handle tooltip showing and hiding
        gameObject.SetActive(true);
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
            selfharmButton.gameObject.SetActive(false);
            discardButton.gameObject.SetActive(false);
        } else if (invItem.myInvItem == InvItem.ScrambledEggs) {
            readButton.gameObject.SetActive(false);
            eatButton.gameObject.SetActive(true);
            selfharmButton.gameObject.SetActive(false);
            discardButton.gameObject.SetActive(true);
        } else if (invItem.myInvItem == InvItem.PencilDull) {
            readButton.gameObject.SetActive(false);
            eatButton.gameObject.SetActive(false);
            selfharmButton.gameObject.SetActive(true);
            discardButton.gameObject.SetActive(true);
        }
    }

    private IEnumerator EnableTooltipDeactivate() {
        yield return new WaitForSecondsRealtime(0.01f);
        GetComponent<DeactivateOnClick>().enabled = true;
    }

}