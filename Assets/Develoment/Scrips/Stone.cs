using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Player
{
    public Terrain terrain;
    [SerializeField] float RaycastDistance;
    [SerializeField] LayerMask Layer;

    void Start()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4f))
        {
            terrain = hit.collider.GetComponent<Terrain>();
        }
    }


    void Update()
    {
        //  ActualPosition();
        Direction();


    }
    void Direction()
    {
        
        bool Forward = Physics.Raycast(transform.position, Vector3.forward, RaycastDistance, Layer);
        bool Left = Physics.Raycast(transform.position, Vector3.left, RaycastDistance, Layer);
        bool Right = Physics.Raycast(transform.position, Vector3.right, RaycastDistance, Layer);
        bool Back = Physics.Raycast(transform.position, Vector3.back, RaycastDistance,Layer);
        if (Forward && Back) terrain.occupied = true;
        else if (Right && Left) terrain.occupied = true;
        else terrain.occupied = false;
    }
}
