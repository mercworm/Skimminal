using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Get the array of prefabs to spawn from the AsciiReader component
///Spawn all prefabs into a grid structure and store them
///Allow a tile size offset for grid
///Able to read the values on tiles(Check before movement)
///Singleton, can be accessed globally, only one
/// </summary>
public class GridManager : MonoBehaviour
{

    public AsciiReader asciiReader;
    public FileReader fileReader;

    public Vector3 tileSize = Vector3.one;

    private static bool created = false;
    public static GridManager instance;

    public Node[,] gridTiles;

    Dictionary<Node, Dictionary<Node, int>> paths = new Dictionary<Node, Dictionary<Node, int>>();

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

    // Use this for initialization
    void Start()
    {
        if (!(asciiReader = GetComponent<AsciiReader>()))
        {
            Debug.LogError("No Ascii Reader component found.");
        }
        if (!(fileReader = GetComponent<FileReader>()))
        {
            Debug.LogError("No File Reader component found.");
        }
        //Wait for file Index
    }

    //TODO: make sure the file to read is not hard coded as 0 or only the first file will load.

    public void LoadLevelGrid(int index)
    {
        if (asciiReader == null)
        {
            Debug.LogError("No Ascii Reader component found.");
            return;
        }

        SpawnGrid(asciiReader.ParseTextToPrefab(fileReader.ReadFile(index)));
    }

    public void SpawnGrid(GameObject[,] prefabArray)
    {
        gridTiles = new Node[prefabArray.GetLength(0), prefabArray.GetLength(1)];
        for (int y = 0; y < prefabArray.GetLength(1); y++) //This may or may not be the correct axis. Needs testing.
        {
            for (int x = 0; x < prefabArray.GetLength(0); x++)
            {
                GameObject newGO = Instantiate(prefabArray[x, y], new Vector3(x * tileSize.x, transform.position.y, -y * tileSize.z), prefabArray[x, y].transform.rotation);
                if (newGO.GetComponent<Node>() == null)
                {
                    Debug.LogWarning("No Node Component on prefab: " + prefabArray[x, y]);
                }
                else
                {
                    gridTiles[x, y] = newGO.GetComponent<Node>();
                    gridTiles[x, y].x = x;
                    gridTiles[x, y].y = y;
                }
            }
        }
        //Debug.Log(gridTiles.Length);

        //Populate a Dictionary with paths
        foreach (Node node in gridTiles)
        {
            Node targetNode;
            Dictionary<Node, int> validPaths = new Dictionary<Node, int>();
            int directionCount = System.Enum.GetValues(typeof(Direction)).Length;
            for (int i = 0; i < directionCount; i++)
            {
                Direction nextDirection = (Direction)i;

                if (CheckMove(node, nextDirection, out targetNode))
                {
                    validPaths.Add(targetNode, 1); //replace the 1 with a distance if nodes were further apart.
                }
                if (node != null)
                    paths[node] = validPaths;
            }
        }
    }


    /// <summary>
    /// This is a test function for Invoking the tool.
    /// Takes in a string and tries to parse to int, then calls the ReadFile and AsciiReader Parser with that file index.
    /// TODO: Make a front-end menu that controls which file to load instead. Then remove this function from build.
    /// </summary>
    /// <param name="test">The index of the file to read</param>
    public void InvokeReadFileIndex(int index)
    {
        LoadLevelGrid(index);
    }

    /// <summary>
    /// Checks if the target position is in the range of the grid.
    /// </summary>
    /// <param name="currentPos">The current position of the agent.</param>
    /// <param name="direction">The direction the agent wants to move in</param>
    /// <param name="outNode">The target position the agent wants to move in</param>
    /// <returns>True if target Node is valid.</returns>
    public bool CheckMove(Node currentPos, Direction direction, out Node outNode)
    {
        outNode = null;
        if (currentPos == null)
            return false;

        outNode = currentPos; // for safety, don't return null
        //int arrayIndex = System.Array.IndexOf(gridTiles, currentPos);
        //int arrayIndexRow = arrayIndex % gridTiles.GetLength(0);
        //int arrayIndexColumn = arrayIndex / gridTiles.GetLength(1);

        int targetYPos;
        int targetXPos;

        switch (direction)
        {
            case Direction.Up:
                targetYPos = currentPos.y - 1;
                targetXPos = currentPos.x;
                break;
            case Direction.Down:
                targetYPos = currentPos.y + 1;
                targetXPos = currentPos.x;
                break;
            case Direction.Left:
                targetYPos = currentPos.y;
                targetXPos = currentPos.x - 1;
                break;
            case Direction.Right:
                targetYPos = currentPos.y;
                targetXPos = currentPos.x + 1;
                break;
            default:
                targetYPos = currentPos.y;
                targetXPos = currentPos.x;
                break;
        }

        if (targetYPos < 0)
        {
            Debug.Log("Target off grid.");
            return false;
        }
        else if (targetXPos < 0)
        {
            Debug.Log("Targetoff grid.");
            return false;
        }
        else if (targetXPos >= gridTiles.GetLength(0))
        {
            Debug.Log("Target off grid.");
            return false;
        }
        else if (targetYPos >= gridTiles.GetLength(1))
        {
            Debug.Log("Target off grid.");
            return false;
        }
        else if(!(gridTiles[targetXPos, targetYPos].GetWalkable()))
        {
            Debug.Log("Target Node not walkable");
            return false;
        }

        outNode = gridTiles[targetXPos, targetYPos];
        if(outNode == null)
        {
            Debug.LogError("Target position Node is missing.");
        }
        return true;
    }

    public void HandleAgentsOnNodes()
    {
        for(int y = 0; y < gridTiles.GetLength(1); y++)
        {
            for (int x = 0; x < gridTiles.GetLength(0); x++)
            {
                gridTiles[x,y].HandleDeclaredAgents();
            }                
        }
    }

    /// <summary>
    /// Dijkstra's Algorithm for finding the shortest path between nodes.
    /// </summary>
    /// <param name="from">The starting <see cref="Node"/>.</param>
    /// <param name="end">The target <see cref="Node"/></param>
    /// <returns>The shortest path as a list of nodes from end to start.</returns>
    public List<Node> FindshortestPath(Node from, Node end, out int distance)
    {
        //initiliazation
        var distances = new Dictionary<Node, int>();
        var previous = new Dictionary<Node, Node>();
        List <Node> nodes = new List<Node>();
        List<Node> path = null;

        //Set all paths distances to max
        //Set then starting node to 0
        foreach (var m_path in paths)
        {
            if(m_path.Key == from)
            {
                distances[m_path.Key] = 0;
            }
            else
            {
                distances[m_path.Key] = int.MaxValue;
            }
            nodes.Add(m_path.Key); //Add all nodes to unexplored
        }

        while (nodes.Count != 0) //While nodes unexplored
        {
            nodes.Sort((x, y) => distances[x] - distances[y]); 
            var smallest = nodes[0]; //Select the first node
            nodes.Remove(smallest);  //First node set to explored

            //Find the shortest path and store it.
            if (smallest == end)
            {
                path = new List<Node>();
                // Construct the shortest path with a stack S
                while (previous.ContainsKey(smallest)) 
                {
                    path.Add(smallest); // Push the vertex onto the stack
                    smallest = previous[smallest]; // Traverse from target to source
                }

                break;
            }

            if (distances[smallest] == int.MaxValue)
            {
                break;
            }

            foreach (var neighbor in paths[smallest]) //Search the paths from the selected node.
            {
                var alt = distances[smallest] + neighbor.Value; //store the length of the path of neighbour
                if (alt < distances[neighbor.Key]) //Shorter path has been found
                {
                    distances[neighbor.Key] = alt;
                    previous[neighbor.Key] = smallest; 
                }
            }
        }
        distance = 0;
        foreach(var node in distances)
        {
            distance += node.Value;
        }
        return path;

    }

}
