using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// used within the Menu UI
public class EndProgramm : MonoBehaviour
{
    public void exitSimulation()
    {
        Application.Quit();
        Debug.Log("QUit");
    }
}
