using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* Author: Alexis Clay Drain
*/
public class BillboardSprites : MonoBehaviour
{
    public bool plantOnGround = true;
    public bool reverseLook = false;
    void LateUpdate() {
        if(reverseLook) {
            transform.LookAt(transform.position - (Camera.main.transform.position - transform.position));
        } else {
            transform.LookAt(Camera.main.transform);
        }
        if(plantOnGround == true) {
            transform.rotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
        }
    }
}
