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
            Debug.Log("check");
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.01f);
            if(transform.position == target.transform.position)
            {
                destroyObject();
            }
        }
        
    }

    public void moveToTarget(Collider2D collider)
    {
        target = collider;
        check = true;
    }

    void destroyObject()
    {
        Debug.Log("Destory");
        check = false;
        Destroy(gameObject);
    }
}
