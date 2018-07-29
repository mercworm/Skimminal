using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetNavMeshSurfaces : MonoBehaviour
{

    void Start()
    {
        var surfaces = Object.FindObjectsOfType<NavMeshSurface>();

        if (surfaces != null && surfaces.Length > 0)
            surfaces[surfaces.Length-1].BuildNavMesh();
        
    }
}

