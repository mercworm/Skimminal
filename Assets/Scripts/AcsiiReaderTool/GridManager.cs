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

    public Vector3 tileSize;

    private static bool created = false;
    public static GridManager instance;

    public Node[,] gridTiles;

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
    }


    /// <summary>
    /// This is a test function for Invoking the tool.
    /// Takes in a string and tries to parse to int, then calls the ReadFile and AsciiReader Parser with that file index.
    /// TODO: Make a front-end menu that controls which file to load instead. Then remove this function from build.
    /// </summary>
    /// <param name="test">The index of the file to read</param>
    public void InvokeReadFileIndex(string test)
    {
        int index;
        if (int.TryParse(test, out index))
        {
            LoadLevelGrid(index);
        }

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
        outNode = currentPos; // for safety, don't return null
        //int arrayIndex = System.Array.IndexOf(gridTiles, currentPos);
        //int arrayIndexRow = arrayIndex % gridTiles.GetLength(0);
        //int arrayIndexColumn = arrayIndex / gridTiles.GetLength(1);

        int targetIndexRow;
        int targetIndexColumn;

        switch (direction)
        {
            case Direction.Up:
                targetIndexRow = currentPos.y - 1;
                targetIndexColumn = currentPos.x;
                break;
            case Direction.Down:
                targetIndexRow = currentPos.y + 1;
                targetIndexColumn = currentPos.x;
                break;
            case Direction.Left:
                targetIndexRow = currentPos.y;
                targetIndexColumn = currentPos.x - 1;
                break;
            case Direction.Right:
                targetIndexRow = currentPos.y;
                targetIndexColumn = currentPos.x + 1;
                break;
            default:
                targetIndexRow = currentPos.y;
                targetIndexColumn = currentPos.x;
                break;
        }

        if (targetIndexRow < 0)
        {
            Debug.Log("Target off grid.");
            return false;
        }
        else if (targetIndexColumn < 0)
        {
            Debug.Log("Targetoff grid.");
            return false;
        }
        else if (targetIndexRow > gridTiles.GetLength(0))
        {
            Debug.Log("Target off grid.");
            return false;
        }
        else if (targetIndexRow > gridTiles.GetLength(1))
        {
            Debug.Log("Target off grid.");
            return false;
        }
        else if(!(gridTiles[targetIndexRow, targetIndexColumn].GetWalkable()))
        {
            Debug.Log("Target Node not walkable");
            return false;
        }

        outNode = gridTiles[targetIndexRow, targetIndexColumn];
        if(outNode == null)
        {
            Debug.LogError("Target position Node is missing.");
        }
        return true;
    }
}
