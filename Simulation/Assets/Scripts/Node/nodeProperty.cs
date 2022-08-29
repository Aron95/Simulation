using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;
// contains all information of a node and handles decision-making within node
public class nodeProperty : MonoBehaviour
{
    public int ip;
    public int energy = 100;
  
    public CollisionController cellular;
    public CollisionController wifi;
    public CollisionController bluetooth;

    public bool canGetCellular;
    public bool canGetWifi;
    public bool canGetBluetooth;

    //for spamfiltering
    public int spamLimit = 5;
    public int spamProtectionTimer = 10000;
    public List<int> blockedIps = new List<int>();

    // keeps track of which nodes alreay have message
    public Dictionary<messageContent, SortedSet<int>> messageTable = 
        new Dictionary<messageContent, SortedSet<int>>(new MessageCompare());

    public Dictionary<int, int> spamDetectionTable =
        new Dictionary<int, int>();

    
    private MessageShooter _shooter;
    MessageShooter shooter { get {return _shooter != null ? _shooter : (_shooter = GetComponent<MessageShooter>());}}



    //NodeMovment

    //timer
    private System.Timers.Timer aTimer;

    // gets a random IP when Node is created / game is started
    void Start()
    {
        ip = Randomator.Next();
        SetTimer();
    }

    private void SetTimer()
    {
        aTimer = new System.Timers.Timer(spamProtectionTimer);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        spamDetectionTable.Clear();
    }

    private void Update()
    {
       
    }


    // handles storing incoming message
    public void addData(messageContent message)
    {
        if(!(blockedIps.Contains(message.ip)))
        {

            //Spamprotection
            if(message.ip != ip)
                {
                if (spamDetectionTable.ContainsKey(message.ip))
                {
                    int ipSpamCount;
                    spamDetectionTable.TryGetValue(message.ip, out ipSpamCount);
                    ipSpamCount++;
                    spamDetectionTable.Remove(message.ip);
                    spamDetectionTable.Add(message.ip, ipSpamCount);
                    if (ipSpamCount >= spamLimit)
                    {
                        blockedIps.Add(message.ip);
                        return;
                    }
                }
                else
                {
                    spamDetectionTable.Add(message.ip, 1);
                }
            }

            
            SortedSet<int> ips = new SortedSet<int>();
            ips.Add(message.ip);

            if (!(messageTable.ContainsKey(message)))
            {
                messageTable.Add(message, ips);
                routeMessage(message);
                GetComponent<NodeMovement>().danger = message.dangerNode;
            }
            else
            {
                messageTable.TryGetValue(message, out ips);
                ips.Add(message.ip);
            }
        }
        
    }

    // handles sending message to current neighbors
    public void routeMessage(messageContent message)
    {
        if (cellular != null){
            routeMessageToList(message, cellular.getNeighbours());
        }
        if (bluetooth != null){
            routeMessageToList(message, bluetooth.getNeighbours());
        }
        if (wifi != null){
            routeMessageToList(message, wifi.getNeighbours());
        }
        
    }

    private void routeMessageToList(messageContent message, List<GameObject> neighbours){
        SortedSet<int> ips;
        messageTable.TryGetValue(message,out ips);

        if(energy >= 0)
        {
            foreach (GameObject neighbour in neighbours)
            {
                if (!(ips.Contains(neighbour.GetComponent<nodeProperty>().ip)))
                {
                    ips.Add(neighbour.GetComponent<nodeProperty>().ip);

                    shooter.shootMessageDot(neighbour.GetComponent<Collider2D>(), message);
                    energy -=1;
                }
            }
        }
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