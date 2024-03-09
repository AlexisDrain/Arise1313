using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum InvItem {
    None,
    FuturePaper,
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
    Milk
};

public class InventoryGridItem : MonoBehaviour
{
    public string itemLabelName;
    public InvItem myInvItem;
    [Header("Set once")]
    //public Sprite imageNothing;
    public InventoryTooltip tooltip;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickButton);
    }

    public void ClickButton() {
        tooltip.SummonTooltip(GetComponent<InventoryGridItem>());
    }

    public void DestroyGridItem() {
        Destroy(gameObject);
    }


}
