using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageShooter : MonoBehaviour {
    public GameObject messageDot;
    
    public void shootMessageDot( Collider2D collider, messageContent message ) {
        int ip = GetComponent<nodeProperty>().ip;
        GameObject Dot = Instantiate(messageDot,transform.position,transform.rotation);
        Dot.GetComponent<messageContent>().fillMessage(message, GetComponent<nodeProperty>().ip);
        Dot.GetComponent<MessageDotMovment>().moveToTarget(collider);
    }
}
