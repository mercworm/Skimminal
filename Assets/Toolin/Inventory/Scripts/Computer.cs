using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Computer : MonoBehaviour
{
    public ParticleSystem doneEffect;

    [SerializeField] 
    private bool _hasUploaded = false;
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
                NoteUploaded();
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

    public void NoteUploaded ()
    {
        //var score = GetComponent<Inventory>().Items[0].
    }
}
