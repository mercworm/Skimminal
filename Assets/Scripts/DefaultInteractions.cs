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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (tag == "FrontDoor")
        {
            if (collision.gameObject.CompareTag ("Player"))
            {
                EventManager.TriggerEvent("OnExitLevelMenu");
            }
        }

        if (tag == "EdwardDoor")
        {
            if (collision.gameObject.CompareTag ("Player"))
            {
                EventManager.TriggerEvent("OnLevelSelectMenu");
            }
        }
    }
}
