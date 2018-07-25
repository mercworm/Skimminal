using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{

    public bool walkable = true;
    public List<AgentMovement> agentsOnLocation;
    public List<AgentMovement> declaredAgents;
    public int x, y;

    public bool GetWalkable()
    {
        if (agentsOnLocation.Count > 0)
        {
            //return false; //Disabled this because Agents movement is now broken down into declare, handle rules, 
        }
        for (int i = 0; i < agentsOnLocation.Count; i++)
        {
            //Could check if player moves into an occupied square here.
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

    public void AddToDeclaredAgents(AgentMovement agentToAdd)
    {
        declaredAgents.Add(agentToAdd);
    }

    public void ClearDeclaredAgents()
    {
        declaredAgents.Clear();
    }

    public void HandleDeclaredAgents()
    {
        //Priority happens here.
        
        if (declaredAgents.Count == 0)
        {
            return;
        }
        declaredAgents.Sort(SortAgentPriority);
        for (int i = 0; i < declaredAgents.Count; i++)
        {
            //If any agents are not moving they get priority.
            if (declaredAgents[i].isNotMoving)
            {
                //First priority agent moved into agent.
                declaredAgents[0].movedIntoAgent = true;
            }
        }
        //First agent gets priority, rest can't move onto Node.
        //declaredAgents[0].
        for (int i = 1; i < declaredAgents.Count; i++)
        {
            declaredAgents[i].movedIntoAgent = true;
        }
        ClearDeclaredAgents();
    }

    public int SortAgentPriority(AgentMovement a1, AgentMovement a2)
    {
        return a1.movePriority.CompareTo(a2.movePriority);
    }
}
