using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchableObjectParticles : MonoBehaviour {

    public ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ps.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ps.Stop();
        }
    }
}
