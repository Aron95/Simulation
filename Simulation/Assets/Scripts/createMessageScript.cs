using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMessageScript : MonoBehaviour
{

    public messageContent messageObject;

    public int riskLvl;
    public string content;
    public string[] region;
    public string validUntil;
    public string validAfter;
    public int typ;
    public int id;
    public float version;
    public GameObject dangerNode;



    // Start is called before the first frame update
    void Start()
    {
        messageObject = gameObject.AddComponent<messageContent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
           createMessage(riskLvl, content, region, validUntil, validAfter, typ, id, version,  dangerNode);
           GetComponent<nodeProperty>().addData(messageObject);
        }
    }

    
    public messageContent createMessage(int riskLvl, string content, string[] region, string validUntil, 
                                        string validAfter, int typ, int id, float version,  GameObject dangerNode  )
    {

        messageObject.riskLvl = riskLvl;
        messageObject.content = content;
        messageObject.region = region;
        messageObject.validUntil = validUntil;
        messageObject.validAfter = validAfter;
        messageObject.typ = typ;
        messageObject.id = id;
        messageObject.version = version;
        messageObject.ip = GetComponent<nodeProperty>().ip;
        messageObject.dangerNode = dangerNode;

        return messageObject;
    }
}
