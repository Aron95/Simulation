using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createNodes : MonoBehaviour
{


    public int nodeCount = 50;
    public GameObject Node;
    Vector2 spawnPoint =new Vector2(0,0); 
    
    // Creates nodecount amount of nodes in the form of a grid
    void Start()
    {
        int nodes = Mathf.RoundToInt(Mathf.Sqrt(nodeCount));
        for(int i =0; i< nodes; i++)
        {
            spawnPoint.x = 2 * i;
            for(int j =0;j< nodes; j++)
            {
                spawnPoint.y = 2 * j;
                Instantiate(Node, spawnPoint, transform.rotation); // actually creates nodes
            }
        }
            
    }

}
