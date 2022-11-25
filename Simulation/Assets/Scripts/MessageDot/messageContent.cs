using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// contans all relevant message information
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
    public int ip;
    public List<GameObject> dangerNodes;

    // fills the message with content
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
        this.dangerNodes = message.dangerNodes;
    }

    public void handleData(Collider2D target)
    {
        target.GetComponent<nodeProperty>().addData(this);
    }
}
