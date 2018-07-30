using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInteractions : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (tag == "Door")
        {
            if (other.gameObject.CompareTag("Player"))
            {
                EventManager.TriggerEvent("OnPlayerDoor");
                Debug.Log("Player triggered door!");
            }
        }

        if (tag == "FrontDoor")
        {
            if (other.gameObject.CompareTag("Player"))
            {
                EventManager.TriggerEvent("OnExitLevelMenu");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (tag == "EdwardDoor")
        {
            if (collision.gameObject.CompareTag ("Player"))
            {
                EventManager.TriggerEvent("OnLevelSelectMenu");
            }
        }
    }
}
