using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles node collision with other nodes
public class CollisionController : MonoBehaviour
{
    public List<GameObject> nearNeighbour = new List<GameObject>();
    public Dictionary<messageContent, SortedSet<int>> messageTable;
    public string tag;

     // Start is called before the first frame update
    void Start() {
        tag = transform.root.gameObject.tag;
    }

    // triggers when Node collides with other Node
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NetworkSphere" && collision.gameObject != transform.parent.gameObject)
        {
            
            Debug.Log("Node "+ transform.parent.name + " enters range of "+collision.gameObject.name);   /* TODO Implement Node Name*/
            nearNeighbour.Add(collision.gameObject);
            messageTable = GetComponentInParent<nodeProperty>().messageTable;

            foreach (KeyValuePair<messageContent, SortedSet<int>> kvp in messageTable)
            {
                if (!(kvp.Value.Contains(collision.GetComponent<nodeProperty>().ip)))
                {
                    GetComponentInParent<MessageShooter>().shootMessageDot(collision.GetComponent<Collider2D>(), kvp.Key);
                }
            }

        }
    }

    // triggers when Node no longer collides with other Node
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NetworkSphere")
        {
            nearNeighbour.Remove(collision.gameObject);
        }
    }

    public List<GameObject> getNeighbours()
    {
        return nearNeighbour;
    }
}
