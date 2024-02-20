using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChoiceButtonData : MonoBehaviour
{
    public StoryType storyType;
    public int storyIndex = 0;
    public GameObject choicesText;
    public TextMeshProUGUI buttonText;

    void Start()
    {
        HideChoice();
    }

    // Update is called once per frame
    public void UpdateText(string newChoiceText)
    {
        ShowChoice();
        buttonText.text = newChoiceText;
    }
    public void ShowChoice() {
        GetComponent<Button>().interactable = false;
        GetComponent<Button>().interactable = true; // hack so that the button looks unhighlighted after clicking
        choicesText.SetActive(true);
        gameObject.SetActive(true);
        buttonText.gameObject.SetActive(true);
    }
    public void HideChoice() {
        gameObject.SetActive(false);
        buttonText.gameObject.SetActive(false);
        choicesText.SetActive(false);
        if (storyIndex == 0) { // if there's no first choice. hide the "Choices" text
            buttonText.gameObject.SetActive(false);
        }
    }
    public void ShakeButton(bool newState) {
        GetComponent<ButtonShake>().ShakeButtonState(newState);
    }
    public void ProgressStory() {
        storyType.ProgressNovel(storyIndex);
    }
}