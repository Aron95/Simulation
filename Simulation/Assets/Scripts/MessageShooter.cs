using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageShooter : MonoBehaviour
{
    public GameObject Dot;
    public GameObject messageDot;
    


    public void shootMessageDot( Collider2D collider ){

        int ip = GetComponent<nodeProperty>().ip;
        Dot = Instantiate(messageDot,transform.position,transform.rotation);
        Dot.GetComponent<MessageDotMovment>().moveToTarget(collider,ip);
    }
}
