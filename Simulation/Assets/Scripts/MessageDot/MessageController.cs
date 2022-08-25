using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// currently not used anywhere to my knowledge
public class MessageController : MonoBehaviour
{
    public GameObject circleCollider;
    public CircleCollider2D collider;
    public GameObject[] singelHopeRange;
    // Start is called before the first frame update
    void Start()
    {
        collider = circleCollider.GetComponent<CircleCollider2D>();
    }
    
    // Only logs when Node is in range
    void OnCollisionEnter2D(Collision2D collision)
    {
    	Debug.Log("Conncetion");
        if (collision.gameObject.tag == "NetworkSphere")
        {
            Debug.Log("Conncetion");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
