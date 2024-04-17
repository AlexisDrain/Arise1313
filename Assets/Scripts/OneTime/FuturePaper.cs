using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FuturePaper : MonoBehaviour {
    [TextArea(4, 3)]
    public string prefix;
    [TextArea(4,3)]
    public string step1_Unknown;
    [TextArea(4, 3)]
    public string step2_Unknown;
    [TextArea(4, 3)]
    public string step3_Unknown;
    [TextArea(4, 3)]
    public string step1_Known;
    [TextArea(4, 3)]
    public string step2_Known;
    [TextArea(4, 3)]
    public string step3_Known;

    [TextArea(4, 3)]
    public string suffix;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdatePaper()
    {
        string finalText = "";

        finalText += prefix;

        if(GameManager.knowsStepOne) {
            finalText += step1_Known;
        } else {
            finalText += step1_Unknown;
        }
        if (GameManager.knowsStepTwo) {
            finalText += step2_Known;
        } else {
            finalText += step2_Unknown;
        }
        if (GameManager.knowsStepThree) {
            finalText += step3_Known;
        } else {
            finalText += step3_Unknown;
        }

        finalText += suffix;

        GetComponent<TextMeshProUGUI>().text = finalText;
    }
}
