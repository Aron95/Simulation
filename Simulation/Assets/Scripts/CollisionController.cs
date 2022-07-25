using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    public List<GameObject> nearNeighbour = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NetworkSphere" && collision.gameObject != transform.parent.gameObject)
        {
     
            Debug.Log("Node "+ transform.parent.name + " enters range of "+collision.gameObject.name);   /* TODO Implement Node Name*/
            transform.parent.GetComponent<MessageShooter>().shootMessageDot(collision);
            nearNeighbour.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit");
        if (other.gameObject.tag == "NetworkSphere")
        {
            Debug.Log("Remove" + other.gameObject.name);
            nearNeighbour.Remove(other.gameObject);
        }
    }
}
