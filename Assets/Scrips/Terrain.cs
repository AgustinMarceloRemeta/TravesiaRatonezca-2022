using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public bool occupied;
    public Vector3 position;
    public int Vertical, Horizontal;
    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        
    }
}
