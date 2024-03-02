using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGridItem : MonoBehaviour
{
    public GameObject tooltip;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SummonTooltip);
    }

    // Update is called once per frame
    public void SummonTooltip()
    {
        StartCoroutine("EnableTooltipDeactivate");
        tooltip.SetActive(true);
        tooltip.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition
            + inventory.GetComponent<RectTransform>().anchoredPosition
            + new Vector2(-175f, 0f);
    }

    private IEnumerator EnableTooltipDeactivate() {
        yield return new WaitForSecondsRealtime(0.01f);
        tooltip.GetComponent<DeactivateOnClick>().enabled = true;
    }
}
