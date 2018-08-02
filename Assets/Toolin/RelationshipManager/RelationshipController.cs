using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipController : MonoBehaviour
{
    public RelationshipManager relMan;
	void Start ()
    {
        relMan.Initialise();
        relMan.EnforceStartingState();
	}
}
