using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// provides IPs to for nodes with random numbers
public class ipProvider : MonoBehaviour
{
    public int ip;
    System.Random rnd= new System.Random();  

    public int getRnd()
    {
        ip = rnd.Next();
        return ip; 
    }
}
