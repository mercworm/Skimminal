﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLevelCompleteHandler : MonoBehaviour {

    private Button thisButton;

    private void OnEnable()
    {
        thisButton = GetComponent<Button>();
        if (PlayerPrefs.GetInt(thisButton.name, 0)== 1)
        {
            thisButton.interactable = false;
        }
    }
}
