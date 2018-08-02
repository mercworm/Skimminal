using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipManager: MonoBehaviour
{
    public SORelationships[] Relationship;

    public void UpdateRelationship(string person1, string person2, int Status)
    {
        for (int i = 0; i < Relationship.Length; i++)
        {
            if (Relationship[i].Person1.Contains(person1) && Relationship[i].Person2.Contains(person2) || Relationship[i].Person1.Contains(person2) && Relationship[i].Person2.Contains(person1))
            {
                Relationship[i].Status += Status;
            }
        }
        Debug.Log(person1 + person2 + Status);
    }

    public int CurrentRelationshipStatus(string person1, string person2)
    {
        for (int i = 0; i < Relationship.Length; i++)
        {
            if (Relationship[i].Person1.Contains(person1) && Relationship[i].Person2.Contains(person2) || Relationship[i].Person1.Contains(person2) && Relationship[i].Person2.Contains(person1))
            {
                return Relationship[i].Status;
            }
        }
        return 0;
    }

}
