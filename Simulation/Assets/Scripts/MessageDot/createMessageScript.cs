using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMessageScript : MonoBehaviour
{

    public int riskLvl;
    public string content;
    public string[] region;
    public string validUntil;
    public string validAfter;
    public int typ;
    public int id;
    public float version;
    public List<GameObject> dangerNodes;



    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            messageContent messageObject = createMessage(riskLvl, content, region, validUntil, validAfter, typ, id, version, dangerNodes);
            GetComponent<nodeProperty>().addData(messageObject);
        }
    }

    
    public messageContent createMessage(int riskLvl, string content, string[] region, string validUntil, 
                                        string validAfter, int typ, int id, float version, List<GameObject> dangerNodes)
    {
        messageContent messageObject = gameObject.AddComponent<messageContent>();
        messageObject.riskLvl = riskLvl;
        messageObject.content = content;
        messageObject.region = region;
        messageObject.validUntil = validUntil;
        messageObject.validAfter = validAfter;
        messageObject.typ = typ;
        messageObject.id = id;
        messageObject.version = version;
        messageObject.ip = GetComponent<nodeProperty>().ip;
        messageObject.dangerNodes = dangerNodes;

        return messageObject;
    }
}
