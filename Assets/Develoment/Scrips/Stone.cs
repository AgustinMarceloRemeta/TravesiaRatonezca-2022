using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : Player
{
    public Terrain terrain;
    [SerializeField] float RaycastDistance;
    [SerializeField] LayerMask Layer;

    bool Forward, Left, Right, Back;

    void Start()
    {
        gridManager = FindObjectOfType<GridManager>();
        NewTerrain();
    }

    private void NewTerrain()
    {
        foreach (var item in gridManager.terrains)
        {
            if (ActualHorizontal == item.Horizontal && ActualVertical == item.Vertical)
                terrain = item;
        }
    }

    void Update()
    {
        ActualPosition();
        Direction();

    }
    void Direction()
    {
       
         Forward = Physics.Raycast(transform.position, Vector3.forward, RaycastDistance, Layer);
         Left = Physics.Raycast(transform.position, Vector3.left, RaycastDistance, Layer);
         Right = Physics.Raycast(transform.position, Vector3.right, RaycastDistance, Layer);
         Back = Physics.Raycast(transform.position, Vector3.back, RaycastDistance,Layer);

        if (Forward)
        {
            if (IsOcuped(ActualVertical - 2, ActualHorizontal)) terrain.occupied = true;
            else terrain.occupied = false;
        }
        else if (Back)
        {
            if (IsOcuped(ActualVertical + 1, ActualHorizontal)) terrain.occupied = true;
            else terrain.occupied = false;
        }
        else if (Right)
        {
            if (IsOcuped(ActualVertical, ActualHorizontal - 1)) terrain.occupied = true;
            else terrain.occupied = false;
        }
        else if (Left)
        {
            if (IsOcuped(ActualVertical, ActualHorizontal + 1)) terrain.occupied = true;
            else terrain.occupied = false;
        }
        else terrain.occupied = false;
        
    }

    bool IsOcuped(int NewVertical, int NewHorizontal)
    {
        foreach (var item in gridManager.terrains)
        {
            if (NewHorizontal == item.Horizontal && NewVertical == item.Vertical)
            {
                if (item.box) return true;
   
                else return false;
            }
        }
        return true;
    }
    void Move()
    {
        if (Forward) NewPosition(ActualVertical - 1, ActualHorizontal);
        if (Back) NewPosition(ActualVertical + 1, ActualHorizontal);
        if (Right) NewPosition(ActualVertical , ActualHorizontal - 1);
        if (Left) NewPosition(ActualVertical, ActualHorizontal + 1);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Player>() != null)
        {
            Move();
            NewTerrain();
        }
    }
}
