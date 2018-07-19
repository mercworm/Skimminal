using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour {

    public Node currentNode;

    public Direction direction;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddToNodeList()
    {
        if (!currentNode)
        {
            return;
        }
        currentNode.AddToList(this);
    }

    public void MoveAgent()
    {
        Node targetNode;
        if (GridManager.instance.CheckMove(currentNode, direction, out targetNode))
        {
            currentNode.RemoveFromList(this);
            currentNode = targetNode;
            currentNode.AddToList(this);
            Debug.Log("I can move!");
        }
        else
        {
            Debug.Log("I can't move.");
        }
    }
}
