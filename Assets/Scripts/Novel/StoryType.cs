using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class StoryType : MonoBehaviour
{

    [SerializeField]
    private TextAsset inkJSONAsset = null;
    public List<int> collectedNightmares = new List<int>();
    public Story inkStory;

    private string finalText = "";
    public TextMeshProUGUI myText;
    private Canvas myCanvas;

    private void Start() {
        inkStory = new Story(inkJSONAsset.text);

        myText.text = "";
        myText.enabled = true; // disabled in the editor and enabled here so that the first frame doesn't show the full text
    }

    public void StartRandomNightmare() {


        // random nightmare
        if(collectedNightmares.Count == 2) {
            collectedNightmares.Clear();
        }
        List<int> notInNightmare = new List<int>();
        for (int i = 0; i < 2;  i++) {
            if(collectedNightmares.Contains(i)== false) {
                notInNightmare.Add(i);
            }
        }
        int randNum = Random.Range(0, notInNightmare.Count);
        int randNightmare = notInNightmare[randNum];
        collectedNightmares.Add(randNightmare);

        // type story
        myText.text = "";
        finalText = "";
        inkStory.ChoosePathString("dream_" + randNightmare);
        while (inkStory.canContinue) {
            inkStory.Continue();
            finalText += inkStory.currentText + "\n";
        }

        StopCoroutine("Typewriter");
        StartCoroutine("Typewriter");
    }
    public void DisableCanvas() {
        StopCoroutine("Typewriter");
        myText.text = "";
        myCanvas.enabled = false;
    }
    IEnumerator Typewriter() {
        myText.text = "";

        foreach (char c in finalText) {
            //if (c != ' ' || c != '\n') {
            //    textAudioSource.Play();
            //}
            myText.text += c;
            yield return new WaitForSeconds(.01f);
        }
        yield return new WaitForSeconds(3f);
        print("Enable buttons");
    }

}
