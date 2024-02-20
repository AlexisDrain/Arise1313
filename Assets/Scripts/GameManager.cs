using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public enum TimeOfDay {
    Morning,
    Evening,
    Midnight
}

public class GameManager : MonoBehaviour
{
    public static GameObject gameManagerObj;
    public static Transform player;
    public static Camera mainCamera;
    public static Camera blinkCamera;
    public static BlinkController blinkController;
    public static DisplayUseText displayUseText;
    
    public static Transform bedCameraTransform;
    public static Transform playerAwakeTrans;

    private static Pool pool_LoudAudioSource;

    public static TimeOfDay currentTimeOfDay;
    public static bool playerInBed = false;
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
        player = GameObject.Find("Player").transform;
        mainCamera = GameObject.Find("Player/CamDolly/MainCam").GetComponent<Camera>();
        blinkCamera = GameObject.Find("Player/CamDolly/BlinkCam").GetComponent<Camera>();
        blinkController = GameObject.Find("CanvasEye/EyeBlink").GetComponent<BlinkController>();
        displayUseText = GameObject.Find("Canvas/UseTextBG").GetComponent<DisplayUseText>();

        bedCameraTransform = GameObject.Find("BedCamera").transform;
        playerAwakeTrans = GameObject.Find("PlayerAwakeTrans").transform;

        pool_LoudAudioSource = transform.Find("pool_LoudAudioSource").GetComponent<Pool>();

        worldMask = LayerMask.NameToLayer("World");
        entityMask = LayerMask.NameToLayer("Entity");
        triggersMask = LayerMask.NameToLayer("Triggers");

        SetTimeOfDay(TimeOfDay.Evening);

        // Time.timeScale = 0f;
        //NewGame();
    }
    public static void SetTimeOfDay(TimeOfDay newTimeOfDay) {
        currentTimeOfDay = newTimeOfDay;

        changeTimeOfDayEvent.Invoke();

        Image iconMorning = GameObject.Find("Canvas/IconTime/IconTime_Morning").GetComponent<Image>();
        Image iconEvening = GameObject.Find("Canvas/IconTime/IconTime_Evening").GetComponent<Image>();
        Image iconMidNight = GameObject.Find("Canvas/IconTime/IconTime_Midnight").GetComponent<Image>();

        if (newTimeOfDay == TimeOfDay.Morning) {
            iconMorning.enabled = true;
            iconEvening.enabled = false;
            iconMidNight.enabled = false;
        } else if (newTimeOfDay == TimeOfDay.Evening) {
            iconMorning.enabled = false;
            iconEvening.enabled = true;
            iconMidNight.enabled = false;
        } else if (newTimeOfDay == TimeOfDay.Midnight) {
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
    public static void PlayerLeaveBed() {
        GameManager.playerInBed = false;
        SetTimeOfDay(TimeOfDay.Midnight);
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
        GameManager.player.position = GameManager.bedCameraTransform.position;
        print("kill player");
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
    public static void StopSayonara() {
        print("Stop sayonara");
    }
    public void Update() {

        if (GameManager.playerInBed) {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, bedCameraTransform.position, 0.01f);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, bedCameraTransform.rotation, 0.01f);

            blinkCamera.transform.position = Vector3.Lerp(blinkCamera.transform.position, bedCameraTransform.position, 0.01f);
            blinkCamera.transform.rotation = Quaternion.Lerp(blinkCamera.transform.rotation, bedCameraTransform.rotation, 0.01f);
        }

        if (cheatMode == true) {
            // one level back
            if (Input.GetKey(KeyCode.G)
            && (Input.GetKeyDown(KeyCode.F3) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))) {
                playerInBed = !playerInBed;
            }

        }
    }
    /*
    public static void RevivePlayer() {
        playerIsAlive = true;
        GameManager.canvasDeath.SetActive(false);
        GameManager.player.GetComponent<PlayerController>().graphicGirl.SetActive(true);
        GameManager.player.GetComponent<PlayerController>().graphicGirl.GetComponent<Animator>().Rebind();
        player.GetComponent<PlayerEnemyCollision>().health = 3;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().rotation = playerCheckpoint.rotation;
        player.transform.rotation = playerCheckpoint.rotation;
        player.GetComponent<Rigidbody>().position = playerCheckpoint.position;
        player.transform.position = playerCheckpoint.position;

        GameManager.checkpointCameraBundle.gameObject.SetActive(true);

        playerRevive.Invoke();
    }
    */
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
    /*
    public void Update() {

        if (Input.GetButtonDown("Pause")) {
            if (gameIsPaused && gameHasBeenStartedOnce == true) {
                gameIsPaused = false;
                canvasMenu.SetActive(false);
                Time.timeScale = 1f;
            } else {
                gameIsPaused = true;
                canvasMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if (playerIsAlive == false) {
            if (Input.GetButtonDown("Revive") || Input.GetButtonDown("Jump")) {
                RevivePlayer();
            }
        } else {
            if (Input.GetButtonDown("Revive")) {
                print("player is not dead but pressed Revive");
                if (currentLevelInt != 13) { // Hack: 13 is the The End level
                    RevivePlayer();

                }
            }
        }

        if(cheatMode == true) {
            // one level back
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            && (Input.GetKeyDown(KeyCode.F1) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))) {
                currentLevelInt -= 1;
                GameManager.gameManagerObj.GetComponent<GameManager>().SetNewLevel(currentLevelInt);
            }
            // one level forward
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            && (Input.GetKeyDown(KeyCode.F2) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))) {
                currentLevelInt += 1;
                GameManager.gameManagerObj.GetComponent<GameManager>().SetNewLevel(currentLevelInt);
            }
            // new game
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                && (Input.GetKeyDown(KeyCode.F3) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))) {
                //NewGame();
            }
            // remove tutorial message
            if ((Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            && (Input.GetKeyDown(KeyCode.F4) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))) {
                GameManager.canvasTopRightTutorial.SetActive(false);
            }
        }
    }

    public IEnumerator ScreenTransition() {
        canvasScreenTransition.GetComponent<Animator>().SetTrigger("FadeInThenOut");
        yield return new WaitForSecondsRealtime(0.5f);
        SwitchLevel(currentLevelInt);
    }
    */
    public void NewGame() {
        gameHasBeenStartedOnce = true;

    }
    public void ResumeGame() {
        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }
}
