using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageDotMovment : MonoBehaviour
{
    public Collider2D target;
    bool check = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update()
    {
        if (check)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.002f);
            if((target.transform.position -transform.position).magnitude < 0.4f )
            {
               destroyObject();
            }
        }
        
    }

    public void moveToTarget(Collider2D collider,int ip)
    {
        target = collider;
        check = true;
        GetComponent<messageContent>().ip = ip;
    }

    void destroyObject()
    {
        GetComponent<messageContent>().handleData(target);
        Debug.Log("Destory");
        check = false;
        Destroy(gameObject);
    }
}
