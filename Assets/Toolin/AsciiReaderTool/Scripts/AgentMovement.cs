using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AgentMovement : MonoBehaviour
{

    public Node currentNode;
    public int test_targetX, test_targetY;

    public LeanTweenType tweenType = LeanTweenType.linear;
    public float moveTime;
    [Tooltip("The priority of the movment, 0 being higher priority than 1." +
        "\nCan go into negatives." +
        "\nA higher priority agent will move before a lower priority agent.")]
    public int movePriority;

    public Vector3 myOffset;

    public bool CanMove = true;
    public bool isPlayer = false;

    private Node targetNode;
    [HideInInspector]
    public Direction nextDirection;
    [HideInInspector]
    public bool movedIntoAgent = false;
    [HideInInspector]
    public bool isNotMoving = false;

    public string[] findByTagList;

    public List<Node> path;

    //move this to it's own script


    // Use this for initialization
    void Start()
    {
        AgentManager.instance.AddToList(this);
        //int distance;
        //path = GridManager.instance.FindshortestPath(currentNode, GridManager.instance.gridTiles[test_targetX, test_targetY], out distance);
        List<GameObject> gameObjectsFoundByTag = new List<GameObject>();
        var paths = new List<PathData>();
        for (int i = 0; i < findByTagList.Length; i++)
        {
            gameObjectsFoundByTag.AddRange(GameObject.FindGameObjectsWithTag(findByTagList[i]));
        }
        for (int i = 0; i < gameObjectsFoundByTag.Count; i++)
        {
            Node waypointNode;
            if (waypointNode = gameObjectsFoundByTag[i].GetComponent<Node>())
            {
                int pathDist = 0;
                PathData pathData = new PathData();
                pathData.endNode = waypointNode;
                pathData.path = GridManager.instance.FindshortestPath(currentNode,waypointNode, out pathDist);
                pathData.distance = pathDist;
                paths.Add(pathData);
            }
            else
            {
                //TODO: add more detail to the debug
                Debug.LogWarning("No Node component found on Gameobject found by tag.\n This error needs more detail.");
            }
        }
        //Sort the path
        paths.OrderBy(x => x.distance);
        if(paths.Count != 0)
        {
            path = paths[0].path;
        }        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToNodeList()
    {
        if (!currentNode)
        {
            return;
        }
        currentNode.AddToList(this);
    }

    public Direction RandDirection()
    {
        int rand = Random.Range(0, 4);
        Direction direction;
        switch (rand)
        {
            case 0:
                direction = Direction.Up;
                break;
            case 1:
                direction = Direction.Down;
                break;
            case 2:
                direction = Direction.Left;
                break;
            case 3:
                direction = Direction.Right;
                break;
            default:
                //this one shouldn't happen.
                direction = nextDirection;
                break;
        }
        return direction;
    }

    public void DeclareMove()
    {

        movedIntoAgent = false;
        isNotMoving = false;
        if (!CanMove)
        {
            return;
        }

        //if not player
        //target is last node in path
        //Declare target
        //If player
        //Check move if valid
        //if not valid, player cannot move
        if (!isPlayer)
        {
            if (path.Count == 0 || path == null)
            {
                //No Path or agent on target
                targetNode = currentNode;
                isNotMoving = true;
                targetNode.AddToDeclaredAgents(this);
                return;
            }
            targetNode = path[path.Count - 1];
            targetNode.AddToDeclaredAgents(this);
            return;
        }
        else if (GridManager.instance.CheckMove(currentNode, nextDirection, out targetNode))
        {
            targetNode.AddToDeclaredAgents(this);
            return;
        }
        else
        {
            //Player hit wall
            isNotMoving = true;
            currentNode.AddToDeclaredAgents(this);
            Debug.Log("I can't move.");
        }
        //else
        //{
        //    //Try other directions
        //    int directionCount = System.Enum.GetValues(typeof(Direction)).Length;
        //    for(int i = 0; i < directionCount; i++)
        //    {
        //        nextDirection = (Direction)i;
        //        if (GridManager.instance.CheckMove(currentNode, nextDirection, out targetNode))
        //        {
        //            targetNode.AddToDeclaredAgents(this);
        //            return;
        //        }
        //    }
        //}
    }

    public void MoveAgent()
    {
        if (movedIntoAgent)
        {
            Debug.Log(gameObject + " moved into another agent.");
            return;
        }
        if (targetNode == null)
        {
            return;
        }
        Debug.Log("Moved from: " + currentNode.x + "," + currentNode.y);
        currentNode.RemoveFromList(this);
        currentNode = targetNode;
        currentNode.AddToList(this);
        CanMove = false;
        LeanTween.moveLocal(gameObject, currentNode.transform.position + myOffset, moveTime)
            .setEase(tweenType)
            .setOnComplete(() => CanMove = true);
        Debug.Log("Moved to: " + currentNode.x + "," + currentNode.y);
        if (path.Count != 0)
        {
            path.RemoveAt(path.Count - 1);
        }
    }


}
