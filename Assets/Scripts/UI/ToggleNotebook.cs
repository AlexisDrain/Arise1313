using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleNotebook : MonoBehaviour
{
    private GameObject quests;
    private GameObject notebook;
    void Start()
    {
        quests = GameObject.Find("Quests");
        quests.SetActive(false);
        notebook = GameObject.Find("Notebook");
        notebook.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ToggleNotebook")) {
            if(quests.activeSelf == false) {
                quests.SetActive(true);
                notebook.SetActive(true);
            } else if (quests.activeSelf == true) {
                quests.SetActive(false);
                notebook.SetActive(false);
            }
        }
    }
}
