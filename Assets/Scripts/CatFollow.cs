using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollow : MonoBehaviour {

    public Transform target; 
    public Vector3 catPosition;
    public float speed;

	// Use this for initialization
	void Start () {
        //CatFollowing();
	}
	
	// Update is called once per frame
	void Update ()
    {
        catPosition = transform.position;
        target = GameObject.FindWithTag("Catnip").transform;
        transform.position = Vector3.MoveTowards(catPosition, target.transform.position, speed);
    }

    public void CatFollowing ()
    {
       
    }
}
