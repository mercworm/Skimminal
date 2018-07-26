using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu()]
public class ScriptableItemCollection : ScriptableObject
{
    public ScriptableItem[] sI;
#if UNITY_EDITOR
    
    [ContextMenu("Gather")]
    public void GatherItems()
    {
        sI = GetAllInstances<ScriptableItem>();
        EditorUtility.SetDirty(this);
    }

    public static T[] GetAllInstances<T>() where T : ScriptableObject
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name, new[] { "Assets/Data" });  //FindAssets uses tags check and find in file location
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a;

    }
#endif
}
