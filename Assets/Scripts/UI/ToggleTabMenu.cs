using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTabMenu : MonoBehaviour
{
    // private GameObject quests;
    private GameObject sanity;
    private GameObject inventory;
    private GameObject inventoryTooltip;
    private GameObject iconTime;
    public GameObject button_options;
    public GameObject optionsMenu;
    void Start()
    {
        // quests = transform.Find("Quests").gameObject;
        // quests.SetActive(false);
        sanity = transform.Find("Sanity").gameObject;
        sanity.SetActive(false);
        inventory = transform.Find("Inventory").gameObject;
        inventory.SetActive(false);
        inventoryTooltip = transform.Find("InventoryTooltip").gameObject;
        inventoryTooltip.SetActive(false);
        iconTime = transform.Find("IconTime").gameObject;
        iconTime.SetActive(false);
        button_options.SetActive(false);

        GameManager.playerInTabMenu = false;
    }

    private void HideMenu() {
        // quests.SetActive(false);
        sanity.SetActive(false);
        inventory.SetActive(false);
        inventoryTooltip.SetActive(false);
        iconTime.SetActive(false);
        button_options.SetActive(false);
        optionsMenu.SetActive(false);
        GameManager.playerInTabMenu = false;

        GameObject futurePaper = GameObject.Find("Canvas/FuturePaper");
        if (futurePaper) {
            futurePaper.SetActive(false);
        };
    }
    void Update() {

        if (GameManager.playerInNovelOrSayonara || GameManager.playerInMainMenu) {
            if (inventory.activeSelf == true) {
                HideMenu();
            }
            return;
        }

        if (inventory.activeSelf == true && (Mathf.Abs(Input.GetAxis("Vertical")) > 0.9f || Mathf.Abs(Input.GetAxis("Horizontal")) > 0.9f)) {
            HideMenu();
        }
        if (Input.GetButtonDown("ToggleTab")) {
            if(inventory.activeSelf == false) {
                // quests.SetActive(true);
                sanity.SetActive(true);
                sanity.GetComponent<SanityController>().StopCoroutine("DisapearSanity");
                inventory.SetActive(true);
                button_options.SetActive(true);
                if(GameManager.currentDayOfWeek != DayOfWeek.Outro) {
                    iconTime.SetActive(true);
                }
                // inventoryTooltip.SetActive(true); gets unhiden by using the inventory
                GameManager.playerInTabMenu = true;
            } else if (inventory.activeSelf == true) {
                HideMenu();
            }
        }
    }
}
