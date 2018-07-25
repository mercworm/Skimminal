using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Controlling Level Select Menu.
 * Holds all of the different scenes in the game.
 * Enables and disables level select.
*/
public class LevelSelect : MonoBehaviour {

    bool menuActive = false;
    public GameObject levelSelectMenu;
    public GameObject exitMenu;

    void OnEnable ()
    {
        EventManager.StartListening("OnLevelSelectMenu", MenuActive);
        EventManager.StartListening("OnExitLevelMenu", ExitMenuActive);
    }

    //Activates the panel that holds the level select menu.
    //Freezes the player's movement.
    void MenuActive ()
    {
        menuActive = true;
        levelSelectMenu.SetActive (true);
        EventManager.TriggerEvent("OnFreezeMovement");
    }

    public void ExitMenuActive ()
    {
        exitMenu.SetActive(true);
        EventManager.TriggerEvent("OnFreezeMovement");
    }


    //Checks if the menu is active.
    //Checks if the player tries to close it.
    //Unfreezes the player's movement when the menu closes.
    void Update ()
    {
        if (menuActive == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                levelSelectMenu.SetActive (false);
                menuActive = false;
                EventManager.TriggerEvent("OnFreezeMovement");
            }
        }
    }

    public void SceneNellie ()
    {
        SceneManager.LoadScene("Nellie");
        EventManager.TriggerEvent("OnNewLevel");
    }

    public void SceneAlcimus()
    {
        SceneManager.LoadScene("Alcimus");
        EventManager.TriggerEvent("OnNewLevel");
    }

    public void ScenePhilip()
    {
        SceneManager.LoadScene("Philip");
        EventManager.TriggerEvent("OnNewLevel");
    }

    public void SceneJenny()
    {
        SceneManager.LoadScene("Jenny");
        EventManager.TriggerEvent("OnNewLevel");
    }

    public void SceneFlorence()
    {
        SceneManager.LoadScene("Florence");
        EventManager.TriggerEvent("OnNewLevel");
    }

    public void SceneWesley()
    {
        SceneManager.LoadScene("Wesley");
        EventManager.TriggerEvent("OnNewLevel");
    }

    public void SceneRyann()
    {
        SceneManager.LoadScene("Ryann");
        EventManager.TriggerEvent("OnNewLevel");
    }

    public void SceneBingk()
    {
        SceneManager.LoadScene("Bingk");
        EventManager.TriggerEvent("OnNewLevel");
    }

    public void SceneElliott()
    {
        SceneManager.LoadScene("Elliott");
        EventManager.TriggerEvent("OnNewLevel");
    }

    public void SceneEdward ()
    {
        SceneManager.LoadScene("EdwardsRoom");
    }
}
