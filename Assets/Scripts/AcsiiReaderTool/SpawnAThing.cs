using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAThing : MonoBehaviour {

    public GameObject prefabToSpawn;
    public bool childToThis = false;
    public Vector3 spawnOffset;

	// Use this for initialization
	void Start () {
        GameObject newGO = Instantiate(prefabToSpawn, transform.position + spawnOffset, prefabToSpawn.transform.rotation);
        AgentMovement agentMovementComponent = newGO.GetComponent<AgentMovement>();
        Node thisNode = GetComponent<Node>();
        if(agentMovementComponent != null && thisNode != null)
        {
            agentMovementComponent.currentNode = thisNode;
            agentMovementComponent.AddToNodeList();
            agentMovementComponent.MoveAgent(); //delete this later
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
