using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageDotMovment : MonoBehaviour
{
    public Collider2D target;
    bool check = false;

    public float destroyDistance = 0.2f;
    public float velocity = 0.020f;
    
    // Start is called before the first frame update
    void Start() {
        
    }

    private void Update() {
        if (check) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, velocity);
            if((target.transform.position -transform.position).magnitude < destroyDistance ) {
               destroyObject();
            }
        }
        
    }

    public void moveToTarget(Collider2D collider) {
        target = collider;
        check = true;
    }

    void destroyObject() {
        GetComponent<messageContent>().handleData(target);
        check = false;
        Destroy(gameObject);
    }
}
