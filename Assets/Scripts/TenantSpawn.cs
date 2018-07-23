using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenantSpawn : MonoBehaviour {

    public float timeLeft;
    public float keySoundTime;

    public Transform AISpawnPoint;
    public GameObject AICharacter;

    //private void OnEnable()
    //{
      //  EventManager.StartListening("OnNewLevel", TimeLeftChange);
    //}

    // Update is called once per frame
    void Update () {

        timeLeft -= Time.deltaTime;

        if (timeLeft == keySoundTime)
        {
            //Play Audio clip of the door rattling.
        }

        if (timeLeft == 0)
        {
            Instantiate(AICharacter, AISpawnPoint);
        }
	}

    void TimeLeftChange()
    {
        timeLeft -= 3;
    }
}