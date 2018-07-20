using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryOverSeer : MonoBehaviour
{
    public GameObject[] itemLocations;
    public ScriptableItem[] items;
    private GameObject Computer;
    private string levelName;

    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        for (int i = 0; i < itemLocations.Length; i++)
        {
            itemLocations = GameObject.FindGameObjectsWithTag("Item");
            items[i] = itemLocations[i].GetComponent<Inventory>().Items[0];
        }
        Computer = GameObject.FindGameObjectWithTag("Computer");
    }

    public void ItemsCurrentLocations()
    {
        if (Computer.GetComponent<Computer>().hasUploaded == true)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (itemLocations[i].GetComponent<Inventory>().Mylocation == itemLocations[i].GetComponent<Inventory>().Items[i].name && Computer.GetComponent<Inventory>().Items[0].winCondition == true)
                {
                    Debug.Log("All in place");
                    PlayerPrefs.SetInt(levelName, 1);
                }
                else
                {
                    Debug.Log("Hey! stuffs been moved");
                    PlayerPrefs.SetInt(levelName, 0);
                }
            }
        }
    }

}
/*
 * Sets the level name of the active scene
 * Grabs the objects and items attached to them and stores them
 * checks if the computer has uploaded
 * checks if the items are in the correct location
 * checks if the right thing was uploaded
 * Saves the data in player prefs according to win condition 
 */
