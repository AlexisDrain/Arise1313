using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImpulseWind : MonoBehaviour
{
    public float swingForce = 10f;
    private float currentTimeToSwing = 1f;

    private void Start() {
        currentTimeToSwing = Random.Range(0f, 3f); // starts random
    }
    void OnEnable()
    {
        currentTimeToSwing = Random.Range(0f, 3f); // starts random
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentTimeToSwing > 0f) {
            currentTimeToSwing -= Time.deltaTime;
        } else {
            currentTimeToSwing = 3f;
            GetComponent<Rigidbody>().AddForce(swingForce * Vector3.right, ForceMode.Impulse);
        }
    }
}
