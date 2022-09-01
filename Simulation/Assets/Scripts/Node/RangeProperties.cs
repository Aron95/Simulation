using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles node collision with other nodes
public abstract class RangeProperties : MonoBehaviour
{
    public List<GameObject> neighbours = new List<GameObject>();
    
    private MessageSender _sender;
    MessageSender sender { get {return _sender != null ? _sender : (_sender = GetComponentInParent<MessageSender>());}}

    

    // triggers when Node collides with other Node
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject other = collision.gameObject;
        if (other.tag == "NetworkSphere" && other != transform.parent.gameObject)
        {
            nodeProperty otherNp = other.GetComponent<nodeProperty>();
            if(isValidNode(otherNp)){
                neighbours.Add(other);
                sender.sendUnsendMessagesToNode(other, this);
            }
        }
    }

    // triggers when Node no longer collides with other Node
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NetworkSphere")
        {
            neighbours.Remove(collision.gameObject);
        }
    }

    //returns the Neighbors from this CollisionController
    public List<GameObject> getNeighbours()
    {
        return neighbours;
    }

    public abstract bool isValidNode(nodeProperty otherNp);

    public abstract GameObject getMessageDotType();

    public abstract double getEnergyUsage();

}
