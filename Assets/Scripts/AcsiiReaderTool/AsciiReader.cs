using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsciiReader : MonoBehaviour
{

    public AsciiDictionary asciiMapArray;
    public Dictionary<char, GameObject> asciiDictionary = new Dictionary<char, GameObject>();


    // Use this for initialization
    void Start()
    {
        //Generate the Ascii Dictionary
        for (int i = 0; i < asciiMapArray.asciiDictionary.Length; i++)
        {
            asciiDictionary.Add(asciiMapArray.asciiDictionary[i].asciiCharacter, asciiMapArray.asciiDictionary[i].tilePrefab);
        }

    }

    /// <summary>
    /// Converts an array of strings into a multidimensional array of prefabs.
    /// Function uses the attached <see cref="AsciiDictionary"/> to find matching prefabs to chars.
    ///
    /// </summary>
    /// <param name="mapText">The array of strings to pass in.</param>
    /// <returns>Returns a multidimensional array of prefabs, equal to the size of the passed value.</returns>
    public GameObject[,] ParseTextToPrefab(string[] mapText)
    {
        int xLength, yLength;
        CheckArrayLengths(mapText, out xLength, out yLength);
        Debug.Log("Size of mapText = " + xLength + "," + yLength);
        GameObject[,] prefabArray = new GameObject[xLength, yLength];
        for (int y = 0; y < mapText.Length; y++)
        {
            var line = mapText[y];
            for (int x = 0; x < line.Length; x++)
            {
                var character = line[x];
                GameObject prefabToSpawn;
                if (asciiDictionary.TryGetValue(character, out prefabToSpawn))
                {
                    prefabArray[x, y] = prefabToSpawn;
                    //Debug.Log(x + "," + y);
                }
                else
                {
                    Debug.LogError(character + " not found in dictionary");
                }
            }
        }
        return prefabArray;
    }

    /// <summary>
    /// Takes in an array of strings and returns the lengths of the longest line and the amount of lines.
    /// Use for finding the X,Y size for a 2D array.
    /// Will throw Error
    /// </summary>
    /// <param name="mapText">The array of strings to pass in.</param>
    /// <param name="xLength">Out the length of the longest string line.</param>
    /// <param name="yLength">Out the count of lines in the string array.</param>
    public void CheckArrayLengths(string[] mapText, out int xLength, out int yLength)
    {
        if(mapText.Length == 0)
        {
            Debug.LogWarning("Empty map text.");
            //return;
        }
        xLength = 0;
        yLength = mapText.Length;
        xLength = mapText[0].Length;
        for (int y = 0; y < mapText.Length; y++)
        {            
            if (xLength > mapText[y].Length)
            {
                xLength = mapText[y].Length;
                Debug.LogWarning("Line lengths in map not uniform in Length. If this is the intended design, there will be null cells in the prefab array.");
            }
        }
    }


}
