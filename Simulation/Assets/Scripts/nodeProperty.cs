using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeProperty : MonoBehaviour
{
    public int ip;
   

    public Dictionary<messageContent, List<int>> messageTable = 
        new Dictionary<messageContent, List<int>>();  
    // Start is called before the first frame update
    void Start()
    {
        ip = Camera.main.GetComponent<ipProvider>().getRnd();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addData(messageContent message)
    {
        List<int> ips = new List<int>();
        ips.Add(message.ip);
        messageTable.Add(message, ips);
        printDict();
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