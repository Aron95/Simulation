using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityToolbag;
using System.Threading;

public class SpamNodeProperties : MonoBehaviour {
    
    System.Random rnd = Randomator.rnd;

    private nodeProperty _np;
    nodeProperty np { get{ return _np ? _np : (_np = GetComponent<nodeProperty>()); } }

    bool started = false;
    public int delay = 2000;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown("p")) {
            Debug.Log("P pressed, spamstatus changed");
            started = !started;
            if(started) {
                new Thread(new ThreadStart(spam)).Start();
            }
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
        message.id = rnd.Next();
        message.version = 1.0f;
        message.ip = np.ip;
        
        np.addData(message);
    }

    void spam() {
        while(started) {
            Dispatcher.InvokeAsync(createMessage);
            Thread.Sleep(delay);
        }
    }
}
