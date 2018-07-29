﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TenantSpawn : MonoBehaviour {

    public float startTime;
    public float timeLeft;
    public float keySoundTime;

    public Transform AISpawnPoint;
    public GameObject AICharacter;

    public bool spawnGO = false;

    //Start listening to find out when a new level has been started.
    private void OnEnable()
    {
        EventManager.StartListening("OnTenantCountdown", CountdownStart);
        EventManager.StartListening("OnLevelComplete", EndEverything);
    }

    // Update is called once per frame
    void Update () {

        //Only starts counting down when the new level has spawned.
        if (spawnGO)
        {
            timeLeft -= Time.deltaTime;

            if (timeLeft == keySoundTime)
            {
                //Play Audio clip of the door rattling.
            }

            if (timeLeft == 0)
            {
                spawnGO = false;
                if (AISpawnPoint != null)
                {
                    Instantiate(AICharacter, AISpawnPoint);
                }
                else
                {
                    Debug.LogError("The AI can't find anywhere to spawn!");
                }
            }
        }
	}

    //Set time left to a default starttime. 
    //Tell the rest of the script the level has spawned. 
    void CountdownStart()
    {
        timeLeft = startTime;
        spawnGO = true;

        //Finds the spot where the AI should spawn when the time is up.
        var AISpawn = GameObject.FindGameObjectWithTag("AISpawn").transform;
        AISpawnPoint = AISpawn;
    }

    public void EndEverything ()
    {
        spawnGO = false;
        AISpawnPoint = null;
    }
}