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

public enum PlayerProgress {
    PlayerInNovelIntroFirstTime,

}

public class GameManager : MonoBehaviour
{
    public static GameObject gameManagerObj;
    public static QuestManager questManager;
    public static Transform player;
    public static SayonaraController sayonaraController;
    public static StoryType storyType;
    public static Camera mainCamera;
    public static Camera blinkCamera;
    public static BlinkController blinkController;
    public static DisplayUseText displayUseText;

    // canvas
    //public static GameObject dream;
    public static GameObject foodQuestionnaire; 
    public static GameObject tutorialControls;
    public static GameObject tabMenu;
    public static GameObject inventory;
    public static InventoryTooltip invTooltip;
    public static GameObject imageScreenTransition;
    public static GameObject timePass;
    
    public static Transform bedCameraTransform;
    public static Transform playerAwakeTrans;
    public static Transform playerStartTrans;

    private static Pool pool_LoudAudioSource;

    public static PlayerProgress currentPlayerProgress = PlayerProgress.PlayerInNovelIntroFirstTime;
    public static TimeOfDay currentTimeOfDay;
    // ritual
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
    public bool cheatMode = true;

    public static LayerMask worldMask;
    public static LayerMask entityMask;
    public static LayerMask triggersMask;

    public static UnityEvent changeTimeOfDayEvent = new UnityEvent();
    public static UnityEvent EyesClosedEvent = new UnityEvent();
    public static UnityEvent EyesOpenEvent = new UnityEvent();

    void Awake() {
        gameManagerObj = gameObject;
        questManager = GetComponent<QuestManager>();
        player = GameObject.Find("Player").transform;
        sayonaraController = GameObject.Find("Canvas/Sayonara").GetComponent<SayonaraController>();
        sayonaraController.gameObject.SetActive(false);
        storyType = GameObject.Find("Canvas/IntroNovel").GetComponent<StoryType>();
        storyType.gameObject.SetActive(false);
        mainCamera = GameObject.Find("Player/CamDolly/MainCam").GetComponent<Camera>();
        blinkCamera = GameObject.Find("Player/CamDolly/BlinkCam").GetComponent<Camera>();
        blinkController = GameObject.Find("CanvasEye/EyeBlink").GetComponent<BlinkController>();
        displayUseText = GameObject.Find("Canvas/UseTextBG").GetComponent<DisplayUseText>();

        // canvas
        //dream = GameObject.Find("Canvas/Dream");
        //dream.gameObject.SetActive(false);
        foodQuestionnaire = GameObject.Find("Canvas/FoodQuestionnaire");
        foodQuestionnaire.gameObject.SetActive(false);
        tutorialControls = GameObject.Find("Canvas/Tutorial_Controls");
        tabMenu = GameObject.Find("Canvas/TabMenu");
        //tabMenu.gameObject.SetActive(false);
        inventory = GameObject.Find("Canvas/TabMenu/Inventory");
        invTooltip = GameObject.Find("Canvas/TabMenu/InventoryTooltip").GetComponent<InventoryTooltip>();
        imageScreenTransition = GameObject.Find("ScreenTransition");
        timePass = GameObject.Find("Canvas/TimePass");
        timePass.SetActive(false);
        
        bedCameraTransform = GameObject.Find("BedCamera").transform;
        playerAwakeTrans = GameObject.Find("PlayerAwakeTrans").transform;
        playerStartTrans = GameObject.Find("PlayerStartTrans").transform;
        pool_LoudAudioSource = transform.Find("pool_LoudAudioSource").GetComponent<Pool>();

        worldMask = LayerMask.NameToLayer("World");
        entityMask = LayerMask.NameToLayer("Entity");
        triggersMask = LayerMask.NameToLayer("Triggers");

        SetTimeOfDay(TimeOfDay.Morning);

        // Time.timeScale = 0f;
    }
    private void Start() {
        
        // GameManager.NewGame(); done in Main Menu
    }

    public static void FadeInThenOut() {
        imageScreenTransition.GetComponent<Animator>().SetTrigger("FadeInThenOut");
    }

    public static void ShowMessage(string newMessageText) {
        Transform message = GameObject.Find("Canvas/Message").transform;
        message.Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = newMessageText;
        message.GetComponent<Animator>().SetTrigger("MessageFade");
    }

    public static void SetTimeOfDay(TimeOfDay newTimeOfDay) {
        currentTimeOfDay = newTimeOfDay;

        changeTimeOfDayEvent.Invoke();

        timePass.SetActive(true); // cutscene object

        Image iconMorning = GameObject.Find("Canvas/TabMenu/IconTime/IconTime_Morning").GetComponent<Image>();
        Image iconEvening = GameObject.Find("Canvas/TabMenu/IconTime/IconTime_Evening").GetComponent<Image>();
        Image iconMidNight = GameObject.Find("Canvas/TabMenu/IconTime/IconTime_Midnight").GetComponent<Image>();
        TMPro.TextMeshProUGUI iconTime = GameObject.Find("Canvas/TabMenu/IconTime/TimeDigital").GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI iconTimeCutscene = timePass.transform.Find("TimeDigital").GetComponent<TMPro.TextMeshProUGUI>();

        if (newTimeOfDay == TimeOfDay.Morning) {
            timePass.GetComponent<Animator>().SetTrigger("SetMorning");
            iconTime.text = "08:00 AM";
            iconTimeCutscene.text = "08:00 AM";
            iconMorning.enabled = true;
            iconEvening.enabled = false;
            iconMidNight.enabled = false;
            questManager.CreateNewQuest("breakfast3");

        } else if (newTimeOfDay == TimeOfDay.Evening) {

            timePass.GetComponent<Animator>().SetTrigger("SetEve");
            iconTime.text = "04:00 PM";
            iconTimeCutscene.text = "04:00 PM";
            iconMorning.enabled = false;
            iconEvening.enabled = true;
            iconMidNight.enabled = false;
        } else if (newTimeOfDay == TimeOfDay.Midnight) {
            timePass.GetComponent<Animator>().SetTrigger("SetNight");
            iconTime.text = "11:00 PM";
            iconTimeCutscene.text = "11:00 PM";
            iconMorning.enabled = false;
            iconEvening.enabled = false;
            iconMidNight.enabled = true;
        }

    }

    // sleeping is handled in FillFKey script

    public static void PlayerGoToBed() {
        GameManager.playerInBed = true;
        GameManager.player.Find("Img").GetComponent<SpriteRenderer>().enabled = false;
    }
    public static void PlayerDream() {
        storyType.StartRandomNightmare();

    }
    public static void PlayerLeaveBed() {
        SetTimeOfDay(TimeOfDay.Midnight);

        GameManager.playerInBed = false;
        GameManager.playerGotBreakfast = false;
        GameManager.playerGotDinner = false;
        GameManager.player.Find("Img").GetComponent<SpriteRenderer>().enabled = true;

        GameManager.player.position = GameManager.playerAwakeTrans.position;
        GameManager.player.GetComponent<Rigidbody>().position = GameManager.playerAwakeTrans.position;
        GameManager.player.rotation = GameManager.playerAwakeTrans.rotation;
        GameManager.player.GetComponent<Rigidbody>().rotation = GameManager.playerAwakeTrans.rotation;

        mainCamera.transform.position = GameObject.Find("Player/CamDolly").transform.position;
        mainCamera.transform.rotation = GameObject.Find("Player/CamDolly").transform.rotation;

        blinkCamera.transform.position = GameObject.Find("Player/CamDolly").transform.position;
        blinkCamera.transform.rotation = GameObject.Find("Player/CamDolly").transform.rotation;
    }
    public static void KillPlayer() {
        GameManager.player.position = GameManager.playerAwakeTrans.position;
        GameManager.player.GetComponent<Rigidbody>().position = GameManager.playerAwakeTrans.position;
        GameManager.player.rotation = GameManager.playerAwakeTrans.rotation;
        GameManager.player.GetComponent<Rigidbody>().rotation = GameManager.playerAwakeTrans.rotation;

        print("kill player");

        if(GameManager.currentPlayerProgress == PlayerProgress.PlayerInNovelIntroFirstTime) {
            playerInNovelOrSayonara = true;
            GameManager.NewGame();
        }
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
    public static void NewGame() {
        gameManagerObj.GetComponent<QuestManager>().CreateNewQuest("q_goToGroupMorn");
        gameHasBeenStartedOnce = true;
        playerInNovelOrSayonara = true;
        playerInMainMenu = false;
        if (GameManager.currentPlayerProgress == PlayerProgress.PlayerInNovelIntroFirstTime) {
            GameManager.StartNovel();
        }

        GameManager.player.position = GameManager.playerStartTrans.position;
        GameManager.player.GetComponent<Rigidbody>().position = GameManager.playerStartTrans.position;
        GameManager.player.rotation = GameManager.playerStartTrans.rotation;
        GameManager.player.GetComponent<Rigidbody>().rotation = GameManager.playerStartTrans.rotation;
    }
    public static void StartFoodQuestionnaire() {
        // remove tutorial:
        tutorialControls.SetActive(false);

        GameManager.foodQuestionnaire.SetActive(true);
        playerInFoodQuestionnaire = true;
    }
    public static void StopFoodQuestionnaire() {
        GameManager.foodQuestionnaire.SetActive(false);
        playerInFoodQuestionnaire = false;
    }

    public static void StartNovel(string newStoryKnot = "") {
        playerInNovelOrSayonara = true;
        if(newStoryKnot == "") {
            storyType.NovelStartFromIntro();
        } else {
            storyType.StartNovelKnot(newStoryKnot);
        }
    }
    public static void StopNovel() {
        storyType.gameObject.SetActive(false);
        playerInNovelOrSayonara = false;
    }
    public static void StartSayonara() {
        sayonaraController.gameObject.SetActive(true);
        playerInNovelOrSayonara = true;
    }
    public static void StopSayonara() {
        sayonaraController.gameObject.SetActive(false);
        if (GameManager.currentPlayerProgress == PlayerProgress.PlayerInNovelIntroFirstTime) {
            GameManager.StartNovel();
        }
    }

    public void Update() {

        if (GameManager.playerInBed) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, bedCameraTransform.position, 0.01f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, bedCameraTransform.rotation, 0.01f);

            blinkCamera.transform.position = Vector3.Lerp(blinkCamera.transform.position, bedCameraTransform.position, 0.01f);
            blinkCamera.transform.rotation = Quaternion.Lerp(blinkCamera.transform.rotation, bedCameraTransform.rotation, 0.01f);
        }

        if (cheatMode == true) {
            //if (Input.GetKey(KeyCode.G)
            //&& (Input.GetKeyDown(KeyCode.F3) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))) {
            //    playerInBed = !playerInBed;
            //}
            if (Input.GetKey(KeyCode.G)
            && (Input.GetKeyDown(KeyCode.F4) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))) {
                StopSayonara();
                StopNovel();
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
