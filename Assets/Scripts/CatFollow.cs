using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollow : MonoBehaviour {

    public Transform target; 
    public Vector3 catPosition;
    public float speed;
	public int maxRange;
	bool catFollowNow = false;

	// Use this for initialization
	void Start () {
        //CatFollowing();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if ((Vector3.Distance(transform.position,target.position)<maxRange))
		{
			catFollowNow = true;
		}

		if (catFollowNow == true) {
			catPosition = transform.position;
			target = GameObject.FindWithTag ("Catnip").transform;
			transform.position = Vector3.MoveTowards (catPosition, target.transform.position, speed);

			transform.LookAt (target);
		}
    }
}
