using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu()]
public class AudioEffectSO : ScriptableObject
{
    public AudioClip[] clips;
    [MinMax(0, 1)]
    public Vector2 VolumeRange = new Vector2(1, 1);
    [MinMax(-3, 3)]
    public Vector2 PitchRange = new Vector2(1, 1);


    public void Play(AudioSource source, bool oneShot = true)
    {
        if (source == null || clips == null || clips.Length == 0)
            return; //bail out not possible

        var clip = clips[Random.Range(0, clips.Length)];
        var curVol = Random.Range(VolumeRange.x, VolumeRange.y);
        var curPitch = Random.Range(PitchRange.x, PitchRange.y);

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

    public void Play()
    {
        var s = AudioSourcePool.GetSource();
        Play(s, false);
        AudioSourcePool.ReturnSourceWhenDone(s);
    }
}