using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SayonaraController : MonoBehaviour
{
    public bool sayonaraTutorial = true;
    public bool sayonaraTransition = false;
    public float healthDepletionRate = 0.01f;
    public Image imageHand;
    public Animator animFace;
    public Image sayonaraBar1;
    public Image sayonaraBar2;
    public GameObject sayonaraTutorialText;
    public SpawnSayonara spawnSayonara;
    public AudioSource scaryMusic;

    [Header("Read only")]
    public float _sayonaraHealth = 0.6f;
    

    void OnEnable() {
        _sayonaraHealth = 0.6f;
        imageHand.GetComponent<RectTransform>().anchoredPosition = new Vector2(537f, imageHand.GetComponent<RectTransform>().anchoredPosition.y);
        animFace.SetTrigger("NewSayonara");

        sayonaraTransition = false;
        sayonaraTutorial = true;
        //if (sayonaraTutorial == true) {
        sayonaraTutorialText.SetActive(true);
        //}
    }

    private void FixedUpdate() {
        if(sayonaraTransition) {
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

        sayonaraTransition = true;
        imageHand.GetComponent<RectTransform>().anchoredPosition
            = new Vector2(200f, imageHand.GetComponent<RectTransform>().anchoredPosition.y);

        spawnSayonara.DestroyAllMembers();
        animFace.SetTrigger("Die");
        yield return new WaitForSeconds(1.5f);
        GameManager.FadeInThenOut();
        yield return new WaitForSeconds(0.5f);
        // GameManager.KillPlayer();
        GameManager.StopSayonara();
        sayonaraTransition = false;

        GameManager.EndGame("You died, sparing youself from the eternal torture but not saving the world.", false);
    }
    private IEnumerator EndSayonaraGood() {
        sayonaraTransition = true;
        yield return new WaitForSeconds(1.5f);
        GameManager.FadeInThenOut();
        yield return new WaitForSeconds(0.5f);
        GameManager.StopSayonara();
        GameManager.StartNovel();
        sayonaraTransition = false;
    }
    public void GiveHealth() {
        _sayonaraHealth += 0.2f;
    }
    public void RemoveHealth() {
        _sayonaraHealth -= 0.1f;
    }

}
