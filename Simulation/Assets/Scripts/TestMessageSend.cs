using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMessageSend : MonoBehaviour
{

    public List<GameObject> nearNeighbour = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Debug.Log("press Space");
            sendMessage();
        }
    }

    public void sendMessage()
    {
        nearNeighbour = GetComponent<CollisionController>().getNeighbours();
        for(int i=0; i < nearNeighbour.Count ; i++)
        {
            Debug.Log("Shoot");
            Collider2D collision = nearNeighbour[i].transform.GetComponent<Collider2D>();
            transform.parent.GetComponent<MessageShooter>().shootMessageDot(collision);
        }
        
    }
}
