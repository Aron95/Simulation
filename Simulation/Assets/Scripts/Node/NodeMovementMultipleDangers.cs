using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovementMultipleDangers : MonoBehaviour
{

    public float speed = 0.001f;
    public GameObject target;
    public List<GameObject> danger = new List<GameObject>();
    public bool shouldMove = true;

    private GameObject lastTarget;


    // Update is called once per frame
    void Update()
    {
        if (target == null || !shouldMove) return; // movement requires initial target to move towards
		
		if (danger.Count != 0)
		{
            dangerRoutine();
		}
        else
		{
            wander();
		}
    }


    // when no danger is set, Node wanders around randomly
    private void wander()
	{

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

    // Node moves away from known dangers
    private void dangerRoutine()
	{
        // calculate safety vector from multiple dangers
        Vector3 safetyDir = new Vector3();

        foreach (GameObject dangerNode in danger)
		{
			if (dangerNode == null)
			{
                Debug.Log("DangerNode in List of Dangers is null");
                return;
			}

            safetyDir += Vector3.Normalize(gameObject.transform.position - dangerNode.transform.position);
            safetyDir = Vector3.Normalize(safetyDir);
		}

        //safetyDir /= danger.Count;
        //safetyDir = Vector3.Normalize(safetyDir);
        
        Debug.DrawRay(gameObject.transform.position, safetyDir, Color.blue);

        // actual movement
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

			if (lastTarget != newTarget || lowestAngle < 90)
			{
                lastTarget = target;
                target = newTarget;
			}
			else
			{
                shouldMove = false;
                lastTarget = null;
			}
        }
        else // move towards target
        {
            Vector3 dirToTarget = target.transform.position - gameObject.transform.position;
            Debug.DrawRay(gameObject.transform.position, dirToTarget, Color.black);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed * 1.5f);

        }

    }

    // to be used when single danger nodes need to be added
    public void addDangerNode(GameObject dangerNode)
	{
		if (dangerNode != null && !danger.Contains(dangerNode))
		{
            danger.Add(dangerNode);
		}
	}

    // adds a list of dangers to the knows list of dangers
    public void addDangerNodeList(List<GameObject> dangers)
	{
        if (dangers == null) return;

        shouldMove = true;

        foreach (GameObject dangerNode in dangers)
		{
            addDangerNode(dangerNode);
		}
    }

}
