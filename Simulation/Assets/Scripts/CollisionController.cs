using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    public GameObject shooterScript;
    
    void start(){
        //GameObject parent = this.transform.parent; 
    }
    
    
    void OnCollisionEnter2D(Collision2D collision)
       {
           if (collision.gameObject.tag == "NetworkSphere")
           {
               Debug.Log("Collison111");
           }
       }
}
