using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetive : MonoBehaviour
{
   public bool Complete;
    private void Start()
    {
        
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 4f))
        {
            if (hit.collider.GetComponent<Stone>() != null)
            {
                Complete = true;
            }
            else Complete = false;

        }
        else Complete = false;
    }
}
