using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createNodes : MonoBehaviour
{
    public int nodeCount = 50;
    public List<GameObject> Nodes; // prefab from which to create nodes
    
    public bool grid = true;
    public float gridDistance = 1.6f;
    public List<GameObject> startingTargets = new List<GameObject>(); // random target from conected targets
    
    void Start()
    {
        if (Nodes.Count == 0) return;

		if (grid)
		{
            int amount = Mathf.RoundToInt(Mathf.Sqrt(nodeCount));
            createGrid(amount);
		}
		else if (startingTargets.Count != 0)
		{
            createBetweenTargets(nodeCount);
		}
        
    }

    // Creates amount of nodes in the form of a grid
    private void createGrid(int amount)
	{
        Vector2 spawnPoint = new Vector2(0, 0);
        for (int i = 0; i < amount; i++)
        {
            spawnPoint.x = gridDistance * i;
            for (int j = 0; j < amount; j++)
            {
                spawnPoint.y = gridDistance * j;

                // choose random prefab
                int prefabIndex = Mathf.RoundToInt(Random.value * (Nodes.Count - 1));
                GameObject Node = Nodes[prefabIndex];

                Instantiate(Node, spawnPoint, transform.rotation); // actually creates nodes
            }
        }
    }


    // creates Nodes randomly between targets
    private void createBetweenTargets(int amount)
	{
        List<GameObject> allNodes = new List<GameObject>();

        // fill allNodes with all targets
        foreach (GameObject target in startingTargets) 
		{
            allNodes = singleNetwork(target, allNodes);
		}

        // create nodes
        for (int i = 0; i < amount; i++) 
		{
            // get random target
            int index = Mathf.RoundToInt(Random.value * (allNodes.Count - 1));
            GameObject current = allNodes[index];
            
            // get random neighbor of chosen target
            List<GameObject> neighbors = current.GetComponent<WaypointNeighbors>().neighbors;
            int neighborIndex = Mathf.RoundToInt(Random.value * (neighbors.Count - 1));
            GameObject neighbor = neighbors[neighborIndex];

            // randomize spawnpoint between selected targets
            Vector3 randomSpawnpoint = Vector3.Lerp(current.transform.position, neighbor.transform.position, Random.value);

            // choose random prefab
            int prefabIndex = Mathf.RoundToInt(Random.value * (Nodes.Count - 1));
            GameObject Node = Nodes[prefabIndex];

            // create Node and give it initial target
            GameObject newNode = Instantiate(Node, randomSpawnpoint, transform.rotation);
            newNode.GetComponent<NodeMovementMultipleDangers>().target = current;
		}
	}

    // helper function to add connected network of targets to allNodes
    private List<GameObject> singleNetwork(GameObject target, List<GameObject> allNodes)
	{
        List<GameObject> todo = new List<GameObject>(); // HashSet not possible because of removing
        todo.Add(target);
		while (todo.Count > 0)
		{
            // pop topmost target from List
            GameObject current = todo[0];
            todo.RemoveAt(0);

            // add target and prepare neighbors if not already in list
			if (!allNodes.Contains(current))
			{
                allNodes.Add(current);
                List<GameObject> neighbors = current.GetComponent<WaypointNeighbors>().neighbors;
				foreach (GameObject neighbor in neighbors) // add neighbors to todo list
				{
					if (!todo.Contains(neighbor) && neighbor != current)
					{
                        todo.Add(neighbor);
					}
				}
			}
		}
        return allNodes;
	}
}
