using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpawn : MonoBehaviour {

    public GridManager gridManager;
    private string levelNumber;
    private string currentSceneName;

    public string levelAlcimus, levelBingk, levelEliott, levelFlorence, levelJenny, levelNellie, levelPhilip, levelRyann, levelWesley;

    private void OnEnable()
    {
        EventManager.StartListening("OnNewLevel", LevelSpawning);
    }

    //I swear there's a better way to do this, but URGH. This is what I get for using strings.
    //Spawns different layouts depending on the name of the scene. 
    //Layout numbers are put in the inspector.
    public void LevelSpawning ()
    {
        currentSceneName = SceneManager.GetActiveScene().name;

        if (currentSceneName == "Alcimus")
        {
            levelNumber = levelAlcimus;
        }
        else if (currentSceneName == "Bingk")
        {
            levelNumber = levelBingk;
        }
        else if (currentSceneName == "Elliott")
        {
            levelNumber = levelEliott;
        }
        else if (currentSceneName == "Florence")
        {
            levelNumber = levelFlorence;
        }
        else if (currentSceneName == "Jenny")
        {
            levelNumber = levelJenny;
        }
        else if (currentSceneName == "Nellie")
        {
            levelNumber = levelNellie;
        }
        else if (currentSceneName == "Philip")
        {
            levelNumber = levelPhilip;
        }
        else if (currentSceneName == "Ryann")
        {
            levelNumber = levelRyann;
        }
        else if (currentSceneName == "Wesley")
        {
            levelNumber = levelWesley;
        }
        else
            return;

        gridManager.InvokeReadFileIndex(levelNumber);
    }
}
