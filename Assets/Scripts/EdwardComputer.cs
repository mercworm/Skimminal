using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdwardComputer : MonoBehaviour {

    Computer regularComputerScript;
    Inventory inv;

    bool panelActive = false;

    private void OnEnable()
    {
        EventManager.StartListening("OnEdwardComputer", Fakebook);
        EventManager.StartListening("OnFinalLevel", ScriptSwitch);
    }

    private void OnDisable()
    {
        EventManager.StopListening("OnEdwardComputer", Fakebook);
        EventManager.StopListening("OnFinalLevel", ScriptSwitch);
    }
   
    // Use this for initialization
    void Start () {
        regularComputerScript = GetComponent<Computer>();
        inv = GetComponent<Inventory>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fakebook ()
    {
        panelActive = true;
        EventManager.TriggerEvent("OnFakebook");
        Debug.Log("Started Fakebook");
    }

    public void ScriptSwitch ()
    {
        regularComputerScript.enabled = true;
        inv.enabled = true;
        this.enabled = false;
    }
}
