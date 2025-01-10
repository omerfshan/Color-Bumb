using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float sensitivity=.16f;
    public float ClampDelta=42f;
    public float bounds=5;
    private Vector3 lastMousePosition;
    [HideInInspector]
    public bool canMove,gameOver,finish;
    CameraFollow cam;
    Rigidbody rb;
  private void Awake()    
    
    {
        rb=GetComponent<Rigidbody>();
        cam=FindAnyObjectByType<CameraFollow>();
    }

    private void Update() {
        transform.position=new Vector3(Mathf.Clamp(transform.position.x,-bounds,bounds),transform.position.y,transform.position.z);
        if(canMove)
        transform.position+=cam.camVel;
        
        if(!canMove&&gameOver){
          if(Input.GetMouseButtonDown(0)){
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);}
        }
        else if(!canMove&&!finish)
        { 
         if(Input.GetMouseButtonDown(0))
          {
              canMove=true;
          }
        }
    }
    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
          lastMousePosition=Input.mousePosition;
        }
        if(canMove){
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


  IEnumerator Nextlevel(){
    finish=true;
    canMove=false;
   PlayerPrefs.SetInt("Level",PlayerPrefs.GetInt("Level",1)+1);
   yield return new WaitForSeconds(1);
   SceneManager.LoadScene("Level"+PlayerPrefs.GetInt("Level"));
  }

  private void GameOver(){
   canMove=false;
   gameOver=true;
   
    GetComponent<MeshRenderer>().enabled=false;
    GetComponent<Collider>().enabled=false;
  }
 
 
 
  private void OnCollisionEnter(Collision other) {
    if(other.gameObject.tag=="Enemy")
    {
         GameOver();
    }
  }


private void OnTriggerEnter(Collider other) {
  if(other.gameObject.tag=="Finish")
  {
    StartCoroutine(Nextlevel());
  }
}
}