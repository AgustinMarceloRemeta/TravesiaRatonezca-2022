using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public List<Objetive> objetives;
    void Start()
    {
        foreach (var item in FindObjectsOfType<Objetive>())
        {
            objetives.Add(item);
        }
    }

    void Update()
    {
        if (isComplete()) print("A");
    }
    bool isComplete()
    {
        foreach (var item in objetives)
        {
            if (!item.Complete) return false;
        }
        return true;
    }
}
