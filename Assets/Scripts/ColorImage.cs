using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorImage : MonoBehaviour
{
    Color color;
    void Start()
    {
        color =new Color(Random.Range(0.1f,1),Random.Range(0.1f,1),Random.Range(0.1f,1));
        GetComponent<SpriteRenderer>().color=color;
    }

   
    void Update()
    {
        
    }
}
