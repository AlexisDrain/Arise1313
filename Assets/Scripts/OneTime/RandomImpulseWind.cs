using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomImpulseWind : MonoBehaviour
{
    public float swingForce = 10f;
    public float defaultTimeToSwing = 1f;
    private float currentTimeToSwing = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(currentTimeToSwing > 0f) {
            currentTimeToSwing -= Time.deltaTime;
        } else {
            currentTimeToSwing = defaultTimeToSwing;
            GetComponent<Rigidbody>().AddForce(swingForce * Vector3.right, ForceMode.Impulse);
        }
    }
}
