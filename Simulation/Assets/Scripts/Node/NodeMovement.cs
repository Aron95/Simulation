using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovement : MonoBehaviour
{

    public float speed = 0.001f;
    public GameObject target;
    public GameObject danger;

    // Update is called once per frame
    void Update()
    {
		if (danger != null)
		{
            dangerRoutine();
		}
        else
		{
            wander();
		}
    }

    private void wander()
	{
        if (target == null) return;

		if (gameObject.transform.position != target.transform.position) // move towards target
		{
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed);
		}
		else // find new target to move towards
		{
            List<GameObject> neighbors = target.GetComponent<WaypointNeighbors>().neighbors;

			if (neighbors.Count < 1) return;
			
            int index = Mathf.RoundToInt(Random.value * (neighbors.Count-1));
            target = neighbors[index];
		}
	}

    private void dangerRoutine()
	{
        Vector3 safetyDir = Vector3.Normalize(gameObject.transform.position - danger.transform.position);
        Debug.DrawRay(gameObject.transform.position, safetyDir, Color.blue);


        if (target != null)
        {

            if (target.transform.position == gameObject.transform.position) // if new target has to be found
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
            }
            else // move towards target
            {
                Vector3 dirToTarget = target.transform.position - gameObject.transform.position;
                Debug.DrawRay(gameObject.transform.position, dirToTarget, Color.black);
                gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed);

            }

        }
    }

}
