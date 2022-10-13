using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;
using UnityEngine.UI;
// contains all information of a node and handles decision-making within node
public class nodeProperty : MonoBehaviour
{
    public int ip;
    public double energy = 100;
      
    public RangeProperties cellular;
    public RangeProperties bluetooth;
    public RangeProperties wifi;

    public GameObject energyBar;
    public EnergyScript script;

    public bool canGetCellular;
    public bool canGetBluetooth;
    public bool canGetWifi;

    //for spamfiltering
    public int spamLimit = 5;
    public int spamProtectionTimer = 10000;
    public List<int> blockedIps = new List<int>();

    // keeps track of which nodes alreay have message
    public Dictionary<messageContent, SortedSet<int>> messageTable = 
        new Dictionary<messageContent, SortedSet<int>>(new MessageCompare());

    public Dictionary<int, int> spamDetectionTable =
        new Dictionary<int, int>();

    
    private MessageSender _sender;
    MessageSender sender { get {return _sender != null ? _sender : (_sender = GetComponent<MessageSender>());}}

    //timer
    private System.Timers.Timer aTimer;

    // gets a random IP when Node is created / game is started
    void Start()
    {
        ip = Randomator.Next();
        SetTimer();
        script = energyBar.GetComponent<EnergyScript>();
    }

    private void SetTimer()
    {
        aTimer = new System.Timers.Timer(spamProtectionTimer);
        aTimer.Elapsed += clearSpamDetection;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    private void clearSpamDetection(object sender, ElapsedEventArgs e)
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
            
            if (!(messageTable.ContainsKey(message)))
            {
                messageTable.Add(message, ips);
                ips.Add(message.ip);
                sender.routeMessage(message);
                GetComponent<NodeMovementMultipleDangers>().addDangerNodeList(message.dangerNodes);
            }
            else
            {
                messageTable.TryGetValue(message, out ips);
                ips.Add(message.ip);
            }
        }
        
    }

    public void lowerEnergy(double energyDraw)
    {
        energy = energyDraw;

        script.SetEnergy(energy);
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
