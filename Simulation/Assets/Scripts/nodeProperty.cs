using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeProperty : MonoBehaviour
{
    public int ip;
    public List<GameObject> nearNeighbour;
    
    public Dictionary<messageContent, SortedSet<int>> messageTable = 
        new Dictionary<messageContent, SortedSet<int>>(new MessageCompare());  
    // Start is called before the first frame update
    void Start()
    {
        ip = Camera.main.GetComponent<ipProvider>().getRnd();
    }

    // Update is called once per frame
  

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
