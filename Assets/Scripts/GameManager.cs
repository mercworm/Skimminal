using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager manager;
    public GameObject gameOverPanel;

    private void OnEnable()
    {
        EventManager.StartListening("OnPlayerSpotted", TempGameOver);
    }

    void Awake()
    {
        if (manager == null)
        {
            DontDestroyOnLoad(gameObject);
            manager = this;
        }
        else if (manager != this)
        {
            Destroy(gameObject);
        }

        PlayerPrefs.DeleteAll();
    }

    public void TempGameOver ()
    {
        gameOverPanel.SetActive(true);
        StartCoroutine(TempTwo());
    }

    public IEnumerator TempTwo ()
    {
        yield return new WaitForSeconds(2);
        EventManager.TriggerEvent("OnFreezeMovement");
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("EdwardsRoom");
        StopCoroutine(TempTwo());
    }

}
