using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; } // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform[] target;
        private GameObject[] things;

        [Header("AI Movement")]
        [Tooltip("The Tag of the objects you want to find")]
        public string Find;
        [Tooltip("The Tag im walking to")]
        public int currentWayPoint;
        [Tooltip("How long the Ai waits at each location")]
        public float waitDelay;
        private float curTime;

        [Header("AI Vision")]
        public float fieldOfView = 110f;
        [HideInInspector]
        public GameObject player;
        public bool playerInSight;
        public UnityEvent whenSpotted;
        private CapsuleCollider col;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            col = GetComponent<CapsuleCollider>();
            player = GameObject.FindGameObjectWithTag("Player");

            //find objects with tag and get their transforms 
            for (int i = 0; i < target.Length; i++)
            {
                target[i] = GameObject.FindGameObjectsWithTag(Find)[i].transform;

            }

            agent.updateRotation = false;
            agent.updatePosition = true;
        }

        private void Update()
        {

            for (int i = 0; i < target.Length; i++)
            {
                if (currentWayPoint < target.Length)
                {
                    agent.SetDestination(target[currentWayPoint].position); //set target as the currentwaypoint transform

                    if (agent.remainingDistance > agent.stoppingDistance)
                    {
                        character.Move(agent.desiredVelocity, false, false);   
                    }
                    else
                    {
                        if (curTime == 0)
                            curTime = Time.time; // Pause over the Waypoint
                        if ((Time.time - curTime) >= waitDelay)
                        {
                            currentWayPoint = UnityEngine.Random.Range(0, target.Length); //get the next point at random
                            curTime = 0; //reset timer
                            return;
                        }
                    }
                }
            }
        }

        public void SetTarget(Transform[] target)
        {
            this.target = target;
        }

        void OnTriggerStay(Collider other)
        {
            if (other.gameObject == player)
            {
                playerInSight = false;
                Vector3 direction = other.transform.position - transform.position;
                float angle = Vector3.Angle(direction, transform.forward);

                if (angle < fieldOfView * 0.5f) //if on the side edges of field of view
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius)) //raycast from about center of the body (to avoid floor)
                    {
                        if (hit.collider.gameObject == player)
                        {
                            Debug.Log("spotted");
                            playerInSight = true;
                            whenSpotted.Invoke();
                        }
                    }
                }
            }
        }

    }
}
/*
 * Gets and sets character controller script 
 * Searches for gameobjects with tags equal to find string
 * Gets the transform from each of those
 * Set the character moving towards location 0
 * When it reaches it, if a delay has been set, wait at the waypoint for that period
 * Sets the next location as a random number in the target array
 * Returns values to 0 to loop through
 * 
 * If within trigger
 * Raycast to Check to see if the player in in vision,
 * if they are within range and sight
 * change bool to true and invoke unityevent
 */
