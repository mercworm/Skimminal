using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTrigger : MonoBehaviour {

    private GameObject[] triggersAudio;
    private GameObject[] triggersItems;
    public List<GameObject> triggers = new List<GameObject>();

    void Start()
    {
        triggersAudio = GameObject.FindGameObjectsWithTag("PlayableAudio");
        triggersItems = GameObject.FindGameObjectsWithTag("Item");

        if (triggersAudio.Length > 0)
        {
            for (int i = 0; i < triggersAudio.Length; i++)
            {
                triggers.Add(triggersAudio[i]);
            }
        }
        else
        {
            Debug.LogError("There is no PlayableAudio tags in the scene");
        }
        if (triggersItems.Length > 0)
        {
            for (int i = 0; i < triggersItems.Length; i++)
            {
                triggers.Add(triggersItems[i]);
            }
        }
        else
        {
            Debug.LogError("There is no Item tags in the scene");
        }

        for (int i = 0; i < triggers.Count; i++)
        {
            SphereCollider sC = triggers[i].AddComponent(typeof(SphereCollider)) as SphereCollider;
            sC.isTrigger = true;
            sC.radius = 1.5f;
        }
    }
}
