using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMusicSwitch : MonoBehaviour {

    public AudioClip run;
    AudioSource source;

    private void OnEnable()
    {
        EventManager.StartListening("OnTenantSpawn", Music);
    }

    // Use this for initialization
    void Start () {
        source = GetComponent<AudioSource>();
	}

    public void Music ()
    {
        source.clip = run;
        source.Play();
    }
}
