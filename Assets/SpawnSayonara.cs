using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class SpawnSayonara : MonoBehaviour
{
    public List<GameObject> sayoGoodButtons = new List<GameObject>();
    public List<GameObject> sayoBadButtons = new List<GameObject>();
    public Vector2 randXPos = new Vector2(0f, 1920f);
    public Vector2 randYPos = new Vector2(0f, 1080f);
    public float minimumButtonDistances = 150f;

    public float waitUntilSpawnNewDefault = 1.5f;
    private float waitUntilSpawnNewCurrent = 0f;

    [Header("Read only")]
    public List<Vector2> _previousSpawnPositions = new List<Vector2>();

    private int previousIndexGood;
    private int previousIndexBad;

    void Start()
    {
        DeactivateAllMembers();
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
    public void SpawnGood() {

        int randIndex = Random.Range(0, sayoGoodButtons.Count);
        while (randIndex == previousIndexGood) {
            randIndex = Random.Range(0, sayoGoodButtons.Count);
        }

        GameObject obj = sayoGoodButtons[randIndex];
        obj.SetActive(true);

        previousIndexGood = randIndex;

        Vector2 randPosition = GenerateNewPosition();

        obj.GetComponent<RectTransform>().anchoredPosition = randPosition;
        obj.GetComponent<ButtonShake>().UpdateNewLocation(obj.transform.position);
    }
    public void SpawnBad() {

        int randIndex = Random.Range(0, sayoBadButtons.Count);
        while (randIndex == previousIndexBad) {
            randIndex = Random.Range(0, sayoBadButtons.Count);
        }

        GameObject obj = sayoBadButtons[randIndex];
        obj.SetActive(true);

        previousIndexBad = randIndex;

        Vector2 randPosition = GenerateNewPosition();

        obj.GetComponent<RectTransform>().anchoredPosition = randPosition;
        obj.GetComponent<ButtonShake>().UpdateNewLocation(obj.transform.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(waitUntilSpawnNewCurrent > 0f) {
            waitUntilSpawnNewCurrent -= Time.deltaTime;
        } else {
            waitUntilSpawnNewCurrent = waitUntilSpawnNewDefault;

            SpawnGood();
            SpawnBad();
        }
    }

    public void DeactivateAllMembers() {
        for (int i = 0; i < sayoBadButtons.Count; i++) {
            sayoBadButtons[i].SetActive(false);
        }
        for (int i = 0; i < sayoGoodButtons.Count; i++) {
            sayoGoodButtons[i].SetActive(false);
        }
    }
}
