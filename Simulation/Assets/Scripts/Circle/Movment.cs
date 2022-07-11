using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public GameObject circle;
  

    // Update is called once per frame
    void Update()
    {
        circle.transform.Rotate(0, 0, 1);
    }
}
