using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageContent : MonoBehaviour
{
/**
    {
    "warning":{
        "risk-level": "INT",
        "content" : "[content of warning, e.g. what to do, additional information]",
        "region": ["list of affected regions"],
        "valid-until": "INT YYYYMMDDHHMM (in UTC)",
        "valid-after": "INT YYYYMMDDHHMM (in UTC)",
        "typ":"INT",
        "id":"somehow generated ID",
        "version":"version of the warning for updates"
    },
    "signature": "[signature with selected algorithm]"
}
*/

    public int riskLvl;
    public string content;
    public string[] region;
    public string validUntil;
    public string validAfter;
    public int typ;
    public int id;
    public float version;
    public int ip;// Wird in MessageDotMovment gesetzt


    // Start is called before the first frame update
    void Start()
    {
  
    }


    public void fillMessage(messageContent message,int ip)
    {
        this.riskLvl = message.riskLvl;
        this.content = message.content;
        this.region = message.region;
        this.validUntil = message.validUntil;
        this.validAfter = message.validAfter;
        this.typ = message.typ;
        this.id = message.id;
        this.version = message.version;
        this.ip = ip;
    }


    public void handleData(Collider2D target)
    {
        target.GetComponent<nodeProperty>().addData(this);
    }
}
