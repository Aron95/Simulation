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
    public int ip;


    // Start is called before the first frame update
    void Start()
    {
        riskLvl = 9001;
        content = "Alienangriff";
        region  = new string []{ "welt","mond"};
        validAfter = "2022-11-11-11-11";
        validUntil = "2022-11-11-11-12";
        typ = 666;
        id = 0815;
        version = 1.0f;
        getIp();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getIp()
    {

        return 1;
    }

    public void handleData(Collider2D target)
    {
        target.GetComponent<nodeProperty>().addData(this);
    }
}
