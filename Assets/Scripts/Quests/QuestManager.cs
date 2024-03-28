using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class QuestManager : MonoBehaviour {

    public Transform questListParent;
    public List<GameObject> totalQuests = new List<GameObject>();

    [Header("Read only")]
    public Sprite unsolvedQuestIconSprite;
    public Sprite solvedQuestIconSprite;
    public Color solvedQuestColor = Color.gray;
    public List<GameObject> _activeQuests = new List<GameObject>();
    void Awake()
    {
        // DeactivateAllQuests();
    }

    public void DeactivateAllQuests() {
        print("remove this function once the quest system is finished");
        for (int i = 0; i < questListParent.childCount; i++) {
            questListParent.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void CreateNewQuest(string questHash) {
        /*
        TODO: repeated quest. set first
        for (int i = 0; i <= questListParent.childCount - 1; i++) {
            if (questListParent.GetChild(i).GetComponent<QuestItem>().questHash == questHash) {
                //questListParent.GetChild(i).GetComponent<QuestItem>().StartQuest("Get breakfast from the kitchen."); // this resets the quest
                //questListParent.GetChild(i).SetAsFirstSibling();
                //return;
            }
        }
        */

        if (questHash == "q_breakfast3") {
            GameObject newQuest = GameObject.Instantiate(totalQuests[0], questListParent);
            newQuest.GetComponent<QuestItem>().StartQuest("Get breakfast from the kitchen.");
            _activeQuests.Add(newQuest);
        }
        else if (questHash == "q_goToGroupMorn") {
            GameObject newQuest = GameObject.Instantiate(totalQuests[0], questListParent);
            newQuest.GetComponent<QuestItem>().StartQuest("Go to group OR go to 1-on-1 therapist meeting.");
            // GameManager.ShowMessage("A new quest! Press Tab to read it.");
            _activeQuests.Add(newQuest);
        }
    }

    public void SolveQuest(string questHash) {
        for (int i = 0; i <= _activeQuests.Count - 1; i++) {
            if (_activeQuests[i].GetComponent<QuestItem>().questHash == questHash) {
                _activeQuests[i].GetComponent<QuestItem>().SolveQuest();
                return;
            }
        }
    }

}
