using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Terrain[] terrains;
    public int MaxVertical, MaxHorizontal;

    private void Awake()
    {
        terrains = FindObjectsOfType<Terrain>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
