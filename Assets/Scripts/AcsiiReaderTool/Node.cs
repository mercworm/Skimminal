using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    public bool walkable = true;
    public List<AgentMovement> agentsOnLocation;
    public int x, y;

    public bool GetWalkable()
    {
        if(agentsOnLocation.Count > 0)
        {
            return false;
        }
        for(int i = 0; i < agentsOnLocation.Count; i++)
        {

        }
        return walkable;
    }

    public void AddToList(AgentMovement agentToAdd)
    {
        agentsOnLocation.Add(agentToAdd);
    }

    public void RemoveFromList(AgentMovement agentToRemove)
    {
        agentsOnLocation.Remove(agentToRemove);
    }
}
