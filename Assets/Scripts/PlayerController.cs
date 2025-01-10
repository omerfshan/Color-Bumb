using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sensitivity=.16f;
    public float ClampDelta=42f;
    public float bounds=5;
    private Vector3 lastMousePosition;
    CameraFollow cam;
    Rigidbody rb;
  private void Awake()    
    
    {
        rb=GetComponent<Rigidbody>();
        cam=FindAnyObjectByType<CameraFollow>();
    }

    private void Update() {
        transform.position=new Vector3(Mathf.Clamp(transform.position.x,-bounds,bounds),transform.position.y,transform.position.z);
        transform.position+=cam.camVel;
    }
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
          lastMousePosition=Input.mousePosition;
        }
        if(Input.GetMouseButton(0))
        {
          Vector3 vector=lastMousePosition-Input.mousePosition;
          lastMousePosition=Input.mousePosition;
          vector=new Vector3(vector.x,0,vector.y);

           Vector3 MoveForce=Vector3.ClampMagnitude(vector,ClampDelta);
           rb.AddForce( -MoveForce * sensitivity - rb.velocity / 5f, ForceMode.VelocityChange);
        }
        rb.velocity.Normalize();
    
    }
}
