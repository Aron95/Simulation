using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public Canvas canvasBTN;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pushed");
            if (canvasBTN.isActiveAndEnabled)
                canvasBTN.enabled = false;
            else
                canvasBTN.enabled = true;
        }
    }
}
