using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ScoreList
{
    [System.Serializable]
    public struct ScoreEntry
    {
        public string name;
        public int score;
    }

    public List<ScoreEntry> entries = new List<ScoreEntry>();

    public void Save(string filePath)
    {
        var jsonified = JsonUtility.ToJson(this);
        System.IO.File.WriteAllText(filePath, jsonified);
    }

    public void Load(string filePath)
    {
        var fileContents = System.IO.File.ReadAllText(filePath);
        JsonUtility.FromJsonOverwrite(fileContents, this);
    }
}
