using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using TMPro;

public class SpawnSayonara : MonoBehaviour {

    public SayonaraController sayonaraController;

    public List<string> sayoGoodWords = new List<string>();
    public List<string> sayoBadWords = new List<string>();
    public GameObject sayoGoodButton;
    public GameObject sayoBadButton;
    public Vector2 randXPos = new Vector2(0f, 1920f);
    public Vector2 randYPos = new Vector2(0f, 1080f);
    public float minimumButtonDistances = 150f;

    public float waitUntilSpawnNewDefault = 1.5f;
    private float waitUntilSpawnNewCurrent = 0f;

    [Header("Read only")]
    public List<Vector2> _previousSpawnPositions = new List<Vector2>();

    private int previousIndexGood;
    private int previousIndexBad;

    void OnEnable()
    {
        DestroyAllMembers();
        SpawnTutorial();
    }
    public Vector2 GenerateNewPosition() {
        Vector2 randPosition = new Vector2(Random.Range(randXPos.x, randXPos.y), Random.Range(randYPos.x, randYPos.y));

        for (int i = 0; i < _previousSpawnPositions.Count; i++) {
            if (Vector2.Distance(_previousSpawnPositions[i], randPosition) < minimumButtonDistances) {
                randPosition = new Vector2(Random.Range(randXPos.x, randXPos.y), Random.Range(randYPos.x, randYPos.y));
                i = 0;
            }
        }
        _previousSpawnPositions.Add(randPosition);
        if (_previousSpawnPositions.Count > 6f) {
            _previousSpawnPositions.RemoveAt(0);
        }
        return randPosition;
    }
    public void SpawnTutorial() {
        GameObject obj1 = GameObject.Instantiate(sayoGoodButton, transform);
        previousIndexGood = 0;
        Vector2 setPosition = new Vector2(500f, -500f);
        _previousSpawnPositions.Add(setPosition);
        obj1.GetComponent<TextMeshProUGUI>().text = sayoGoodWords[0];
        obj1.GetComponent<RectTransform>().anchoredPosition = setPosition;
        obj1.GetComponent<ButtonShake>().UpdateNewLocation(obj1.transform.position);


        GameObject obj2 = GameObject.Instantiate(sayoBadButton, transform);
        previousIndexBad = 0;
        setPosition = new Vector2(1100f, -500f);
        _previousSpawnPositions.Add(setPosition);
        obj2.GetComponent<TextMeshProUGUI>().text = sayoBadWords[0];
        obj2.GetComponent<RectTransform>().anchoredPosition = setPosition;
        obj2.GetComponent<ButtonShake>().UpdateNewLocation(obj2.transform.position);
    }
    public void SpawnGood() {

        int randIndex = Random.Range(0, sayoGoodWords.Count);
        while (randIndex == previousIndexGood) {
            randIndex = Random.Range(0, sayoGoodWords.Count);
        }

        GameObject obj = GameObject.Instantiate(sayoGoodButton, transform);
        obj.SetActive(true);

        previousIndexGood = randIndex;

        Vector2 randPosition = GenerateNewPosition();

        obj.GetComponent<TextMeshProUGUI>().text = sayoGoodWords[randIndex];
        obj.GetComponent<RectTransform>().anchoredPosition = randPosition;
        obj.GetComponent<ButtonShake>().UpdateNewLocation(obj.transform.position);
    }
    public void SpawnBad() {

        int randIndex = Random.Range(0, sayoBadWords.Count);
        while (randIndex == previousIndexBad) {
            randIndex = Random.Range(0, sayoBadWords.Count);
        }

        GameObject obj = GameObject.Instantiate(sayoBadButton, transform);
        obj.SetActive(true);

        previousIndexBad = randIndex;

        Vector2 randPosition = GenerateNewPosition();

        obj.GetComponent<TextMeshProUGUI>().text = sayoBadWords[randIndex];
        obj.GetComponent<RectTransform>().anchoredPosition = randPosition;
        obj.GetComponent<ButtonShake>().UpdateNewLocation(obj.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (sayonaraController.sayonaraTutorial == true || sayonaraController.sayonaraTransition) {
            return;
        }

        if(waitUntilSpawnNewCurrent > 0f) {
            waitUntilSpawnNewCurrent -= Time.deltaTime;
        } else {
            waitUntilSpawnNewCurrent = waitUntilSpawnNewDefault;

            SpawnGood();
            SpawnBad();
        }
    }

    public void DestroyAllMembers() {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
