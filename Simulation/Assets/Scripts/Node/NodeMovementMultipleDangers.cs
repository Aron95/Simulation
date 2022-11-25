using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMovementMultipleDangers : MonoBehaviour
{

    public float speed = 0.001f;
    public GameObject target;
    public List<GameObject> danger = new List<GameObject>();
    public bool shouldMove = true;
    public bool shouldMoveToDanger = false;

    private GameObject lastTarget;
    private GameObject dangerToMoveTo;

    private Vector3 safetyDir; // cached safety dir for danger routine

    // Update is called once per frame
    void Update()
    {
        if (target == null || !shouldMove) return; // movement requires initial target to move towards
		
		if (danger.Count != 0)
		{
			if (!shouldMoveToDanger)
			{
                dangerRoutine();
			}
			else
			{
                moveToDanger();
			}
		}
        else
		{
            wander();
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

    // when no danger is set, Node wanders around randomly
    private void wander()
	{

		if (gameObject.transform.position != target.transform.position) // move towards target
		{
            moveToTarget();
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
        // actual movement
        if (target.transform.position == gameObject.transform.position) // if new target has to be found
        {
            // calculate safety vector from multiple dangers
            safetyDir = new Vector3();

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

            // choose new target based on angle
            GameObject newTarget;
            float lowestAngle = chooseNewTarget(safetyDir, out newTarget);

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
            moveToTarget();
        }
        Debug.DrawRay(gameObject.transform.position, safetyDir, Color.blue);

    }

    // move towards danger
    private void moveToDanger()
	{
		if (dangerToMoveTo == null)
		{
            int index = Mathf.RoundToInt(Random.value * (danger.Count-1));
            dangerToMoveTo = danger[index];
		}
        Vector3 dangerPos = dangerToMoveTo.transform.position;

        Vector3 dangerDir = Vector3.Normalize(dangerPos - gameObject.transform.position);
        Debug.DrawRay(gameObject.transform.position, dangerDir, Color.red);

        // actual movement
        if (target.transform.position == gameObject.transform.position) // if new target has to be found
        {
            GameObject newTarget;
            chooseNewTarget(dangerDir, out newTarget);

            if (lastTarget != newTarget)
            {
                lastTarget = target;
                target = newTarget;
            }
            else
            {
                dangerToMoveTo = null;
                lastTarget = null;
            }
        }
        else // move towards target
        {
            moveToTarget();
        }

	}

    // chooses new Target to move to depending on the direction given
    private float chooseNewTarget(Vector3 dir, out GameObject newTarget)
	{
        List<GameObject> targetNeighbors = target.GetComponent<WaypointNeighbors>().neighbors;
        newTarget = null;

        float lowestAngle = 181;

        foreach (GameObject neighbor in targetNeighbors) // finds neighbor that leads furthest away from danger
        {
            Vector3 dirToNeighbor = neighbor.transform.position - gameObject.transform.position;
            float neighborAngle = Vector3.Angle(dir, dirToNeighbor);

            if (neighborAngle < lowestAngle)
            {
                newTarget = neighbor;
                lowestAngle = neighborAngle;
            }
        }

        return lowestAngle;
    }

    // moves Node towards target and visualizes
    private void moveToTarget()
	{
        Vector3 dirToTarget = target.transform.position - gameObject.transform.position;
        Debug.DrawRay(gameObject.transform.position, dirToTarget, Color.black);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, speed);
    }

}
