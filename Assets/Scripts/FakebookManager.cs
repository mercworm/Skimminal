using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakebookManager : MonoBehaviour {

    public GameObject[] profiles;
    public GameObject friendsList;

    public GameObject profileGroup;

    private bool profileOpen = false;
    private bool listOpen = false;

    //takes all of the profiles avaliable in the array
    //checks which one has the same name as the button calling the function
    //enables it
    public void OpenProfile (string buttonName)
    {
        foreach (GameObject profile in profiles)
        {
            if (profile.name.EndsWith(buttonName))
            {
                profile.gameObject.SetActive(true);
                profileOpen = true;
                return;
            }
        }
    }

    //called when the player moves from the feed to the friendslist
    public void OpenFriendsList ()
    {
        friendsList.SetActive(true);
        listOpen = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (profileOpen == true)
            {
                profileOpen = false;
                for (int i = 0; i < profileGroup.transform.childCount; i++)
                {
                    var child = profileGroup.transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(false);
                }
            }
            else if (listOpen == true)
            {
                listOpen = false;
                friendsList.SetActive(false);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        if (Input.GetKeyDown (KeyCode.RightArrow))
        {
            if (!profileOpen && !listOpen)
            {
                OpenFriendsList();
            }
        }
    }
}
