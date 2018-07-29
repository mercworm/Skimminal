using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTimer : MonoBehaviour {

    public float countdown;
    public float doorOpenTime;
    public bool doorOpen;

    public Animator anim;

    private void OnEnable()
    {
        EventManager.StartListening("OnPlayerDoor", DoorAnimations);
    }

    public void DoorAnimations ()
    {
        doorOpen = true;
        if (countdown == 0)
        {
            anim.SetTrigger("OpenDoor");
        }
        else
        {
            countdown = doorOpenTime;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (doorOpen == true)
        {
            countdown -= Time.deltaTime;
            if (countdown == 0)
            {
                anim.SetTrigger("CloseDoor");
            }
        }
	}
}
