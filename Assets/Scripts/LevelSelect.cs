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

    void OnEnable ()
    {
        EventManager.StartListening("OnLevelSelectMenu", MenuActive);
    }

    void MenuActive ()
    {
        menuActive = true;
        levelSelectMenu.SetActive (true);
    }

    void Update ()
    {
        if (menuActive == true)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                levelSelectMenu.SetActive (false);
                menuActive = false;
            }
        }
    }

    public void SceneNellie ()
    {
        SceneManager.LoadScene("Nellie");
    }

    public void SceneAlcimus()
    {
        SceneManager.LoadScene("Alcimus");
    }

    public void ScenePhilip()
    {
        SceneManager.LoadScene("Philip");
    }

    public void SceneJenny()
    {
        SceneManager.LoadScene("Jenny");
    }

    public void SceneFlorence()
    {
        SceneManager.LoadScene("Florence");
    }

    public void SceneWesley()
    {
        SceneManager.LoadScene("Wesley");
    }

    public void SceneRyann()
    {
        SceneManager.LoadScene("Ryann");
    }

    public void SceneBingk()
    {
        SceneManager.LoadScene("Bingk");
    }

    public void SceneElliott()
    {
        SceneManager.LoadScene("Elliott");
    }
}
