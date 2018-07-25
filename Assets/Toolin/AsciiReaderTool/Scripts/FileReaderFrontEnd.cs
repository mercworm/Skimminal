using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class FileReaderFrontEnd : MonoBehaviour
{
    public FileReader fR;
    private List<string> dropOptions = new List<string>();
    public Dropdown dropDown;
    private GridManager gridManager;
    private int levelIndex;
    private bool hasBeenPressed;
    //[HideInInspector]
    public string levelName;
  

    void Start()
    {
        fR = GetComponent<FileReader>();
        gridManager = GetComponent<GridManager>();
        dropDown.ClearOptions();

        for (int i = 0; i < fR.fileInfo.Length; i++)
        {
            levelName = fR.fileInfo[i].Name.Remove(fR.fileInfo[i].Name.Length -4, 4);
            dropOptions.Add(levelName); 
        }
        dropDown.AddOptions(dropOptions);
        ScrollChanged(0);
    }

/// <summary>
/// Clears drop down box of data
/// Adds the file names from streaming assets to a list 
/// Adds that list data to the drop down options
/// </summary>
/// 
    public void ScrollChanged(int i)
    {
        levelIndex = i;
    }

    public void LoadFileIndex()
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        SceneManager.LoadScene(fR.fileInfo[levelIndex].Name.Remove(fR.fileInfo[levelIndex].Name.Length - 4, 4));
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        gridManager.InvokeReadFileIndex(levelIndex);
        Destroy(this.gameObject, 1);
    }
}

/// <summary>
/// Gets the value of the drop downbox and converts to string
/// Adds a new scene equal to the current name value of dropdown box
/// Invokes the grid manager passing through the current level index
/// </summary>