using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezePlayerMovement : MonoBehaviour {

    UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter thirdPerson;

    private void OnEnable()
    {
        EventManager.StartListening("OnFreezeMovement", MovementControl);
        thirdPerson = GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>();
    }

    private void OnDisable()
    {
        EventManager.StopListening("OnFreezeMovement", MovementControl);
    }

    public void MovementControl ()
    {
        if (thirdPerson.enabled)
            thirdPerson.enabled = false;
        else
            thirdPerson.enabled = true;
    }
}
