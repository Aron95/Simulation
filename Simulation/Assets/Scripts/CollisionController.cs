using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NetworkSphere")
        {
            Debug.Log("Collison111");
            transform.parent.GetComponent<MessageShooter>().shootMessageDot(collision);
        }
    }
}
