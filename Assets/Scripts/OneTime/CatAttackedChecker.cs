using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAttackedChecker : MonoBehaviour
{
    public GameObject oldInteract;
    public GameObject catAttackedInteract;
    void Start()
    {
        GameManager.changeTimeOfDayEvent.AddListener(ChangedDayCheckCat);
    }

    // Update is called once per frame
    void ChangedDayCheckCat()
    {
        if (GameManager.catAttacked || GameManager.catKilled) {
            oldInteract.gameObject.SetActive(false);
            catAttackedInteract.gameObject.SetActive(true);
        }
    }
}
