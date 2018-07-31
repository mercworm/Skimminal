using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fakebook : MonoBehaviour {

    public GameObject fakebook;
    bool isOpening = false;

    private void OnEnable()
    {
        EventManager.StartListening("OnFakebook", StartFakebook);
    }

    public void StartFakebook ()
    {
        fakebook.SetActive(true);
    }
}
