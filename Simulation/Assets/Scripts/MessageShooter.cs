using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles start of message transit
public class MessageShooter : MonoBehaviour
{
    public GameObject Dot;
    public GameObject messageDot;
    

    // creates message gameobject using messageContent and forwards it to destination node
    public void shootMessageDot( Collider2D collider, messageContent message ){

        int ip = GetComponent<nodeProperty>().ip;
        Dot = Instantiate(messageDot,transform.position,transform.rotation);
        Dot.GetComponent<messageContent>().fillMessage(message, GetComponent<nodeProperty>().ip);
        Dot.GetComponent<MessageDotMovment>().moveToTarget(collider);
    }
}
