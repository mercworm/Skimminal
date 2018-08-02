using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMyLocation : MonoBehaviour {

	public void DoIt ()
    {
        var res = FindObjectsOfType<Inventory>();

        foreach (var item in res)
        {
            item.OnSceneLoad();
        }
    }
}
