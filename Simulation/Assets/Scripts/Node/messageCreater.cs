using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageCreater : MonoBehaviour
{

    private nodeProperty _np;
    nodeProperty np { get{ return _np ? _np : (_np = GetComponent<nodeProperty>()); } }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("pressed Space");
            createMessage();
        }
    }

    void createMessage() {
        messageContent message = gameObject.AddComponent<messageContent>();
        message.riskLvl = 9001;
        message.content = "Alienangriff";
        message.region = new string[] { "welt", "mond" };
        message.validAfter = "2022-11-11-11-11";
        message.validUntil = "2022-11-11-11-12";
        message.typ = 666;
        message.id = Randomator.Next();
        message.version = 1.0f;
        message.ip = np.ip;
        
        np.addData(message);
    } 
}
