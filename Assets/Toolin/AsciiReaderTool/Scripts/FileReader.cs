using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileReader : MonoBehaviour
{
    [Tooltip("The folder subpath inside of StreamingAssets folder. Don't change unless you've added subfolders inside the StreamingAssets folder.")]
    public string folderSubPath;
    public string fileTypeExtension = ".txt";


    //Make this public if you want to see the ASCII map loaded into the Inspector.
    private string[] mapText;
    private string text;

    [HideInInspector]
    public string filePath;
    [HideInInspector]
    public FileInfo[] fileInfo;

    private void Awake()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, folderSubPath);
        var info = new DirectoryInfo(filePath);
        fileInfo = info.GetFiles("*" + fileTypeExtension);
        Debug.Log(fileInfo.Length + " files found in " + filePath + ".");
        foreach (FileInfo file in fileInfo)
        {
            //Debug.Log(file.Name);
        }
    }
    void Start()
    {

    }

    /// <summary>
    /// Takes an index and reads the text in that file into a array of strings.
    /// </summary>
    /// <param name="fileIndex">The index of the file to load to string.</param>
    /// <returns>String[], new lines in file adds a new string to the array.</returns>
    public string[] ReadFile(int fileIndex)
    {
        if (fileInfo.Length == 0)
        {
            Debug.Log("No files loaded.");
            return null;
        }
        if (fileIndex >= fileInfo.Length || fileIndex < 0)
        {
            Debug.Log("File Index out of range.");
            return null;
        }
        //else index valid, continue

        if (fileInfo[fileIndex].Exists)
        {
            Debug.Log("File " + filePath + " loaded.");
            using (StreamReader sr = fileInfo[fileIndex].OpenText())
            {
                text = sr.ReadToEnd();
                mapText = text.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                return mapText;
            }
        }
        else
        {
            Debug.LogError("File path" + filePath + "does not exist.");
            return null;
        }
    }

    public int FileCount()
    {
        return fileInfo.Length;
    }

}
