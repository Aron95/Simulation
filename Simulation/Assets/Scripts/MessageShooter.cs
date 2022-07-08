using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageShooter : MonoBehaviour
{
    public GameObject messageDot;
    


    void shootMessageDot(){
        Instantiate(messageDot);
    }
}
