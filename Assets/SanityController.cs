using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityController : MonoBehaviour
{
    public Image sanity3;
    public Image sanity2;
    public Image sanity1;
    public Image sanity0;
    public GameObject sanity0Effect;
    void Awake()
    {
        // myAnim = GetComponent<Animator>();
        UpdateImage();
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

    public void IncreaseSanity()
    {
        gameObject.SetActive(true);

        GameManager.sanityHealth += 1;
        GameManager.sanityHealth = Mathf.Clamp(GameManager.sanityHealth, 0, 3);
        UpdateImage();

        StopCoroutine("DisapearSanity");
        StartCoroutine("DisapearSanity");
    }
    public void DecreaseSanity() {
        gameObject.SetActive(true);

        GameManager.sanityHealth -= 1;
        GameManager.sanityHealth = Mathf.Clamp(GameManager.sanityHealth, 0, 3);
        UpdateImage();

        StopCoroutine("DisapearSanity");
        StartCoroutine("DisapearSanity");
    }

    private IEnumerator DisapearSanity() {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
