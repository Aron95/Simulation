using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject circle;
  

    // rotates the outer dotted circle of a node
    void Update()
    {
        circle.transform.Rotate(0, 0, 1);
    }
}
