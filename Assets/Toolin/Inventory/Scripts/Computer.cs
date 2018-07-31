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

            if(_hasUploaded && onlyOnce)
            {
                NoteUploaded();
                doneEffect.Play();
                onlyOnce = false;
            }
        }
    }
    public float uploadTime;
    [HideInInspector]
    public float curTime;
    [HideInInspector]
    public GameObject loadbar;
    public bool onlyOnce = true;

    public void Start()
    {
        loadbar = GameObject.Find("LoadBar");
        doneEffect = GetComponent<ParticleSystem>();
    }

    public void NoteUploaded ()
    {
        var note = GetComponent<Inventory>().Items[0].name;
        ScoreManager.noteName = note;
        EventManager.TriggerEvent("UpdateRelationships");
    }
}
