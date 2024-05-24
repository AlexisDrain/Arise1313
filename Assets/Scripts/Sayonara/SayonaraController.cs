using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SayonaraController : MonoBehaviour
{
    public Image imageHand;
    public Animator animFace;
    public Image sayonaraBar1;
    public Image sayonaraBar2;
    public GameObject text_getReady;
    public GameObject sayonaraTutorialText;
    public SpawnSayonara spawnSayonara;
    public AudioSource scaryMusic;

    [Header("Stuff to change for each minigame")]
    public bool sayonaraTutorial = true;
    public float waitBeforeStart = 2.5f;
    public float healthDepletionRate = 0.01f;
    public float healthStart = 0.6f;
    public float giveHealthAmount = 0.2f;
    public float loseHealthAmount = 0.1f;
    public float waitUntilRemoveDefault = 1.5f;
    public float waitUntilSpawnNewDefault = 1.5f;
    public bool hideKill = false;
    public bool disableBadWords = false;
    public bool disableGoodWords = false;

    [Header("Read only")]
    public float _sayonaraHealth = 0.6f;
    public bool _sayonaraTransition = false;
    private float waitBeforeStartCurrent = 0f;

    public UnityEvent onSayonaraGood;
    public UnityEvent onSayonaraBad;

    void OnEnable() {
        _sayonaraHealth = healthStart;
        imageHand.GetComponent<RectTransform>().anchoredPosition = new Vector2(537f, imageHand.GetComponent<RectTransform>().anchoredPosition.y);
        animFace.SetTrigger("NewSayonara");

        _sayonaraTransition = false;

        waitBeforeStartCurrent = waitBeforeStart;

        if (sayonaraTutorial == true) {
            sayonaraTutorialText.SetActive(true);
            text_getReady.SetActive(false);
        } else {
            sayonaraTutorialText.SetActive(false);
            text_getReady.SetActive(true);
        }
        if (hideKill == true) {
            imageHand.GetComponent<Image>().enabled = false;
        } else {
            imageHand.GetComponent<Image>().enabled = true;
        }
    }

    private void FixedUpdate() {
        if(_sayonaraTransition) {
            return;
        }

        sayonaraBar1.fillAmount = _sayonaraHealth;
        sayonaraBar2.fillAmount = _sayonaraHealth;

        // sayonara hand position. max: 725f. Death: 275f, start: 537f
            float handPosRange = (725f - 275f);
            float handPosValue = (_sayonaraHealth * handPosRange) + 275f;
            imageHand.GetComponent<RectTransform>().anchoredPosition
                = new Vector2(Mathf.Lerp(imageHand.GetComponent<RectTransform>().anchoredPosition.x, handPosValue, 0.1f), imageHand.GetComponent<RectTransform>().anchoredPosition.y);


        if (sayonaraTutorial == true) {
            return;
        }
        if(waitBeforeStartCurrent > 0f) {
            waitBeforeStartCurrent -= Time.deltaTime;
            return;
        }

        if (_sayonaraHealth > 0f) {
            _sayonaraHealth -= Time.deltaTime * healthDepletionRate;
            _sayonaraHealth = Mathf.Clamp(_sayonaraHealth, 0f, 1f);
        }

        // music
        if(_sayonaraHealth < 0.3f && scaryMusic.isPlaying == false) {
            scaryMusic.PlayWebGL();
        } else if (_sayonaraHealth > 0.3f && scaryMusic.isPlaying == true) {
            scaryMusic.StopWebGL();
        }

        if (_sayonaraHealth <= 0f) {
            sayonaraBar1.fillAmount = 0f;
            sayonaraBar2.fillAmount = 0f;
            StartCoroutine("KillPlayerSayonara");
        }
        if(_sayonaraHealth >= 0.99f) {
            sayonaraBar1.fillAmount = 1f;
            sayonaraBar2.fillAmount = 1f;
            StartCoroutine("EndSayonaraGood");
        }
    }
    private IEnumerator KillPlayerSayonara() {

        _sayonaraTransition = true;
        imageHand.GetComponent<RectTransform>().anchoredPosition
            = new Vector2(200f, imageHand.GetComponent<RectTransform>().anchoredPosition.y);

        spawnSayonara.DestroyAllMembers();
        if (hideKill == false) {
            animFace.SetTrigger("Die");
        }
        yield return new WaitForSeconds(1.5f);
        GameManager.FadeInThenOut();
        yield return new WaitForSeconds(0.5f);
        GameManager.StopSayonara();
        _sayonaraTransition = false;

        // GameManager.EndGame("You died, sparing youself from the eternal torture but not saving the world.", false);
        onSayonaraBad.Invoke();
    }
    private IEnumerator EndSayonaraGood() {
        _sayonaraTransition = true;
        yield return new WaitForSeconds(1.5f);
        GameManager.FadeInThenOut();
        yield return new WaitForSeconds(0.5f);
        GameManager.StopSayonara();
        _sayonaraTransition = false;
        onSayonaraGood.Invoke();
    }
    public void GiveHealth() {
        _sayonaraHealth += giveHealthAmount;
    }
    public void RemoveHealth() {
        _sayonaraHealth -= loseHealthAmount;
    }

}
