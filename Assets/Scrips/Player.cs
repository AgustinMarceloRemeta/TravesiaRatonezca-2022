using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float Velocity;
    [SerializeField] int MaxVertical, MaxHorizontal;
    [SerializeField] Terrain[] Terrains;
     int ActualVertical, ActualHorizontal;
     float NewX, NewZ;
     bool Change;

    void Start()
    {
              
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(NewX,transform.position.y, NewZ),Velocity*Time.deltaTime);
        if (NewX == transform.position.x && NewZ == transform.position.z) Change = true;
        if (Change) Movement();
    }
    void NewPosition(int NewVertical, int NewHorizontal)
    {
        foreach (var item in Terrains)
        {
            if (NewHorizontal == item.Horizontal && NewVertical == item.Vertical)
            {
                if (!item.occupied)
                {
                    NewX = item.position.x;
                    NewZ = item.position.z;
                    ActualHorizontal = NewHorizontal;
                    ActualVertical = NewVertical;
                }
                else print("Objeto ocupado");
            }
        // agregar condiciones y distintas cosas aca
        }
    }
    void Movement()
    {
        int NewVertical= ActualVertical,NewHorizontal = ActualHorizontal;   
        if (Input.GetKeyDown("w"))
        {
            Change = false;
            NewVertical++;
        }
        else if (Input.GetKeyDown("s"))
        {
            Change = false;
                NewVertical--;
        }
        else if (Input.GetKeyDown("d"))
        {
            Change = false;
            NewHorizontal++;
        }  
        else if (Input.GetKeyDown("a"))
        {
            Change = false;
            NewHorizontal--;
        }
        if (ActualHorizontal < -MaxHorizontal) ActualHorizontal = -MaxHorizontal;
        if (ActualHorizontal > MaxHorizontal) ActualHorizontal = MaxHorizontal;
        if (ActualVertical < -MaxVertical) ActualVertical = -MaxVertical;
        if (ActualVertical > MaxVertical) ActualVertical = MaxVertical;
        NewPosition(NewVertical,NewHorizontal);
    }
}
