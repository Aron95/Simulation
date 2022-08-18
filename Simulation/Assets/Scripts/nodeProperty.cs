using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeProperty : MonoBehaviour
{
    public int ip;
    public List<GameObject> nearNeighbour;
    
    public Dictionary<messageContent, List<int>> messageTable = 
        new Dictionary<messageContent, List<int>>(new MessageCompare());  
    // Start is called before the first frame update
    void Start()
    {
        ip = Camera.main.GetComponent<ipProvider>().getRnd();
    }

    // Update is called once per frame
  

    public void addData(messageContent message)
    {
        List<int> ips = new List<int>();
        ips.Add(message.ip);
        if(!(messageTable.ContainsKey(message)))
        {
            messageTable.Add(message, ips);
            routeMessage(message);
        }

        //TODO: checkDict 
    }

    public void routeMessage(messageContent message)
    {
        nearNeighbour = transform.GetChild(0).GetComponent<CollisionController>().nearNeighbour;

        List<int> ips = new List<int>();
        messageTable.TryGetValue(message,out ips);

        foreach (GameObject neighbour in nearNeighbour)
        {
            if(!(ips.Contains(neighbour.GetComponent<nodeProperty>().ip)))
            {
                GetComponent<MessageShooter>().shootMessageDot(neighbour.GetComponent<Collider2D>(),message);
            }
        }
        Debug.Log("routeMessage"+nearNeighbour);
    }


    public void printDict()
    {
        foreach (KeyValuePair<messageContent, List<int>> kvp in messageTable)
        {
            //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            
            Debug.Log("Key = "+ kvp.Key + ", Value = " + string.Join(", ",kvp.Value ));
        }
    }
}
