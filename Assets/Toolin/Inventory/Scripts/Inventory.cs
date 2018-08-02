using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public List<ScriptableItem> Items = new List<ScriptableItem>();
    public bool activateLocation;
    public string Mylocation;
    private List<ScriptableItem> objItems;


    public void Swap(GameObject ObjectsItem)
    {
        objItems = ObjectsItem.GetComponent<Inventory>().Items;
        objItems.InsertRange(1, objItems);
        Items.InsertRange(1, Items);
        Items[0] = objItems[0];
        objItems[1] = Items[1];
        Items.RemoveAt(1);
        objItems.RemoveAt(0);
    }

    public void OnSceneLoad()
    {
        if (activateLocation == true)
        {
            if (Items[0] != null)
            {
                Mylocation = Items[0].name;
            }
        }
    }
}
/*
 * Create a list of items
 * Checks if the user want to know if this is a container that spawned an item to begin with
 * Swaps items between container and player
 * Inserts range so that the trade can take place (ie trading between one slot has issues)
 * Then removes the excess
 */
