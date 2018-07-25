using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour {

    private static bool created = false;
    public static AgentManager instance;

    public float tickTime = 1f;
    private float timer;

    public List<AgentMovement> agentList;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }

        if (!created)
        {
            //DontDestroyOnLoad(this.gameObject);
            created = true;
            Debug.Log("Awake: " + this.gameObject);

        }
    }

    public void AddToList(AgentMovement agentToAdd)
    {
        agentList.Add(agentToAdd);
    }

    public void RemoveFromList(AgentMovement agentToRemove)
    {
        agentList.Remove(agentToRemove);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= tickTime)
        {
            timer = 0;
            MoveAllAgents();
        }		
	}



    public void MoveAllAgents()
    {
        for (int i = 0; i < agentList.Count; i++)
        {
            //Declare moves
            agentList[i].DeclareMove();
        }
        for (int i = 0; i < agentList.Count; i++)
        {
            //Rules
            GridManager.instance.HandleAgentsOnNodes();
        }
        for (int i = 0; i < agentList.Count; i++)
        {
            agentList[i].MoveAgent();
            //Move Agents
        }
    }

}
