using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{

    public float speed = 0.001f;
    public GameObject target;
    public GameObject danger;

    public float angle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 safetyDir = Vector3.Normalize(gameObject.transform.position - danger.transform.position);
        Debug.DrawRay(gameObject.transform.position, safetyDir);


		if (target != null)
		{
            Vector3 dirToTarget = target.transform.position - gameObject.transform.position;
            Debug.DrawRay(gameObject.transform.position, dirToTarget);
            angle = Vector3.Angle(safetyDir, dirToTarget);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed);

		}
    }
}
