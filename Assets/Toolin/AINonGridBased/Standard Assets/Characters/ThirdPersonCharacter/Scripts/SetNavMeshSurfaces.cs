using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetNavMeshSurfaces : MonoBehaviour
{
    public NavMeshSurface[] surfaces;

    void Start()
    {
        surfaces = Object.FindObjectsOfType<NavMeshSurface>();
        for (int i = 0; i < surfaces.Length; i++)
        {
            surfaces[i].BuildNavMesh();
        }
    }
}

