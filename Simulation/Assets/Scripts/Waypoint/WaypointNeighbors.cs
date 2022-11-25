using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNeighbors : MonoBehaviour
{
    public List<GameObject> neighbors = new List<GameObject>();
    public bool showNeighborLines = true;

	private void Update()
	{
		if (showNeighborLines)
		{
			foreach (GameObject neighbor in neighbors)
			{
				Vector3 endpoint = Vector3.Lerp(gameObject.transform.position, neighbor.transform.position, 0.5f);
				Debug.DrawLine(gameObject.transform.position, endpoint, Color.green);
			}
		}
	}
}
