using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static string noteName;

    private void OnEnable()
    {
        EventManager.StartListening("UpdateRelationships", CheckName);
    }

    private void Start()
    {

    }

    //This function takes care of updating all of the relationship points, depending on which note was posted. 
    //It also notifies the Fakebook script, so the panels are updated correctly.
    public void CheckName ()
    {
        if (noteName.StartsWith("Alcimus"))
        {
            Debug.Log("FoundAlcimus");
            if (noteName.EndsWith("Note1"))
            {
                EventManager.TriggerEvent("Alcimus1");
                Debug.Log("Triggered event!");
            }
            else if (name.EndsWith("Note2"))
            {
                EventManager.TriggerEvent("Alcimus2");
            }
            else if (name.EndsWith("Note3"))
            {

            }
            else if (name.EndsWith("Note4"))
            {

            }
            else
            {

            }
        }
    }
}
