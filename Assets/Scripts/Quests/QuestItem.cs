using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestItem : MonoBehaviour
{
    public string questHash = "breakfast3";

    [Header("Set once")]
    public Image questIcon;
    public TextMeshProUGUI text;
    public Color solvedQuestColor = Color.gray;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartQuest(string newQuestText)
    {
        //TODO: repeated quest. set first in QuestManager
        text.text = newQuestText;
        questIcon.sprite = GameManager.questManager.unsolvedQuestIconSprite;
    }
    public void SolveQuest() {
        text.color = GameManager.questManager.solvedQuestColor;
        questIcon.sprite = GameManager.questManager.solvedQuestIconSprite;
    }
}
