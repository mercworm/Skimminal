using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class LevelSpawn : MonoBehaviour {

    public GridManager gridManager;
    
    //The varaibles that hold the string that we will use in the event later.
    private int levelNumber;
    private string currentSceneName;

    public int levelAlcimus, levelBingk, levelEliott, levelFlorence, levelJenny, levelNellie, levelPhilip, levelRyann, levelWesley, levelEdward;

    //We want to call this every time a new level starts.
    private void OnEnable()
    {
        EventManager.StartListening("OnNewLevel", LevelSpawning);
    }

    //Spawn the level for the first time.
    private void Start()
    {
        LevelSpawning();
    }

    //I swear there's a better way to do this, but URGH. This is what I get for using strings.
    //Spawns different layouts depending on the name of the scene. 
    //Layout numbers are put in the inspector.
    public void LevelSpawning ()
    {
        //Get name of the scene, so we can add the correct layout.
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
            levelNumber = levelEdward;

        //Spawn event with the correct number. 
        gridManager.InvokeReadFileIndex(levelNumber);

        if (currentSceneName != "EdwardsRoom")
        {
            EventManager.TriggerEvent("OnTenantCountdown");
        }
    }
}
