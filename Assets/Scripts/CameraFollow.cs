using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 camVel;
    public float camspeed=6;
    
    void Update()
    {
        camVel=Vector3.forward*camspeed*Time.deltaTime;
        transform.position+=Vector3.forward*camspeed*Time.deltaTime;
    }
}
