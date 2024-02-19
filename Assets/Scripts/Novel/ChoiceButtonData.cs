using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceButtonData : MonoBehaviour
{
    public StoryType storyType;
    public int storyIndex = 0;
    public GameObject choiceText;

    void Start()
    {
        HideChoice();
    }

    // Update is called once per frame
    public void UpdateText(string newChoiceText)
    {
        ShowChoice();
        transform.Find("Text").GetComponent<TextMeshProUGUI>().text = newChoiceText;
    }
    public void ShowChoice() {
        GetComponent<Button>().interactable = false;
        GetComponent<Button>().interactable = true; // hack so that the button looks unhighlighted after clicking
        gameObject.SetActive(true);
        choiceText.SetActive(true);
    }
    public void HideChoice() {
        gameObject.SetActive(false);
        if(storyIndex == 0) { // if there's no first choice. hide the "Choices" text
            choiceText.SetActive(false);
        }
    }
    public void ShakeButton(bool newState) {
        print("shake choice " + newState);
    }
    public void ProgressStory() {
        storyType.ProgressNovel(storyIndex);
    }
}
