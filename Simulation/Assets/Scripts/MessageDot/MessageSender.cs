using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles start of message transit
public class MessageSender : MonoBehaviour
{
    private nodeProperty _np;
    nodeProperty np { get{ return _np ? _np : (_np = GetComponent<nodeProperty>()); } }

    // handles sending message to current neighbors
    public void routeMessage(messageContent message)
    {
        if (np.cellular != null){
            routeMessage(message, np.cellular);
        }
        if (np.bluetooth != null){
            routeMessage(message, np.bluetooth);
        }
        if (np.wifi != null){
            routeMessage(message, np.wifi);
        }
        
    }

    // sends the message with the correct Properties
    // creates message gameobject using messageContent and forwards it to destination node
    private void routeMessage(messageContent message, RangeProperties rp){
        SortedSet<int> ips;
        np.messageTable.TryGetValue(message,out ips);

        foreach (GameObject destination in rp.neighbours)
        {
            nodeProperty destinationNp = destination.GetComponent<nodeProperty>();
            if(!ips.Contains(destinationNp.ip)){
                if(sendMessage(message, destinationNp, rp)) {
                    ips.Add(destinationNp.ip);
                }
            }
        }
    }

    // returns if Message was send.
    private bool sendMessage(messageContent message, nodeProperty destinationNp, RangeProperties rp){
        if(np.energy < rp.getEnergyUsage()){
            Debug.Log("Too less Energy!");
        } else {
            GameObject Dot = Instantiate(rp.getMessageDotType(),transform.position,transform.rotation);
            Dot.GetComponent<messageContent>().fillMessage(message, np.ip);
            Dot.GetComponent<MessageDotMovment>().moveToTarget(destinationNp.GetComponent<Collider2D>());

            np.energy -=rp.getEnergyUsage();
            np.lowerEnergy(np.energy);
            return true;
        }
        return false;
    }

    public void sendUnsendMessagesToNode(GameObject destination, RangeProperties rp){
        foreach (KeyValuePair<messageContent, SortedSet<int>> kvp in np.messageTable)
        {
            nodeProperty destinationNp = destination.GetComponent<nodeProperty>();
            if (!(kvp.Value.Contains(destinationNp.ip))) {
                if(sendMessage(kvp.Key, destinationNp, rp)) {
                    kvp.Value.Add(destinationNp.ip);
                }
            }
        }
    }
}
