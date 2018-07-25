using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGridMovement : MonoBehaviour {

    public AgentMovement agent;
    public int lastDirection;
    int directionCount = System.Enum.GetValues(typeof(Direction)).Length;

    // Use this for initialization
    void Start () {
        agent = GetComponent<AgentMovement>();
        lastDirection = (int)agent.nextDirection;
	}
	
	// Update is called once per frame
	void Update () {

        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    agent.nextDirection = Direction.Up;
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    agent.nextDirection = Direction.Down;
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    agent.nextDirection = Direction.Left;
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    agent.nextDirection = Direction.Right;
        //}

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            lastDirection--;
            lastDirection += directionCount;
            lastDirection %= directionCount;
            agent.nextDirection = (Direction)lastDirection;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            lastDirection++;
            lastDirection += directionCount;
            lastDirection %= directionCount;
            agent.nextDirection = (Direction)lastDirection;
        }
    }
}
