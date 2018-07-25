using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    public string scoreListFileName;
    public ScoreList scoreList = new ScoreList();
    public int anInt;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Save")]
    public void SaveNow()
    {
        scoreList.Save(System.IO.Path.Combine(Application.persistentDataPath, scoreListFileName));
    }

    [ContextMenu("Load")]
    public void LoadNow()
    {
        scoreList.Load(System.IO.Path.Combine(Application.persistentDataPath, scoreListFileName));
    }
}
