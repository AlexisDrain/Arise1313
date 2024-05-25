using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum TimeOfDay {
    Morning,
    Evening,
    Midnight
}
public enum DayOfWeek {
    DayOne,
    DayTwo,
    Outro
}

public enum SayonaraType {
    SayonaraIntro,
    SayonaraZeroSanity,
    SayonaraRitual,
    SayonaraBloodPressure
}

public class GameManager : MonoBehaviour
{
    public static GameObject gameManagerObj;
    // public static QuestManager questManager;
    public static Transform player;
    public static StoryType storyType;
    public static Camera mainCamera;
    public static Camera blinkCamera;
    public static BlinkController blinkController;
    public static DisplayUseText displayUseText;

    // Sayonara
    public static GameObject sayonaraAssets;
    public static SpawnSayonara sayonaraAssetsSpawn;
    public static SayonaraController sayonaraIntroController;
    public static SayonaraController sayonaraZeroSanityController;
    public static SayonaraController sayonaraRitualController;
    public static SayonaraController sayonaraBloodPressureController;
    // canvas
    //public static GameObject dream;
    public static GameObject foodQuestionnaire; 
    public static GameObject tutorialControls;
    public static GameObject tabMenu;
    public static GameObject sanityMenu;
    public static GameObject inventory;
    public static InventoryTooltip invTooltip;
    public static PlayerEatingManager playerEatingManager;
    public static PhoneManager phoneManager;
    public static GameObject imageScreenTransition;
    public static GameObject timePass;
    public static GameObject mainMenu;
    public static GameObject mainMenuButtons;
    public static GameObject endingMenu;
    public static GameObject musicObj;
    public static GameObject mainMenuMusic;

    public static GameObject outroWorld;

    public static Transform bedCameraTransform;
    public static Transform playerAwakeTrans;
    public static Transform playerElevatorTrans;
    public static Transform playerOutroTrans;

    private static Pool pool_LoudAudioSource;

   // public static PlayerProgress currentPlayerProgress = PlayerProgress.PlayerInNovelIntroFirstTime;
    public static TimeOfDay currentTimeOfDay;
    public static DayOfWeek currentDayOfWeek;

    // group visit increment
    public static int sanityHealth = 3;
    public static int numberOfGroups = 0;
    public static int numberOfTherapists = 0;
    public static int numberOfPrayer = 0;
    public static bool hasPencilDull = false;
    public static bool hasPencilSharp = false;
    public static bool killedCat = false;

    // phone manager:
    /*
    public static bool knowsStepOne;
    public static bool calledRitualDay1;
    public static bool calledRitualDay2;
    public static bool calledParentsDay;
    public static bool calledParentsNight;
    public static bool calledSiblings;
    */

    // ritual
    public static bool knowsStepOne = false; // the phone number
    public static bool knowsStepTwo = false; // final meal
    public static bool knowsStepThree = false; // sacrifice
    public static bool stepOneComplete = false;
    public static bool stepTwoComplete = false;
    public static bool stepThreeComplete = false;

    // player navigation
    public static bool playerInMainMenu = true;
    public static bool playerInFoodQuestionnaire = false;
    public static bool playerInNovelOrSayonara = false;
    public static bool playerInTabMenu = false;
    public static bool playerInBed = false;
    public static bool playerGotBreakfast = false;
    public static bool playerGotDinner = false;
    public static bool gameIsPaused = true;
    public static bool gameHasBeenStartedOnce = false;
    public static bool storySeenBrother = false;
    public static bool sayonaraColorBlind = false;
    public bool cheatMode = true;

    public static LayerMask worldMask;
    public static LayerMask entityMask;
    public static LayerMask eyesClosedMask;
    public static LayerMask triggersMask;

    public static UnityEvent changeTimeOfDayEvent = new UnityEvent();
    public static UnityEvent EyesClosedEvent = new UnityEvent();
    public static UnityEvent EyesOpenEvent = new UnityEvent();

    void Awake() {
        gameManagerObj = gameObject;
        // questManager = GetComponent<QuestManager>();
        player = GameObject.Find("Player").transform;
        storyType = GameObject.Find("Canvas/IntroNovel").GetComponent<StoryType>();
        storyType.gameObject.SetActive(false);
        mainCamera = GameObject.Find("Player/CamDolly/MainCam").GetComponent<Camera>();
        blinkCamera = GameObject.Find("Player/CamDolly/BlinkCam").GetComponent<Camera>();
        blinkController = GameObject.Find("CanvasEye/EyeBlink").GetComponent<BlinkController>();
        displayUseText = GameObject.Find("Canvas/UseTextBG").GetComponent<DisplayUseText>();

        // sayonara
        sayonaraIntroController = GameObject.Find("Canvas/Sayonara/SayonaraIntro").GetComponent<SayonaraController>();
        sayonaraIntroController.gameObject.SetActive(false);
        sayonaraZeroSanityController = GameObject.Find("Canvas/Sayonara/SayonaraZeroSanity").GetComponent<SayonaraController>();
        sayonaraZeroSanityController.gameObject.SetActive(false);
        sayonaraRitualController = GameObject.Find("Canvas/Sayonara/SayonaraRitual").GetComponent<SayonaraController>();
        sayonaraRitualController.gameObject.SetActive(false);
        sayonaraBloodPressureController = GameObject.Find("Canvas/Sayonara/SayonaraBloodPressure").GetComponent<SayonaraController>();
        sayonaraBloodPressureController.gameObject.SetActive(false);
        sayonaraAssets = GameObject.Find("Canvas/Sayonara/SayonaraAssets");
        sayonaraAssetsSpawn = GameObject.Find("Canvas/Sayonara/SayonaraAssets/Pool_ButtonSayonara").GetComponent<SpawnSayonara>();
        sayonaraAssets.gameObject.SetActive(false);

        //dream = GameObject.Find("Canvas/Dream");
        //dream.gameObject.SetActive(false);
        foodQuestionnaire = GameObject.Find("Canvas/FoodQuestionnaire");
        foodQuestionnaire.gameObject.SetActive(false);
        tutorialControls = GameObject.Find("Canvas/Tutorial_Controls");
        tabMenu = GameObject.Find("Canvas/TabMenu");
        //tabMenu.gameObject.SetActive(false);
        sanityMenu = GameObject.Find("Canvas/TabMenu/Sanity");
        sanityMenu.SetActive(false);
        inventory = GameObject.Find("Canvas/TabMenu/Inventory");
        invTooltip = GameObject.Find("Canvas/TabMenu/InventoryTooltip").GetComponent<InventoryTooltip>();
        playerEatingManager = GetComponent<PlayerEatingManager>();
        phoneManager = GetComponent<PhoneManager>();
        imageScreenTransition = GameObject.Find("ScreenTransition");
        timePass = GameObject.Find("Canvas/TimePass");
        timePass.SetActive(false);
        mainMenu = GameObject.Find("Canvas/MainMenu").gameObject;
        mainMenuButtons = mainMenu.transform.Find("MainMenuButtons").gameObject;
        endingMenu = GameObject.Find("Canvas/EndingMenu").gameObject;
        endingMenu.SetActive(false);
        musicObj = GameObject.Find("TimedObjects_Music").gameObject;
        mainMenuMusic = GameObject.Find("TimedObjects_Music/MainMenuMusic").gameObject;

        outroWorld = GameObject.Find("OutroWorld").gameObject;
        outroWorld.SetActive(false);

        bedCameraTransform = GameObject.Find("BedCamera").transform;
        playerAwakeTrans = GameObject.Find("PlayerAwakeTrans").transform;
        playerElevatorTrans = GameObject.Find("PlayerElevatorTrans").transform;
        playerOutroTrans = GameObject.Find("PlayerOutroTrans").transform;
        pool_LoudAudioSource = transform.Find("pool_LoudAudioSource").GetComponent<Pool>();

        worldMask = LayerMask.NameToLayer("World");
        entityMask = LayerMask.NameToLayer("Entity");
        eyesClosedMask = LayerMask.NameToLayer("EyesClosed");
        triggersMask = LayerMask.NameToLayer("Triggers");

        SetTimeOfDay(TimeOfDay.Midnight); // because midnight has no music. progressing through novel will set to morning.
        currentDayOfWeek = DayOfWeek.DayOne;
        // Time.timeScale = 0f;
    }

    public static void NewGame() {
        // gameManagerObj.GetComponent<QuestManager>().CreateNewQuest("q_goToGroupMorn");
        gameHasBeenStartedOnce = true;
        storySeenBrother = false;
        playerInNovelOrSayonara = true;
        playerInMainMenu = false;
        numberOfGroups = 0;
        numberOfTherapists = 0;
        numberOfPrayer = 0;
        sanityHealth = 3;
        killedCat = false;
        GameManager.hasPencilDull = false;
        GameManager.hasPencilSharp = false;
        knowsStepOne = false;
        knowsStepTwo = false;
        knowsStepThree = false;
        PlayerEatingManager.RestartEatingManager();
        GameManager.phoneManager.RestartPhoneStats();
        GameManager.foodQuestionnaire.GetComponent<FoodQuestionare>().DestroyAllInvExceptFuturePaper();

        outroWorld.SetActive(false);
        RenderSettings.fog = true;
        RenderSettings.reflectionIntensity = 1f;
        RenderSettings.ambientIntensity = 1f;

        // if (GameManager.currentPlayerProgress == PlayerProgress.PlayerInNovelIntroFirstTime) {
        GameManager.StartNovel();
        //}

    }
    public static void RestartGame() { // confusingly, this is titled End Game inside the game
        endingMenu.SetActive(false);
        mainMenu.SetActive(true);
        mainMenu.GetComponent<Animator>().SetTrigger("PauseFade");
        mainMenuButtons.gameObject.SetActive(true);
    }
    public static void GoToOutro() {
        endingMenu.SetActive(false);
        GameManager.SetDay(DayOfWeek.Outro);
        changeTimeOfDayEvent.Invoke();
        timePass.SetActive(false);
        RenderSettings.fog = false;
        RenderSettings.reflectionIntensity = 0f;
        RenderSettings.ambientIntensity = 0f;
        GameManager.outroWorld.SetActive(true);
        GameManager.TeleportPlayer(GameManager.playerOutroTrans);
    }

    public static void KillSelfEnding() {
        GameManager.EndGame("You died, sparing youself from the eternal torture but not saving the world.", false);
    }
    public static void EndGame(string endGameMessage, bool goodEnding) {
        SetTimeOfDay(TimeOfDay.Midnight); // because midnight has no music. progressing through novel will set to morning.
        currentDayOfWeek = DayOfWeek.DayOne;
        timePass.GetComponent<AudioSource>().StopWebGL();

        endingMenu.SetActive(true);
        endingMenu.transform.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = endGameMessage;
        
        if (goodEnding) {
            endingMenu.transform.Find("Button_RestartGame").gameObject.SetActive(false);
            endingMenu.transform.Find("Button_StartEpilogue").gameObject.SetActive(true);
            endingMenu.GetComponent<Animator>().SetTrigger("InvokeGood");
        } else if (goodEnding == false) {
            endingMenu.transform.Find("Button_RestartGame").gameObject.SetActive(true);
            endingMenu.transform.Find("Button_StartEpilogue").gameObject.SetActive(false);
            endingMenu.GetComponent<Animator>().SetTrigger("InvokeBad");

            musicObj.GetComponent<TriggerTimeOfDay>().DisableAllMembersAllGroups(); // this kills all the music
            mainMenuMusic.SetActive(true);
        }
        mainMenu.SetActive(false);
    }

    public static void FadeInThenOut() {
        imageScreenTransition.GetComponent<Animator>().SetTrigger("FadeInThenOut");
    }

    // messages and delayed messages
    public static void ShowMessage(string newMessageText) {
        Transform message = GameObject.Find("Canvas/Message").transform;
        message.Find("MessageBG/Text (TMP)").GetComponent<TextMeshProUGUI>().text = newMessageText;
        message.GetComponent<Animator>().SetTrigger("MessageFade");

        /*
        if(newMessageText.Length > 60) {
            message.Find("Text (TMP)").GetComponent<RectTransform>().
        }
        */
    }
    public void DelayedMessage5Sec(string message) {
        StartCoroutine("DelayedMessage5SecCountdown", message);
    }
    public IEnumerator DelayedMessage5SecCountdown(string message) {
        yield return new WaitForSeconds(5f);
        GameManager.ShowMessage(message);
    }

    public static void IncreaseSanity() {
        sanityMenu.GetComponent<SanityController>().IncreaseSanity();
    }
    public static void DecreaseSanity() {
        sanityMenu.GetComponent<SanityController>().DecreaseSanity();
    }
    public static void DecreaseSanityTwice() {
        sanityMenu.GetComponent<SanityController>().DecreaseSanityTwice();
    }

    public static void SetDay(DayOfWeek dayOfWeek) {
        GameManager.currentDayOfWeek = dayOfWeek;
    }

    // TO DO: make the visual aspect (animation) of the time of day SEPERATE from the actual time of day change.
    public static void SetTimeOfDay(TimeOfDay newTimeOfDay) {
        currentTimeOfDay = newTimeOfDay;

        changeTimeOfDayEvent.Invoke();
        PlayerEatingManager.ResetStomackSize();

        timePass.SetActive(true); // cutscene object
        if(gameHasBeenStartedOnce && GameManager.sanityHealth > 0) {
            timePass.GetComponent<AudioSource>().PlayWebGL();
        }

        //change time icon
        Image iconMorning = GameObject.Find("Canvas/TabMenu/IconTime/IconTime_Morning").GetComponent<Image>();
        Image iconEvening = GameObject.Find("Canvas/TabMenu/IconTime/IconTime_Evening").GetComponent<Image>();
        Image iconMidNight = GameObject.Find("Canvas/TabMenu/IconTime/IconTime_Midnight").GetComponent<Image>();
        TextMeshProUGUI iconMorningText = GameObject.Find("Canvas/TabMenu/IconTime/IconTime_Morning/IconTimeText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI iconEveText = GameObject.Find("Canvas/TabMenu/IconTime/IconTime_Evening/IconTimeText").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI iconNightText = GameObject.Find("Canvas/TabMenu/IconTime/IconTime_Midnight/IconTimeText").GetComponent<TextMeshProUGUI>();
        TMPro.TextMeshProUGUI iconTime = GameObject.Find("Canvas/TabMenu/IconTime/TimeDigital").GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI timeLeft = GameObject.Find("Canvas/TabMenu/IconTime/TimeLeft").GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI iconTimeCutscene = timePass.transform.Find("TimeDigital").GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI timeLeftCutscene = timePass.transform.Find("TimeLeft").GetComponent<TMPro.TextMeshProUGUI>();

        // change player location
        if (newTimeOfDay == TimeOfDay.Morning) {
            timePass.GetComponent<Animator>().SetTrigger("SetMorning");
            iconTime.text = "08:00 AM";
            iconTimeCutscene.text = "08:00 AM";
            iconMorning.enabled = true;
            iconEvening.enabled = false;
            iconMidNight.enabled = false;
            iconMorningText.enabled = true;
            iconEveText.enabled = false;
            iconNightText.enabled = false;
            // questManager.CreateNewQuest("breakfast3");

            // player position
            if (currentDayOfWeek == DayOfWeek.DayOne) {
                timeLeftCutscene.text = "40 Hours Left";
                timeLeft.text = "40 Hours Left";
                GameManager.TeleportPlayer(GameManager.playerElevatorTrans);
            } else if (currentDayOfWeek == DayOfWeek.DayTwo) {
                timeLeftCutscene.text = "16 Hours Left";
                timeLeft.text = "16 Hours Left";

                GameManager.TeleportPlayer(GameManager.playerAwakeTrans);
            }

        } else if (newTimeOfDay == TimeOfDay.Evening) {

            timePass.GetComponent<Animator>().SetTrigger("SetEve");
            iconTime.text = "04:00 PM";
            iconTimeCutscene.text = "04:00 PM";
            iconMorning.enabled = false;
            iconEvening.enabled = true;
            iconMidNight.enabled = false;
            iconMorningText.enabled = false;
            iconEveText.enabled = true;
            iconNightText.enabled = false;

            // player position
            GameManager.TeleportPlayer(GameManager.playerElevatorTrans);

            if (currentDayOfWeek == DayOfWeek.DayOne) {
                timeLeftCutscene.text = "32 Hours Left";
                timeLeft.text = "32 Hours Left";
            } else if (currentDayOfWeek == DayOfWeek.DayTwo) {
                timeLeftCutscene.text = "8 Hours Left";
                timeLeft.text = "8 Hours Left";
            }
        } else if (newTimeOfDay == TimeOfDay.Midnight) {
            timePass.GetComponent<Animator>().SetTrigger("SetNight");
            iconTime.text = "11:00 PM";
            iconTimeCutscene.text = "11:00 PM";
            iconMorning.enabled = false;
            iconEvening.enabled = false;
            iconMidNight.enabled = true;
            iconMorningText.enabled = false;
            iconEveText.enabled = false;
            iconNightText.enabled = true;

            GameManager.TeleportPlayer(GameManager.playerElevatorTrans);

            if (currentDayOfWeek == DayOfWeek.DayOne) {
                timeLeftCutscene.text = "25 Hours Left";
                timeLeft.text = "25 Hours Left";
            } else if (currentDayOfWeek == DayOfWeek.DayTwo) {
                timeLeftCutscene.text = "1 Hour Left";
                timeLeft.text = "1 Hour Left";
            }
        }

    }

    // sleeping is handled in FillFKey script

    public static void PlayerGoToBed() {
        GameManager.playerInBed = true;
        GameManager.player.Find("Img").GetComponent<SpriteRenderer>().enabled = false;
    }
    public static void PlayerDream() {

        GameManager.playerInBed = false;
        storyType.StartNovelKnot("dream_0");
        // storyType.StartRandomNightmare();

    }
    public static void TeleportPlayer(Transform newTransform) {

        GameManager.player.position = newTransform.position;
        GameManager.player.GetComponent<Rigidbody>().position = newTransform.position;
        GameManager.player.rotation = newTransform.rotation;
        GameManager.player.GetComponent<Rigidbody>().rotation = newTransform.rotation;
    }
    public static void PlayerLeaveBed() {
        GameManager.SetDay(DayOfWeek.DayTwo);
        GameManager.SetTimeOfDay(TimeOfDay.Morning);

        // GameManager.playerInBed = false;
        GameManager.playerGotBreakfast = false;
        GameManager.playerGotDinner = false;
        GameManager.player.Find("Img").GetComponent<SpriteRenderer>().enabled = true;

        GameManager.TeleportPlayer(GameManager.playerAwakeTrans);

        mainCamera.transform.position = GameObject.Find("Player/CamDolly").transform.position;
        mainCamera.transform.rotation = GameObject.Find("Player/CamDolly").transform.rotation;

        blinkCamera.transform.position = GameObject.Find("Player/CamDolly").transform.position;
        blinkCamera.transform.rotation = GameObject.Find("Player/CamDolly").transform.rotation;
    }
    public static void KillPlayer() {
        GameManager.TeleportPlayer(GameManager.playerAwakeTrans);

        print("kill player");

        // if(GameManager.currentPlayerProgress == PlayerProgress.PlayerInNovelIntroFirstTime) {
        playerInNovelOrSayonara = true;
        GameManager.NewGame();
        // }


        /*
        GameManager.canvasDeath.SetActive(true);
        GameManager.player.GetComponent<PlayerController>().graphicGirl.SetActive(false);
        GameManager.player.GetComponent<PlayerController>().shadow.SetActive(false);

        if(GameManager.currentLevel.GetComponent<LevelValues>().enableGibs == true) {
            GameObject gibs = GameManager.pool_Gibs.Spawn(GameManager.player.transform.position);
            gibs.transform.rotation = GameManager.player.transform.rotation;
        }
        */
    }
    public void ResumeGame() {
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }
    public static void StartFoodQuestionnaire() {

        GameManager.foodQuestionnaire.SetActive(true);
        playerInFoodQuestionnaire = true;
    }
    public static void StopFoodQuestionnaire() {
        GameManager.foodQuestionnaire.SetActive(false);
        playerInFoodQuestionnaire = false;
    }

    public static void StartNovel(string newStoryKnot = "") {
        playerInNovelOrSayonara = true;
        if (newStoryKnot == "") {
            storyType.NovelStartFromIntro();
        } else {
            storyType.StartNovelKnot(newStoryKnot);
        }
    }
    public static void StopNovel() {
        storyType.gameObject.SetActive(false);
        playerInNovelOrSayonara = false;
    }

    public static void StartSayonara(SayonaraType mySayonaraType) {
        SayonaraController currentSayonaraController = null;
        if (mySayonaraType == SayonaraType.SayonaraIntro) {
            currentSayonaraController = sayonaraIntroController;
            currentSayonaraController.sayonaraTutorial = true;
        } else if (mySayonaraType == SayonaraType.SayonaraZeroSanity) {
            currentSayonaraController = sayonaraZeroSanityController;
        } else if (mySayonaraType == SayonaraType.SayonaraRitual) {
            currentSayonaraController = sayonaraRitualController;
        } else if (mySayonaraType == SayonaraType.SayonaraBloodPressure) {
            currentSayonaraController = sayonaraBloodPressureController;
        }

        currentSayonaraController.gameObject.SetActive(true);
        sayonaraAssetsSpawn.currentSayonaraController = currentSayonaraController;
        sayonaraAssets.gameObject.SetActive(true);
        GameManager.playerInNovelOrSayonara = true;
        timePass.GetComponent<AudioSource>().StopWebGL();
    }
    public static void StopSayonara() {
        
        playerInNovelOrSayonara = false;
        sayonaraIntroController.gameObject.SetActive(false);

        if(sayonaraZeroSanityController.gameObject.activeSelf) {
            GameManager.SetTimeOfDay(currentTimeOfDay);
            sayonaraZeroSanityController.gameObject.SetActive(false);
        }
        if (sayonaraRitualController.gameObject.activeSelf) {
            sayonaraRitualController.gameObject.SetActive(false);
        }
        if (sayonaraBloodPressureController.gameObject.activeSelf) {
            sayonaraBloodPressureController.gameObject.SetActive(false);
        }

        sayonaraAssets.gameObject.SetActive(false);
    }

    public void Update() {

        if (GameManager.playerInBed) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, bedCameraTransform.position, 0.01f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, bedCameraTransform.rotation, 0.01f);

            blinkCamera.transform.position = Vector3.Lerp(blinkCamera.transform.position, bedCameraTransform.position, 0.01f);
            blinkCamera.transform.rotation = Quaternion.Lerp(blinkCamera.transform.rotation, bedCameraTransform.rotation, 0.01f);
        }

        // activate cheat mode
        if (Input.GetKey(KeyCode.C)
        && (Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))) {
            GameManager.ShowMessage("Cheat: activate cheats");
            GameManager.gameManagerObj.GetComponent<GameManager>().cheatMode = true;
            // GameManager.StartSayonara(SayonaraType.SayonaraRitual);
        }
        if (cheatMode == true) {

            // skip intro novel
            if (Input.GetKey(KeyCode.G)
            && (Input.GetKeyDown(KeyCode.F4) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))) {
                GameManager.ShowMessage("Cheat: skip intro novel. this cheat can be buggy");
                GameManager.mainMenuMusic.SetActive(false);
                GameManager.SetTimeOfDay(TimeOfDay.Morning);
                StopSayonara();
                StopNovel();
                timePass.SetActive(false);
            }

            // set date
            if (Input.GetKey(KeyCode.G)
            && (Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))) {
                GameManager.ShowMessage("Cheat: goTo Morning");
                GameManager.SetTimeOfDay(TimeOfDay.Morning);
            }
            if (Input.GetKey(KeyCode.G)
            && (Input.GetKeyDown(KeyCode.F2) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))) {
                GameManager.ShowMessage("Cheat: goTo evening");
                GameManager.SetTimeOfDay(TimeOfDay.Evening);
            }
            if (Input.GetKey(KeyCode.G)
            && (Input.GetKeyDown(KeyCode.F3) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))) {
                GameManager.ShowMessage("Cheat: goTo midnight");
                GameManager.SetTimeOfDay(TimeOfDay.Midnight);
            }
            if (Input.GetKey(KeyCode.G)
            && (Input.GetKeyDown(KeyCode.F7) || Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))) {
                GameManager.ShowMessage("Cheat: goTo day 2");
                GameManager.SetDay(DayOfWeek.DayTwo);
            }

            // progress
            if (Input.GetKey(KeyCode.J)
            && (Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))) {
                GameManager.ShowMessage("Cheat: learn all steps of the ritual");
                GameManager.knowsStepOne = true;
                GameManager.knowsStepTwo = true;
                GameManager.knowsStepThree = true;
            }

            if (Input.GetKey(KeyCode.H)
            && (Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))) {
                GameManager.numberOfTherapists += 1;
                GameManager.ShowMessage("Cheat: numberOfTherapist is now " + GameManager.numberOfTherapists);
            }
            if (Input.GetKey(KeyCode.H)
            && (Input.GetKeyDown(KeyCode.F2) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))) {
                GameManager.numberOfGroups += 1;
                GameManager.ShowMessage("Cheat: numberOfGroups is now " + GameManager.numberOfGroups);
            }
            if (Input.GetKey(KeyCode.H)
            && (Input.GetKeyDown(KeyCode.F3) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))) {
                GameManager.numberOfPrayer += 1;
                GameManager.ShowMessage("Cheat: numberOfPrayer is now " + GameManager.numberOfPrayer);
            }

            if (Input.GetKey(KeyCode.J)
            && (Input.GetKeyDown(KeyCode.F3) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))) {
                GameManager.IncreaseSanity();
                GameManager.ShowMessage("Cheat: IncreaseSanity");
            }
            if (Input.GetKey(KeyCode.J)
            && (Input.GetKeyDown(KeyCode.F2) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))) {
                GameManager.DecreaseSanity();
                GameManager.ShowMessage("Cheat: DecreaseSanity");
            }

            if (Input.GetKey(KeyCode.J)
            && (Input.GetKeyDown(KeyCode.F5) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))) {
                GoToOutro();
                GameManager.ShowMessage("Cheat: change lighting + go to outro world");
            }
            if (Input.GetKey(KeyCode.K)
            && (Input.GetKeyDown(KeyCode.F3) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))) {
                //foodQuestionnaire.GetComponent<FoodQuestionare>().PlayerGiveMealBreakfast();
                //foodQuestionnaire.GetComponent<FoodQuestionare>().PlayerGiveMealDinner();
                foodQuestionnaire.GetComponent<FoodQuestionare>().CheatGiveEverything();
                GameManager.ShowMessage("Cheat: Give player food");
            }
            if (Input.GetKey(KeyCode.K)
            && (Input.GetKeyDown(KeyCode.F4) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))) {
                //foodQuestionnaire.GetComponent<FoodQuestionare>().PlayerGiveMealBreakfast();
                //foodQuestionnaire.GetComponent<FoodQuestionare>().PlayerGiveMealDinner();
                GameManager.ShowMessage("Cheat: become hungry");
                PlayerEatingManager.ResetStomackSize();
            }
        }
    }
    public static AudioSource SpawnLoudAudio(AudioClip newAudioClip, Vector2 pitch = new Vector2(), float newVolume = 1f) {

        float sfxPitch;
        if (pitch.x <= 0.1f) {
            sfxPitch = 1;
        } else {
            sfxPitch = Random.Range(pitch.x, pitch.y);
        }

        AudioSource audioObject = pool_LoudAudioSource.Spawn(new Vector3(0f, 0f, 0f)).GetComponent<AudioSource>();
        audioObject.GetComponent<AudioSource>().pitch = sfxPitch;
        audioObject.PlayWebGL(newAudioClip, newVolume);
        return audioObject;
        // audio object will set itself to inactive after done playing.
    }
}
