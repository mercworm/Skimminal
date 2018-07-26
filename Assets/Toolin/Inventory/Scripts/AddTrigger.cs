using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTrigger : MonoBehaviour {

    public GameObject[] triggers;


	void Start ()
    {
        triggers = GameObject.FindGameObjectsWithTag("PlayableAudio");

        for (int i = 0; i < triggers.Length; i++)
        {
            SphereCollider sC = triggers[i].AddComponent(typeof(SphereCollider)) as SphereCollider;
            sC.isTrigger = true;
            sC.radius = 1.5f;
        }
    }
	
}
