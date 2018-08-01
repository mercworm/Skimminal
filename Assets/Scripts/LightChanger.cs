using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class LightChanger : MonoBehaviour {

    public PostProcessingProfile litApartment;

    private void OnEnable()
    {
        EventManager.StartListening("OnTenantSpawn", LightSwitch);
    }

    private void OnDisable()
    {
        EventManager.StopListening("OnTenantSpawn", LightSwitch);
    }

    public void LightSwitch ()
    {
        var mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        var postProfile = mainCamera.GetComponent<PostProcessingBehaviour>();

        postProfile.profile = litApartment;

    }
}
