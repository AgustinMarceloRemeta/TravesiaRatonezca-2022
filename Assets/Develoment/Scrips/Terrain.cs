using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour
{
    public bool occupied, box;
    public Vector3 position;
    public int Vertical, Horizontal;
    public GameObject Up;
    void Start()
    {
        position = this.transform.position;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4f))
        {
            Up = hit.collider.gameObject;
            if (hit.collider.GetComponent<Player>() != null)
            {
                box = true;
            }
            else if (hit.collider.CompareTag("Obstacle")) 
            {
                occupied = true;
                box = true;           
            }

            else box = false;       
        }
        else
        {
            box = false;
            occupied = false;
        }
    }
}
