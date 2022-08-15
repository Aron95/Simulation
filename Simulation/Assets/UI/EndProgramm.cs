using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndProgramm : MonoBehaviour
{
    public void exitSimulation()
    {
        Application.Quit();
        Debug.Log("QUit");
    }
}
