using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakebookManager : MonoBehaviour {

    public GameObject[] profiles;
    public string buttonName;

	// Use this for initialization
	void Start () {
        buttonName = gameObject.name;
	}

    //takes all of the profiles avaliable in the array
    //checks which one has the same name as the button
    //enables it
    void OpenProfile ()
    {
        foreach (GameObject profile in profiles)
        {
            if (profile.name.EndsWith(buttonName))
            {
                profile.gameObject.SetActive(true);
                return;
            }
        }
    }
}
