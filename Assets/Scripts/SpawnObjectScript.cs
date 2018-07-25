using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectScript : MonoBehaviour {

    private void OnEnable()
    {
        EventManager.TriggerEvent("OnNewLevel");
    }
}
