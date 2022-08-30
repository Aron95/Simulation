using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// contains 
public class MessageDotMovment : MonoBehaviour
{
    public Collider2D target;
    bool check = false;
    public float speed = 1.0f;


    // contains homing mechanism of message objects
    private void Update()
    {
        if (check)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.012f * speed);
            
            // if message is close to target center
            if ((target.transform.position -transform.position).magnitude < 0.2f ) 
            {
               destroyObject();
            }
        }
        
    }

    // sets the target object
    public void moveToTarget(Collider2D collider)
    {
        target = collider;
        check = true;
    }

    // handles proper message transmission when message gameobject is destroyed
    void destroyObject()
    {
        GetComponent<messageContent>().handleData(target);
        check = false;
        Destroy(gameObject);
    }
}
