using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Player
{
    public Terrain terrain;
    [SerializeField] float RaycastDistance;

    void Start()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4f))
        {
            terrain = hit.collider.GetComponent<Terrain>();
            print(hit.collider.gameObject.name);
        }
    }


    void Update()
    {
        //  ActualPosition();
        Direction();


    }
    void Direction()
    {
        
        bool Forward = Physics.Raycast(transform.position, Vector3.forward, RaycastDistance);
        bool Left = Physics.Raycast(transform.position, Vector3.left, RaycastDistance);
        bool Right = Physics.Raycast(transform.position, Vector3.right, RaycastDistance);
        bool Back = Physics.Raycast(transform.position, Vector3.back, RaycastDistance);
        if (Forward && Back) terrain.occupied = true;
        else if (Right && Left) terrain.occupied = true;
        else terrain.occupied = false;
    }
}
