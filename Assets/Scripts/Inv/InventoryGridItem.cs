using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum InvItem {
    // Add items at the end, not the begining, as it will break the indexing.
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
};

public class InventoryGridItem : MonoBehaviour
{
    public string itemLabelName;
    public string mealName;
    public InvItem myInvItem;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ClickButton);
    }

    public void ClickButton() {
        GameManager.invTooltip.SummonTooltip(GetComponent<InventoryGridItem>());
    }

    public void DestroyGridItem() {
        Destroy(gameObject);
    }


}
