using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{

    public float speed = 0.001f;
    public GameObject target;
    public GameObject danger;

    public float angle;
    bool switchedTarget = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 safetyDir = Vector3.Normalize(gameObject.transform.position - danger.transform.position);
        Debug.DrawRay(gameObject.transform.position, safetyDir, Color.blue);


		if (target != null)
		{

			if (target.transform.position == gameObject.transform.position && !switchedTarget)
			{
                List<GameObject> targetNeighbors = target.GetComponent<WaypointNeighbors>().neighbors;

                GameObject newTarget = null;
                float lowestAngle = 181;

				foreach (GameObject neighbor in targetNeighbors) // finds neighbor that leads furthest away from danger
				{
                    Vector3 dirToNeighbor = neighbor.transform.position - gameObject.transform.position;
                    float neighborAngle = Vector3.Angle(safetyDir, dirToNeighbor);

                    if (neighborAngle < lowestAngle)
					{
                        newTarget = neighbor;
                        lowestAngle = neighborAngle;
					}
				}

                target = newTarget;


                switchedTarget = true;
			}
			else
			{
                Vector3 dirToTarget = target.transform.position - gameObject.transform.position;
                angle = Vector3.Angle(safetyDir, dirToTarget);
                Debug.DrawRay(gameObject.transform.position, dirToTarget, Color.black);
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed);
                switchedTarget = false;

			}

		}
    }
}
