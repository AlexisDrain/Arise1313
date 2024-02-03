using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayUseText : MonoBehaviour
{
    public TextMeshProUGUI TextObject;

    void Start()
    {
        HideDisplay();
    }

    // Update is called once per frame
    public void Highlight(string newText)
    {
        GetComponent<Image>().enabled = true;
        TextObject.text = newText;
    }
    public void HideDisplay() {
        GetComponent<Image>().enabled = false;
        TextObject.text = string.Empty;
    }
}
