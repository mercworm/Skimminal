using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RelationShipEntry
{
    public string Person1;
    public string Person2;
    public int Status;
}

[CreateAssetMenu]
public class RelationshipManager: ScriptableObject
{
    [Tooltip("List all characters name in game")]
    public string[] characterNames;

    private void Start()
    {
        Initialise();
    }

    public void Initialise()
    {
        for (int i = 0; i < characterNames.Length; i++)
        {
            for (int j = i+1; j < characterNames.Length; j++)
            {
                Relationships.Add(new RelationShipEntry() { Person1 = characterNames[i], Person2 = characterNames[j], Status = 0 });
            }
        }

        EnforceStartingState();
    }

    [Tooltip("If you want people to start with a different relationships status than default(0)")]
    public RelationShipEntry[] startingRelationShipState;

    //init with default relationships
    public void EnforceStartingState()
    {
        foreach (var item in startingRelationShipState)
        {
            UpdateRelationship(item.Person1, item.Person2, item.Status);
        }
    }


    private List<RelationShipEntry> Relationships = new List<RelationShipEntry>();

    public void UpdateRelationship(string person1, string person2, int Status)
    {
        for (int i = 0; i < Relationships.Count; i++)
        {
            if (Relationships[i].Person1.Contains(person1) && Relationships[i].Person2.Contains(person2) || Relationships[i].Person1.Contains(person2) && Relationships[i].Person2.Contains(person1))
            {
                Relationships[i].Status += Status;
            }
        }
        Debug.Log(person1 + person2 + Status);
    }

    public int CurrentRelationshipStatus(string person1, string person2)
    {
        for (int i = 0; i < Relationships.Count; i++)
        {
            if (Relationships[i].Person1.Contains(person1) && Relationships[i].Person2.Contains(person2) || Relationships[i].Person1.Contains(person2) && Relationships[i].Person2.Contains(person1))
            {
                return Relationships[i].Status;
            }
        }
        return 0;
    }

}
