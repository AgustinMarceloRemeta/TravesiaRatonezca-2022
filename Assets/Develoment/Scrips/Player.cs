using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float Velocity;
    [SerializeField] protected int  ActualVertical, ActualHorizontal;
    [SerializeField] float NewX, NewZ;
    protected GridManager gridManager;
     bool Change;
    Animator Anim;

    void Start()
    {
        Anim = GetComponent<Animator>();
        gridManager = FindObjectOfType<GridManager>();
    }


    void Update()
    {
        ActualPosition();
        Animation();
        if (Change) Movement();
    }

    private void Animation()
    {
        if (NewX == transform.position.x && NewZ == transform.position.z)
        {
            Change = true;
            Anim.SetBool("Walk", false);
        }
        else Anim.SetBool("Walk", true);
    }

    public virtual void ActualPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(NewX, transform.position.y, NewZ), Velocity * Time.deltaTime);
    }

    public virtual void NewPosition( int NewVertical, int NewHorizontal)
    {
        foreach (var item in gridManager.terrains)
        {
            if (NewHorizontal == item.Horizontal && NewVertical == item.Vertical)
            {
                if (!item.occupied)
                {
                    NewX = item.position.x;
                    NewZ = item.position.z;
                    ActualHorizontal = NewHorizontal;
                    ActualVertical = NewVertical;
                    Limits();
                }
                else print("Objeto ocupado");
            }
        }
    }
    void Movement()
    {
        int NewVertical = ActualVertical, NewHorizontal = ActualHorizontal;

        if (Input.GetKeyDown("w"))
        {
            Change = false;
            NewVertical++;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown("s"))
        {
            Change = false;
            NewVertical--;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKeyDown("d"))
        {
            Change = false;
            NewHorizontal++;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Input.GetKeyDown("a"))
        {
            Change = false;
            NewHorizontal--;
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }


        NewPosition(NewVertical, NewHorizontal);
    }

    private void Limits()
    {
        if (ActualHorizontal < -gridManager.MaxHorizontal) ActualHorizontal = -gridManager.MaxHorizontal;
        if (ActualHorizontal > gridManager.MaxHorizontal) ActualHorizontal = gridManager.MaxHorizontal;
        if (ActualVertical < -gridManager.MaxVertical) ActualVertical = -gridManager.MaxVertical;
        if (ActualVertical > gridManager.MaxVertical) ActualVertical = gridManager.MaxVertical;
    }
}
