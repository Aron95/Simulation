using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// controls Menu UI
public class UIController : MonoBehaviour
{
    public Canvas canvasBTN;

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
