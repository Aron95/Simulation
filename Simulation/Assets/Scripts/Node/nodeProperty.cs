using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeProperty : MonoBehaviour {
    public int ip;
    
    private List<GameObject> _nearNeighbour;
    public List<GameObject> nearNeighbour { get{ return _nearNeighbour != null ? _nearNeighbour : 
        (_nearNeighbour = transform.GetChild(0).GetComponent<CollisionController>().nearNeighbour); } }

    private MessageShooter _ms;
    public MessageShooter ms { get{ return _ms != null ? _ms : (_ms = GetComponent<MessageShooter>()); } }
    
    public Dictionary<messageContent, SortedSet<int>> messageTable = 
        new Dictionary<messageContent, SortedSet<int>>(new MessageCompare());  

    
    // Start is called before the first frame update
    void Start() {
       ip = Randomator.Next();
    }

    public void addData(messageContent message) {
        SortedSet<int> ips = new SortedSet<int>();
        ips.Add(message.ip);

        if(!(messageTable.ContainsKey(message))) {
            messageTable.Add(message, ips);
            routeMessage(message);
        } else {
            messageTable.TryGetValue(message, out ips);
            ips.Add(message.ip);
        }   
    }

    public void routeMessage(messageContent message) {
        SortedSet<int> ips;
        messageTable.TryGetValue(message,out ips);

        foreach (GameObject neighbour in nearNeighbour) {
            int nIp = neighbour.GetComponent<nodeProperty>().ip;
            if(!(ips.Contains(nIp))) {
                ips.Add(nIp);
                ms.shootMessageDot(neighbour.GetComponent<Collider2D>(),message);
            }
        }
    }


    public void printDict() {
        foreach (KeyValuePair<messageContent, SortedSet<int>> kvp in messageTable)
        {
            Debug.Log("Key = "+ kvp.Key + ", Value = " + string.Join(", ",kvp.Value ));
        }
    }
}
