using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for 1 type of audio effect, to be used by other monobeh
/// </summary>
public class SimpleAudioEffect : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource source;
    [Range(0.0f,1.0f)]
    public float minVol = 1, maxVol = 1;
    [Range(-3.0f, 3.0f)]
    public float minPitch = 1, maxPitch = 1;

    public void Play(bool oneShot = true)
    {
        if (source == null || clips == null || clips.Length == 0)
            return; //bail out not possible

        var clip = clips[Random.Range(0, clips.Length)];
        var curVol = Random.Range(minVol, maxVol);
        var curPitch = Random.Range(minPitch, maxPitch);

        if (oneShot)
        {
            source.PlayOneShot(clip);
        }
        else
        {
            source.clip = clip;
            source.pitch = curPitch;
            source.volume = curVol;
            source.Play();
        }
    }
}
