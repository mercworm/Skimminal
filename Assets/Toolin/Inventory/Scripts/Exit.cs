using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Exit : MonoBehaviour
{
    public UnityEvent exit;

    public void OnTriggerStay()
    {
        exit.Invoke();
    }
}
