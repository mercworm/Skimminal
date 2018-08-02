using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;

public class InventoryOverSeer : MonoBehaviour
{
    public ScriptableItemCollection sIC;
    public GameObject[] itemLocations;
    public ScriptableItem[] items;
    public ScriptableItem[] assignItems;
    private Computer computer;

    [HideInInspector]
    public string levelName;
    [HideInInspector]
    public int index = 0;

    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        assignItems = sIC.sI;
        itemLocations = GameObject.FindGameObjectsWithTag("Item");
        items = new ScriptableItem[itemLocations.Length];

        for (int i = 0; i < assignItems.Length; i++)
        {
            if (assignItems[i].name.StartsWith(levelName)) // checks if the name of the item is equal to the level name + plus the item removing the level name off it
            {           
                itemLocations[index].GetComponent<Inventory>().Items[0] = assignItems[i]; //applies that item to the item location index
                items[index] = itemLocations[index].GetComponent<Inventory>().Items[0]; // applies to the overseers data
                index++; //seperate index for applying to itemlocations 
            }    
        }
   
    }
    
    public void ItemsCurrentLocations()
    {
        computer = FindObjectOfType<Computer>();

        if (computer != null && computer.HasUploaded == true)
        {
                    Debug.Log("All in place");
                    PlayerPrefs.SetInt(levelName, 1);

            for (int i = 0; i < itemLocations.Length; i++)
            {
                var item = itemLocations[i].GetComponent<Inventory>();

                if (item.Mylocation == item.Items[0].name)
                //Checks if all items in the list are the same as their string locations and if the uploaded item to the computer has the winCondition
                {
                }
                else
                {
                    Debug.Log("Hey! stuffs been moved");
                    PlayerPrefs.SetInt(levelName, 0);
                }
            }
        }
    }
    /// <summary>
    /// Grabs scriptable objects in project from file location
    /// loads all assets at that path
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
   
}

/*
 * Sets the level name of the active scene
 * Grabs the objects and items attached to them and stores them
 * checks if the computer has uploaded
 * checks if the items are in the correct location
 * checks if the right thing was uploaded
 * Saves the data in player prefs according to win condition 
 */
