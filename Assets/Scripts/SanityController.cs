using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class SanityController : MonoBehaviour
{
    public AudioClip sanityUpSFX;
    public AudioClip sanityDownSFX;
    public TextMeshProUGUI sanityChangeText;
    public Image sanity3;
    public Image sanity2;
    public Image sanity1;
    public Image sanity0;
    public GameObject sanity0Effect;

    private Animator myAnim;
    public Image sanityFadeMe;

    void Awake()
    {
        myAnim = GetComponent<Animator>();
        UpdateImage();
    }
    private void Update() {
        if (sanityFadeMe.color.a >= 0.001f) {
            float newAlpha = Mathf.Lerp(sanityFadeMe.color.a, 0f, 0.01f);
            sanityFadeMe.color = new Color(sanityFadeMe.color.r, sanityFadeMe.color.g, sanityFadeMe.color.b, newAlpha);
        }
    }
    

    public void UpdateImage() {
        sanity3.enabled = false;
        sanity2.enabled = false;
        sanity1.enabled = false;
        sanity0.enabled = false;
        sanity0Effect.SetActive(false);

        if (GameManager.sanityHealth == 0) {
            sanity0.enabled = true;
            sanity0Effect.SetActive(true);
        } else if (GameManager.sanityHealth == 1) {
            sanity1.enabled = true;
        } else if (GameManager.sanityHealth == 2) {
            sanity2.enabled = true;
        } else if (GameManager.sanityHealth == 3) {
            sanity3.enabled = true;
        }

    }
    private void SanityFade(int oldImage) {
        if (oldImage == 0) {
            sanityFadeMe.sprite = sanity0.sprite;
        } else if (oldImage == 1) {
            sanityFadeMe.sprite = sanity1.sprite;
        } else if (oldImage == 2) {
            sanityFadeMe.sprite = sanity2.sprite;
        } else if (oldImage == 3) {
            sanityFadeMe.sprite = sanity3.sprite;
        }
        sanityFadeMe.color = new Color(1f, 1f, 1f, 1f);
    }
    public void IncreaseSanity()
    {
        gameObject.SetActive(true);

        SanityFade(GameManager.sanityHealth);

        GameManager.sanityHealth += 1;
        GameManager.sanityHealth = Mathf.Clamp(GameManager.sanityHealth, 0, 3);
        sanityChangeText.text = "<color=#00FF00>Sanity +1</color>";
        myAnim.SetTrigger("ChangeSanityUp");
        GameManager.SpawnLoudAudio(sanityUpSFX);
        UpdateImage();

        StopCoroutine("DisapearSanity");
        StartCoroutine("DisapearSanity");
    }
    public void DecreaseSanity() {
        gameObject.SetActive(true);

        SanityFade(GameManager.sanityHealth);

        GameManager.sanityHealth -= 1;
        GameManager.sanityHealth = Mathf.Clamp(GameManager.sanityHealth, 0, 3);
        sanityChangeText.text = "<color=#FF0000>Sanity -1</color>";
        myAnim.SetTrigger("ChangeSanityDown");
        GameManager.SpawnLoudAudio(sanityDownSFX);
        UpdateImage();

        StopCoroutine("DisapearSanity");
        StartCoroutine("DisapearSanity");
    }
    public void DecreaseSanityTwice() {
        gameObject.SetActive(true);

        SanityFade(GameManager.sanityHealth);

        GameManager.sanityHealth -= 2;
        GameManager.sanityHealth = Mathf.Clamp(GameManager.sanityHealth, 0, 3);
        sanityChangeText.text = "<color=#FF0000>Sanity -2</color>";
        myAnim.SetTrigger("ChangeSanityDown");
        GameManager.SpawnLoudAudio(sanityDownSFX);
        UpdateImage();

        StopCoroutine("DisapearSanity");
        StartCoroutine("DisapearSanity");
    }

    private IEnumerator DisapearSanity() {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
