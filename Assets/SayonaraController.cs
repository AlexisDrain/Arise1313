using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SayonaraController : MonoBehaviour
{
    public bool sayonaraTutorial = true;
    public bool sayonaraTransition = false;
    public float healthDepletionRate = 0.01f;
    public Image sayonaraBar1;
    public Image sayonaraBar2;
    public GameObject sayonaraTutorialText;
    public AudioSource scaryMusic;

    [Header("Read me")]
    public float _sayonaraHealth = 0.6f;
    

    void OnEnable() {
        _sayonaraHealth = 0.6f;

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
            // gameObject.SetActive(false);
            GameManager.KillPlayer();
            GameManager.StopSayonara();
        }
        if(_sayonaraHealth >= 0.99f) {
            // gameObject.SetActive(false);
            StartCoroutine("EndSayonara");
        }
    }
    private IEnumerator EndSayonara() {
        sayonaraTransition = true;
        yield return new WaitForSeconds(1.5f);
        GameManager.FadeInThenOut();
        yield return new WaitForSeconds(0.5f);
        GameManager.StopSayonara();
        sayonaraTransition = false;
    }
    public void GiveHealth() {
        _sayonaraHealth += 0.2f;
    }
    public void RemoveHealth() {
        _sayonaraHealth -= 0.1f;
    }

}
