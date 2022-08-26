using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles node collision with other nodes
public abstract class CollisionController : MonoBehaviour
{
    public List<GameObject> neighbours = new List<GameObject>();

    private Dictionary<messageContent, SortedSet<int>> _messageTable;
    Dictionary<messageContent, SortedSet<int>> messageTable { get {return _messageTable != null ? _messageTable : (_messageTable = GetComponentInParent<nodeProperty>().messageTable);}}
    
    private MessageShooter _shooter;
    MessageShooter shooter { get {return _shooter != null ? _shooter : (_shooter = GetComponentInParent<MessageShooter>());}}

    

    // triggers when Node collides with other Node
    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject other = collision.gameObject;
        if (other.tag == "NetworkSphere" && other != transform.parent.gameObject)
        {
            nodeProperty otherNp = other.GetComponent<nodeProperty>();
            if(isValidNode(otherNp)){
                neighbours.Add(other);
                foreach (KeyValuePair<messageContent, SortedSet<int>> kvp in messageTable)
                {
                    if (!(kvp.Value.Contains(otherNp.ip)))
                    {
                        shooter.shootMessageDot(collision.GetComponent<Collider2D>(), kvp.Key);
                    }
                }
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

}
