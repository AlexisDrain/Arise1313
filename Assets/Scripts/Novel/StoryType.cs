using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class StoryType : MonoBehaviour
{

    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public Story inkStory;
    public ChoiceButtonData choice0;
    public ChoiceButtonData choice1;

    private string finalText = "";
    private bool justOpenedStoryIntro = false;
    public Image bgImage;
    public TextMeshProUGUI myText;

    public List<Sprite> imageList = new List<Sprite>();

    [Header("Read only")]
    public List<int> _collectedNightmares = new List<int>();
    private Canvas myCanvas;

    private void Awake() {
        inkStory = new Story(inkJSONAsset.text);

        myText.text = "";
        myText.enabled = true; // disabled in the editor and enabled here so that the first frame doesn't show the full text
    }

    public void CloseNovel() {
        GameManager.StopNovel();
    }
    public void NovelStartFromIntro() {
        inkStory = new Story(inkJSONAsset.text);

        gameObject.SetActive(true);
        justOpenedStoryIntro = true;
        inkStory.ChoosePathString("novel_intro1");

        ProgressNovel(-1);
    }
    public void StartNovelKnot(string newPathString) {
        inkStory = new Story(inkJSONAsset.text);

        gameObject.SetActive(true);
        //justOpenedStory = true; too slow ingame
        inkStory.ChoosePathString(newPathString);

        ProgressNovel(-1);
    }
    public void ProgressNovel(int newIndex = -1) {

        if(newIndex != -1) {
            inkStory.ChooseChoiceIndex(newIndex);
        }


        // type story
        myText.text = "";
        finalText = "";
        while (inkStory.canContinue) {
            if (inkStory.currentTags.Count > 0) {
                for (int i = 0; i < inkStory.currentTags.Count; i++) {
                    if (inkStory.currentTags[i] == "image_black") {
                        bgImage.sprite = imageList[0];
                        continue;
                    }
                    if (inkStory.currentTags[i] == "image_redComputer") {
                        bgImage.sprite = imageList[1];
                        continue;
                    }
                    if (inkStory.currentTags[i] == "confiscate") {
                        inkStory.variablesState["confiscateVar"] = "";
                        continue;
                    }
                }
            }
            inkStory.Continue();
            finalText += inkStory.currentText + "\n";
        }


        // check we are at the end
        if (inkStory.currentTags.Count > 0) {

            if (inkStory.currentTags[0] == "sayonaraStart") {
                GameManager.StartSayonara();
                CloseNovel();
                return;
            }
            if (inkStory.currentTags[0] == "closeNovel") {
                CloseNovel();
                return;
            }
            if (inkStory.currentTags[0] == "foodGet") {
                GameManager.questManager.SolveQuest("breakfast3");
                //GameManager.StartFoodQuestionnaire();
                GameManager.foodQuestionnaire.GetComponent<FoodQuestionare>().PlayerGiveMealDinner();
                CloseNovel();
                return;
            }
            if (inkStory.currentTags[0] == "foodGetAndQuestionnaire") {
                GameManager.questManager.SolveQuest("breakfast3");
                GameManager.foodQuestionnaire.GetComponent<FoodQuestionare>().PlayerGiveMealBreakfast();
                GameManager.StartFoodQuestionnaire();
                CloseNovel();
                return;
            }
            //if (inkStory.currentTags[0] == "confiscate") {
            //}




        }

        // buttons
        choice0.HideChoice();
        choice1.HideChoice();

        if (justOpenedStoryIntro == true) {
            StartCoroutine("StoryIntroDelay");
            justOpenedStoryIntro = false;
        } else { // same as StoryIntroDelay but without delay
            StopCoroutine("Typewriter");
            StartCoroutine("Typewriter");
        }
    }

    public void StartRandomNightmare() {
        gameObject.SetActive(true);

        // random nightmare
        if (_collectedNightmares.Count == 2) {
            _collectedNightmares.Clear();
        }
        List<int> notInNightmare = new List<int>();
        for (int i = 0; i < 2;  i++) {
            if(_collectedNightmares.Contains(i)== false) {
                notInNightmare.Add(i);
            }
        }
        int randNum = Random.Range(0, notInNightmare.Count);
        int randNightmare = notInNightmare[randNum];
        _collectedNightmares.Add(randNightmare);

        // type story
        myText.text = "";
        finalText = "";

        inkStory.ChoosePathString("dream_" + randNightmare);
        while (inkStory.canContinue) {
            inkStory.Continue();
            finalText += inkStory.currentText + "\n";
        }

        // buttons
        choice0.HideChoice();
        choice1.HideChoice();
        // choice0.UpdateText(inkStory.currentChoices[0].text);

        StopCoroutine("Typewriter");
        StartCoroutine("Typewriter");
    }

    public void FastForwardStory() {
        StopCoroutine("Typewriter");
        myText.text = finalText;
        ShowButtons();
    }
    private void ShowButtons() {
        choice0.UpdateText(inkStory.currentChoices[0].text);
        if (inkStory.currentChoices.Count >= 2 && inkStory.currentChoices[1]) {
            choice1.UpdateText(inkStory.currentChoices[1].text);
        } else {
            choice1.HideChoice();
        }
        if (inkStory.currentChoices[0].text.Contains("Suicide")) {
            choice0.ShakeButton(true);
        } else {
            choice0.ShakeButton(false);
        }
    }
    IEnumerator StoryIntroDelay() {
        yield return new WaitForSeconds(2f);
        StopCoroutine("Typewriter");
        StartCoroutine("Typewriter");
    }
    IEnumerator StoryFadeInBlackDelay() {
        GameManager.FadeInThenOut();
        yield return new WaitForSeconds(0.5f);
        StopCoroutine("Typewriter");
        StartCoroutine("Typewriter");
    }
    IEnumerator Typewriter() {
        myText.text = "";

        foreach (char c in finalText) {
            //if (c != ' ' || c != '\n') {
            //    textAudioSource.Play();
            //}
            myText.text += c;
            yield return new WaitForSeconds(.01f);
        }
        yield return new WaitForSeconds(1f);
        ShowButtons();
    }

}
