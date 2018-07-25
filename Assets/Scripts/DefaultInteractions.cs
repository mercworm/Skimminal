using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultInteractions : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (tag == "FrontDoor")
        {
            if (collision.gameObject.CompareTag ("Player"))
            {

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
