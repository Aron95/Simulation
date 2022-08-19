using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// contains all information of a node and handles decision-making within node
public class nodeProperty : MonoBehaviour
{
    public int ip;
    public List<GameObject> nearNeighbour;
    
    // keeps track of which nodes alreay have message
    public Dictionary<messageContent, SortedSet<int>> messageTable = 
        new Dictionary<messageContent, SortedSet<int>>(new MessageCompare());  
    
    
    // gets a random IP from the main camera when Node is created / game is started
    void Start()
    {
        ip = Camera.main.GetComponent<ipProvider>().getRnd();
    }
  

    // handles storing incoming message
    public void addData(messageContent message)
    {
        SortedSet<int> ips = new SortedSet<int>();
        ips.Add(message.ip);

        if(!(messageTable.ContainsKey(message)))
        {
            messageTable.Add(message, ips);
            routeMessage(message);
        }
        else
        {
            messageTable.TryGetValue(message, out ips);
            ips.Add(message.ip);
        }   
    }

    // handles sending message to current neighbors
    public void routeMessage(messageContent message)
    {
        nearNeighbour = transform.GetChild(0).GetComponent<CollisionController>().nearNeighbour;

        SortedSet<int> ips;
        messageTable.TryGetValue(message,out ips);

        foreach (GameObject neighbour in nearNeighbour)
        {
            if(!(ips.Contains(neighbour.GetComponent<nodeProperty>().ip)))
            {
                ips.Add(neighbour.GetComponent<nodeProperty>().ip);
        
                GetComponent<MessageShooter>().shootMessageDot(neighbour.GetComponent<Collider2D>(),message);
            }
        }
        Debug.Log("routeMessage"+nearNeighbour);
    }


    public void printDict()
    {
        foreach (KeyValuePair<messageContent, SortedSet<int>> kvp in messageTable)
        {
            //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            
            Debug.Log("Key = "+ kvp.Key + ", Value = " + string.Join(", ",kvp.Value ));
        }
    }
}
