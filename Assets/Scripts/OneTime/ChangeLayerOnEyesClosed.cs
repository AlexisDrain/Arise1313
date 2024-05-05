using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeLayerOnEyesClosed : MonoBehaviour
{
    // Start is called before the first frame update
    public Material newMat;
    private Material oldMat;
    void Start()
    {
        oldMat = GetComponent<MeshRenderer>().material;
        GameManager.EyesClosedEvent.AddListener(SetLayerToEyesClosed);
        GameManager.EyesOpenEvent.AddListener(SetLayerToWorld);
        SetLayerToWorld();
    }

    void SetLayerToWorld() {
        GetComponent<MeshRenderer>().material = oldMat;
        gameObject.layer = GameManager.worldMask;
    }
    void SetLayerToEyesClosed() {
        GetComponent<MeshRenderer>().material = newMat;
        gameObject.layer = GameManager.eyesClosedMask;
    }
}
