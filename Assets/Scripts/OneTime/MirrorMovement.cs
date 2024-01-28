using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorMovement : MonoBehaviour
{
    public Transform mirrorTrans;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 camToLocal = mirrorTrans.InverseTransformPoint(Camera.main.transform.position);
        transform.position = mirrorTrans.TransformPoint(new Vector3(camToLocal.x, camToLocal.y, -camToLocal.z));

        Vector3 direction = mirrorTrans.TransformPoint(new Vector3(-camToLocal.x, camToLocal.y, camToLocal.z));
        transform.LookAt(-direction);
    }
}
