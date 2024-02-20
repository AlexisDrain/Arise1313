using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnSayonara : MonoBehaviour
{
    public List<GameObject> sayoButtons = new List<GameObject>();
    public Vector2 randXPos = new Vector2(0f, 1920f);
    public Vector2 randYPos = new Vector2(0f, 1080f);

    public float waitUntilSpawnNewDefault = 1.5f;
    private float waitUntilSpawnNewCurrent = 0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(waitUntilSpawnNewCurrent > 0f) {
            waitUntilSpawnNewCurrent -= Time.deltaTime;
        } else {
            waitUntilSpawnNewCurrent = waitUntilSpawnNewDefault;

            int rand = Random.Range(0, sayoButtons.Count);
            GameObject randObj = GameObject.Instantiate(sayoButtons[rand], transform);

            Vector2 randPosition = new Vector2(Random.Range(randXPos.x, randXPos.y), Random.Range(randYPos.x, randYPos.y));
            randObj.GetComponent<RectTransform>().anchoredPosition = randPosition;
        }
    }
}
