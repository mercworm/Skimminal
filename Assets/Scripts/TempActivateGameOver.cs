using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempActivateGameOver : MonoBehaviour {

	public void GameOver ()
    {
        EventManager.TriggerEvent("OnPlayerSpotted");
    }
}
