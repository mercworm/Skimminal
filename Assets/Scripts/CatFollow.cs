using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFollow : MonoBehaviour {

    private GameObject player;

    public Transform target;
    public Vector3 catPosition;
    public float speed;
	public int maxRange;
	bool catFollowNow = false;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if ((Vector3.Distance(transform.position,player.transform.position)<maxRange))
		{
			catFollowNow = true;
		}

		if (catFollowNow == true) {
			catPosition = transform.position;
			target = GameObject.FindWithTag ("Catnip").transform;
			transform.position = Vector3.MoveTowards (catPosition, target.transform.position, speed * Time.deltaTime);

			transform.LookAt (target);
		}
    }
}
