using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] float Velocity;
    [SerializeField] protected int ActualVertical, ActualHorizontal;
    [SerializeField] float NewX, NewZ;
    [SerializeField] List<Position> ExPositions;
    public bool IsPlayer;
    public static Action  SavePos, AddMovs;
    protected GridManager gridManager;
    bool Change;
    Animator Anim;

    public virtual void Awake()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4f))
        {
            if (hit.collider.GetComponent<Terrain>() != null)
            {
                Terrain t = hit.collider.GetComponent<Terrain>();
                ActualHorizontal = t.Horizontal;
                ActualVertical = t.Vertical;
                NewX = t.transform.position.x;
                NewZ = t.transform.position.z;
            }
        }
    }
    void Start()
    {
        Anim = GetComponent<Animator>();
        gridManager = FindObjectOfType<GridManager>();
        InitList();
    }

    public virtual void InitList()
    {
        var newP = new Position(ActualVertical, ActualHorizontal);
        ExPositions.Add(newP);
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
                    Limits();
                    if (IsPlayer) {
                        SavePos?.Invoke();
                        AddMovs?.Invoke();
                            }
                    NewX = item.position.x;
                    NewZ = item.position.z;
                    ActualHorizontal = NewHorizontal;
                    ActualVertical = NewVertical;

                }
                else print("Objeto ocupado");
            }
        }
    }
    void Movement()
    {
        int NewVertical = ActualVertical, NewHorizontal = ActualHorizontal;

        if (Input.GetKey("w"))
        {
            Change = false;
            NewVertical++;
            transform.rotation = Quaternion.Euler(0, 0, 0);
           // SavePos?.Invoke();
            NewPosition(NewVertical, NewHorizontal);
        }
        else if (Input.GetKey("s"))
        {
            Change = false;
            NewVertical--;
            transform.rotation = Quaternion.Euler(0, 180, 0);
           // SavePos?.Invoke();
            NewPosition(NewVertical, NewHorizontal);
        }
        else if (Input.GetKey("d"))
        {
            Change = false;
            NewHorizontal++;
            transform.rotation = Quaternion.Euler(0, 90, 0);
         //   SavePos?.Invoke();
            NewPosition(NewVertical, NewHorizontal);
        }
        else if (Input.GetKey("a"))
        {
            Change = false;
            NewHorizontal--;
            transform.rotation = Quaternion.Euler(0, 270, 0);
          //  SavePos?.Invoke();
            NewPosition(NewVertical, NewHorizontal);
        }


       
    }

    private void Limits()
    {
        if (ActualHorizontal < -gridManager.MaxHorizontal) ActualHorizontal = -gridManager.MaxHorizontal;
        if (ActualHorizontal > gridManager.MaxHorizontal) ActualHorizontal = gridManager.MaxHorizontal;
        if (ActualVertical < -gridManager.MaxVertical) ActualVertical = -gridManager.MaxVertical;
        if (ActualVertical > gridManager.MaxVertical) ActualVertical = gridManager.MaxVertical;
    }

    public virtual void SavePosition()
    {
        var NewPosition = new Position(ActualVertical, ActualHorizontal);
        ExPositions.Add(NewPosition);
    }
    Position GetPosition()
    {
        for (int i = 0; i < ExPositions.Count; i++)
        {
            if (i == ExPositions.Count - 1)
            {
                var Exposition = ExPositions[i];
                ExPositions.RemoveAt(i);
                return Exposition;
            }
        }
        return new Position(ActualVertical, ActualHorizontal);
    }

   public virtual void ReturnToPastPosition()
    {
        var NewPosition = GetPosition();
        int NewHorizontal = NewPosition.horizontal;
        int NewVertical = NewPosition.vertical;
        foreach (var item in gridManager.terrains)
        {
            if (NewHorizontal == item.Horizontal && NewVertical == item.Vertical)
            {
                print(item.position.x);
                this.transform.position = new Vector3(item.position.x, 0, item.position.z);
                NewX = item.position.x;
                    NewZ = item.position.z;
                    ActualHorizontal = NewHorizontal;
                    ActualVertical = NewVertical;
                    Limits();
                }
            }
       // NewPosition(GetPosition().vertical, GetPosition().horizontal);
        //Llamar desde un evento
    }
    public virtual void OnEnable()
    {
        GameManager.Back += ReturnToPastPosition;
        SavePos += SavePosition;
    }
    public virtual void OnDisable()
    {
        GameManager.Back -= ReturnToPastPosition;
        SavePos -= SavePosition;
    }
}
[System.Serializable]
public class Position
{
     public int vertical, horizontal;
    public Position(int Vertical, int Horizontal)
    {
        vertical = Vertical;
        horizontal = Horizontal;
    }
   
}
