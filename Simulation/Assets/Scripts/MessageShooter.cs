using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageShooter : MonoBehaviour
{
    public GameObject Dot;
    public GameObject messageDot;
    


    public void shootMessageDot( Collider2D collider ){
        Dot = Instantiate(messageDot,transform.position,transform.rotation);
    }
}
