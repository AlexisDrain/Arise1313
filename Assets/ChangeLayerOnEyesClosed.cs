using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeLayerOnEyesClosed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        GameManager.EyesClosedEvent.AddListener(SetLayerToEyesClosed);
        GameManager.EyesOpenEvent.AddListener(SetLayerToWorld);
        SetLayerToWorld();
    }

    void SetLayerToWorld() {

        gameObject.layer = GameManager.worldMask;
    }
    void SetLayerToEyesClosed() {
        gameObject.layer = GameManager.eyesClosedMask;
    }
}
