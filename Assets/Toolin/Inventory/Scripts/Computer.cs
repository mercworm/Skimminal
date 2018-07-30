using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Computer : MonoBehaviour
{
    public ParticleSystem doneEffect;

    public bool _hasUploaded = false;
    public bool HasUploaded
    {
        get
        {
            return _hasUploaded;
        }

        set
        {
            _hasUploaded = value;

            if(_hasUploaded)
            {
                doneEffect.Play();
            }
        }
    }
    public float uploadTime;
    [HideInInspector]
    public float curTime;
    [HideInInspector]
    public GameObject loadbar;

    public void Start()
    {
        loadbar = GameObject.Find("LoadBar");
        doneEffect = GetComponent<ParticleSystem>();
    }
}
