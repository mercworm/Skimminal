using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetMovement : MonoBehaviour {

    public GameObject playerCharacter;
    public Transform petFollow;
    public float petSpeed;

    private void OnEnable()
    {
        EventManager.StartListening("OnPlayerPetSpotted", FollowPlayer);
    }

    private void Start()
    {
        petFollow = playerCharacter.GetComponentInChildren<Transform>();
    }

    public void FollowPlayer ()
    {
        transform.position = Vector3.MoveTowards(transform.position, petFollow.transform.position, petSpeed);
    }
}
