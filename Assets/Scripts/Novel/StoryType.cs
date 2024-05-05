using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;
using System.Linq;

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
    public List<AudioClip> audioClipList = new List<AudioClip>();

    [Header("Read only")]
    public List<int> _collectedNightmares = new List<int>();
    private Canvas myCanvas;

    private void Awake() {
        inkStory = new Story(inkJSONAsset.text);

        myText.text = "";
        myText.enabled = true; // disabled in the editor and enabled here so that the first frame doesn't show the full text
    }

    // to fix bug when starting dialogue too fast after closing it
    private void OnDisable() {
        StopCoroutine("Typewriter");
        myText.text = "";
    }

    public void CloseNovel() {
        StopCoroutine("Typewriter");
        GameManager.StopNovel();
        if(GameManager.sanityHealth <= 0) {
            GameManager.StartSayonara(SayonaraType.SayonaraZeroSanity);
        }
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
    public void ProcessTags() {

        for (int i = 0; i < inkStory.currentTags.Count; i++) {
            print("inkStory tag: " + inkStory.currentTags[i] + " i: " + i);

            // images
            if (inkStory.currentTags[i] == "image_black") {
                bgImage.sprite = imageList[0];
            }
            if (inkStory.currentTags[i] == "image_redComputer") {
                bgImage.sprite = imageList[1];
            }
            // sfx
            if (inkStory.currentTags[i] == "sfx_phoneUp") {
                GameManager.SpawnLoudAudio(audioClipList[0]);
            }

            // special functions
            if (inkStory.currentTags[i] == "sanityUp") {
                GameManager.IncreaseSanity();
            }
            if (inkStory.currentTags[i] == "sanityDown") {
                GameManager.DecreaseSanity();
            }
            if (inkStory.currentTags[i] == "sanityDownTwice") {
                GameManager.DecreaseSanityTwice();
            }

            if (inkStory.currentTags[i] == "confiscate") {
                inkStory.variablesState["confiscateVar"] = "";
            }
            // chaplain
            if (inkStory.currentTags[i] == "checkWorship") {
                if (GameManager.numberOfPrayer == 0) {
                    GameManager.StartNovel("worship_intro");
                } 
                if (GameManager.numberOfPrayer >= 1) {
                    if (GameManager.currentTimeOfDay == TimeOfDay.Morning) {
                        GameManager.StartNovel("worship_Morn");
                    } else if (GameManager.currentTimeOfDay == TimeOfDay.Evening) {
                        GameManager.StartNovel("worship_Eve");
                    } else if (GameManager.currentTimeOfDay == TimeOfDay.Midnight) {
                        GameManager.StartNovel("worship_Night");
                    }
                }
                return; // inkStory tags that change the knot needs to return;
            }
            if (inkStory.currentTags[i] == "checkChaplainShakeHands") {
                if (GameManager.currentTimeOfDay == TimeOfDay.Morning) {
                    GameManager.StartNovel("worship_Morn");
                } else if (GameManager.currentTimeOfDay == TimeOfDay.Evening) {
                    GameManager.StartNovel("worship_Eve");
                } else if (GameManager.currentTimeOfDay == TimeOfDay.Midnight) {
                    GameManager.StartNovel("worship_Night");
                }
                return; // inkStory tags that change the knot needs to return;
            }
            if (inkStory.currentTags[i] == "checkSecondChaplainMeeting") {
                print(GameManager.numberOfPrayer);
                if (GameManager.numberOfPrayer == 2) {
                    GameManager.StartNovel("worship_ritualstep");
                } else {
                    CloseNovel();
                }
                return; // inkStory tags that change the knot needs to return;
            }
            

            // brother encounter
            if (inkStory.currentTags[i] == "checkBrother") {
                if (GameManager.storySeenBrother == false) {
                    GameManager.storySeenBrother = true;
                    GameManager.StartNovel("hasBrother");
                } else {
                    if (GameManager.currentTimeOfDay == TimeOfDay.Morning) {
                        GameManager.SetTimeOfDay(TimeOfDay.Evening);
                    } else if (GameManager.currentTimeOfDay == TimeOfDay.Evening) {
                        GameManager.SetTimeOfDay(TimeOfDay.Midnight);
                    } else {
                        Debug.LogWarning("hasBrother is invalid");
                    }
                    CloseNovel();
                }
                return; // inkStory tags that change the knot needs to return;
            }
            // pet encounter
            if (inkStory.currentTags[i] == "catKillCheck") {
                GameManager.StartNovel("group_killcat_HasPen");
                return; // inkStory tags that change the knot needs to return;
            }

            if (inkStory.currentTags[i] == "stopNovelTeleportPlayerToRitualRoom") {
                GameManager.TeleportPlayer(GameObject.Find("PlayerLeaveRitualTrans").transform);
                CloseNovel();
                return;
            }
                
            // ritual
            if (inkStory.currentTags[i] == "checkStep1") {
                if (GameManager.stepOneComplete) {
                    GameManager.StartNovel("ritual_step1_correct");
                } else {
                    GameManager.StartNovel("ritual_step1_incorrect");
                }
                return; // inkStory tags that change the knot needs to return;
            }
            if (inkStory.currentTags[i] == "updateMealString") {
                // inkStory.variablesState["finalMeal"] = "- Apple Juice\n - Yaba Daba Dooooo";
                inkStory.variablesState["finalMeal"] = "- Demo, not implemented yet. -Alexis";
            }
            if (inkStory.currentTags[i] == "checkStep2") {
                if (GameManager.stepTwoComplete) {
                    GameManager.StartNovel("ritual_step2_correct");
                } else {
                    GameManager.StartNovel("ritual_step2_incorrect");
                }
                return; // inkStory tags that change the knot needs to return;
            }
            if (inkStory.currentTags[i] == "checkStep3") {
                if (GameManager.stepThreeComplete) {
                    GameManager.StartNovel("ritual_step3_pet");
                } else {
                    GameManager.StartNovel("ritual_step3_nopet");
                }
                return; // inkStory tags that change the knot needs to return;
            }

            if (inkStory.currentTags[i] == "knowStepOne") {
                GameManager.knowsStepOne = true;
                GameManager.gameManagerObj.GetComponent<GameManager>().
                    DelayedMessage5Sec("You learned Step 1 of the ritual. Check your future paper in TAB menu.");
                // novel is closed in a seperate tag.
            }
            if (inkStory.currentTags[i] == "knowStepTwo") {
                GameManager.knowsStepTwo = true;
                GameManager.gameManagerObj.GetComponent<GameManager>().
                    DelayedMessage5Sec("You learned Step 2 of the ritual. Check your future paper in TAB menu.");
                // novel is closed in a seperate tag.
            }
            if (inkStory.currentTags[i] == "knowStepThree") {
                GameManager.knowsStepThree = true;
                GameManager.ShowMessage("You learned Step 3 of the ritual. Check your future paper in TAB menu.");
                CloseNovel(); // this closes it
            }
            // group, therapist, prayer increment
            if (inkStory.currentTags[i] == "groupIncrement") {
                GameManager.numberOfGroups += 1;
                print("numberOfGroups = " + GameManager.numberOfGroups);
            }
            if (inkStory.currentTags[i] == "therapyIncrement") {
                GameManager.numberOfTherapists += 1;
                print("numberOfTherapists = " + GameManager.numberOfTherapists);
            }
            if (inkStory.currentTags[i] == "prayerIncrement") {
                GameManager.numberOfPrayer += 1;
                print("numberOfPrayer = " + GameManager.numberOfPrayer);
                inkStory.currentTags.RemoveAt(i); // hack because of nested tags bug
                return;
            }

            // endings
            if (inkStory.currentTags[i] == "ending_good_sacrificeSelf") {
                CloseNovel();
                GameManager.EndGame("You sacrificed yourself to save the world.", true);
            }
            if (inkStory.currentTags[i] == "ending_good_sacrificeChaplain") {
                CloseNovel();
                GameManager.EndGame("You allowed the chaplain to sacrifice himself, thus saving the world.", true);
            }
            if (inkStory.currentTags[i] == "ending_good_sacrificePet") {
                CloseNovel();
                GameManager.EndGame("You sacrificed a cat to save the world.", true);
            }

            if (inkStory.currentTags[i] == "sayonaraStart_Intro") {
                GameManager.StartSayonara(SayonaraType.SayonaraIntro);
                CloseNovel();
            }
            if (inkStory.currentTags[i] == "closeNovel") {
                CloseNovel();
            }
            if (inkStory.currentTags[i] == "start3DGame") {
                GameManager.mainMenuMusic.SetActive(false);
                GameManager.SetTimeOfDay(TimeOfDay.Morning);
                CloseNovel();
            }
            /*
            if (inkStory.currentTags[i] == "playerWakeupToNight") {
                CloseNovel();
                GameManager.SetTimeOfDay(TimeOfDay.Midnight);
                GameManager.PlayerLeaveBed();
            }
            */
            if (inkStory.currentTags[i] == "playerWakeupToMorning") {
                CloseNovel();
                GameManager.PlayerLeaveBed();
            }
            if (inkStory.currentTags[i] == "setTimeFollowingTimePeriod") {
                if (GameManager.currentTimeOfDay == TimeOfDay.Morning) {
                    GameManager.SetTimeOfDay(TimeOfDay.Evening);
                } else if (GameManager.currentTimeOfDay == TimeOfDay.Evening) {
                    GameManager.SetTimeOfDay(TimeOfDay.Midnight);
                } else {
                    Debug.LogWarning("setTimeFollowingTimePeriod is invalid");
                }
                CloseNovel();
            }
            if (inkStory.currentTags[i] == "setTimeEve") {
                CloseNovel();
                GameManager.SetTimeOfDay(TimeOfDay.Evening);
            }
            if (inkStory.currentTags[i] == "setTimeMidnight") {
                CloseNovel();
                GameManager.SetTimeOfDay(TimeOfDay.Midnight);
            }

            if (inkStory.currentTags[i] == "foodGetAndQuestionnaire") {
                // GameManager.questManager.SolveQuest("breakfast3");
                GameManager.foodQuestionnaire.GetComponent<FoodQuestionare>().PlayerGiveMealDinner();
                GameManager.StartFoodQuestionnaire();
                CloseNovel();
            }
            if (inkStory.currentTags[i] == "foodGet") {
                // GameManager.questManager.SolveQuest("breakfast3");
                //GameManager.StartFoodQuestionnaire();
                GameManager.foodQuestionnaire.GetComponent<FoodQuestionare>().PlayerGiveMealBreakfast();
                CloseNovel();
            }
        }
    }
    public void ProgressNovel(int newIndex = -1) {
        // newIndex is which choice the player chooses.
        // I.e. 0 is the first option. 1 is the second option provided to the player.
        // -1 means no choice provided

        if (newIndex >= 0) {
            inkStory.ChooseChoiceIndex(newIndex);
        }

        // type story
        myText.text = "";
        finalText = "";
        while (inkStory.canContinue) {

            if (inkStory.currentTags.Count > 0) {
                ProcessTags();
            }

            inkStory.Continue();
            finalText += inkStory.currentText + "\n";
        }

        // buttons
        choice0.HideChoice();
        choice1.HideChoice();

        if (justOpenedStoryIntro == true) {
            StartCoroutine("StoryIntroDelay");
        } else { // same as StoryIntroDelay but without delay
            StopCoroutine("Typewriter");
            StartCoroutine("Typewriter");
        }


        if (inkStory.currentTags.Count > 0) {
            ProcessTags();
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
        if(justOpenedStoryIntro) {
            return;
        }
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
        if (inkStory.currentChoices[0].text.Contains("Suicide") || inkStory.currentChoices[0].text.Contains("Sacrifice")) {
            choice0.ShakeButton(true);
        } else {
            choice0.ShakeButton(false);
        }
        if (inkStory.currentChoices.Count >= 2
            && (inkStory.currentChoices[1].text.Contains("Kill") || inkStory.currentChoices[1].text.Contains("Sacrifice"))) {
            choice1.ShakeButton(true);
        } else {
            choice1.ShakeButton(false);
        }
    }
    IEnumerator StoryIntroDelay() {
        yield return new WaitForSeconds(2f);
        justOpenedStoryIntro = false;
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
