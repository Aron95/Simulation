using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createNodes : MonoBehaviour
{


    public int nodeCount = 50;
    public GameObject Node;
    Vector2 spawnPoint =new Vector2(0,0); 
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i =0; i<nodeCount;i++)
        {
            for(int j =0;j< nodeCount;j++)
            {
                Instantiate(Node, spawnPoint, transform.rotation);
                spawnPoint.x = 2 * i;
                spawnPoint.y = 2 * j;
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
