using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Inventory))]
public class Computer : MonoBehaviour
{
    public bool hasUploaded = false;
    public float uploadTime;
    [HideInInspector]
    public float curTime;
    [HideInInspector]
    public GameObject loadbar;

    public void Start()
    {
        loadbar = GameObject.Find("LoadBar");
    }
}
