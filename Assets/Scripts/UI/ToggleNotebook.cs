using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNotebook : MonoBehaviour
{
    private GameObject quests;
    private GameObject notebook;
    void Start()
    {
        quests = transform.Find("Quests").gameObject;
        quests.SetActive(false);
        notebook = transform.Find("Notebook").gameObject;
        notebook.SetActive(false);
        GameManager.playerInNotebook = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleNotebook")) {
            if(quests.activeSelf == false) {
                quests.SetActive(true);
                notebook.SetActive(true);
                GameManager.playerInNotebook = true;
            } else if (quests.activeSelf == true) {
                quests.SetActive(false);
                notebook.SetActive(false);
                GameManager.playerInNotebook = false;
            }
        }
    }
}
