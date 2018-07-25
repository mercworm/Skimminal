using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTester : MonoBehaviour
{
    public AudioEffectSO audioEffectSO;
    public KeyCode key = KeyCode.Space;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(key))
        {
            audioEffectSO.Play();
        }
    }
}
