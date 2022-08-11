using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ipProvider : MonoBehaviour
{
    public int ip;
    System.Random rnd= new System.Random();  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getRnd()
    {
        ip = rnd.Next();
        return ip; 
    }
}
