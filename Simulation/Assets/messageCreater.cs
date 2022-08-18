using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class messageCreater : MonoBehaviour
{
    public messageContent message;
    public List<GameObject> nearNeighbour = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        message = gameObject.AddComponent<messageContent>();
        message.riskLvl = 9001;
        message.content = "Alienangriff";
        message.region = new string[] { "welt", "mond" };
        message.validAfter = "2022-11-11-11-11";
        message.validUntil = "2022-11-11-11-12";
        message.typ = 666;
        message.id = 0815;
        message.version = 1.0f;
        message.ip = GetComponent<nodeProperty>().ip;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("pressed Space");
            GetComponent<nodeProperty>().addData(message);
        }
    }
}
