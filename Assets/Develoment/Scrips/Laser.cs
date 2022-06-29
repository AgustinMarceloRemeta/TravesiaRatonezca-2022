using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    LineRenderer LaserRenderer;
    [SerializeField] Vector3 direction;
    void Start()
    {
        LaserRenderer= GetComponent<LineRenderer>();
        LaserRenderer.startWidth = 0.2f;
        LaserRenderer.endWidth = 0.2f;
        //LaserRenderer.SetPosition(0, this.transform.position);

    }

    void Update()
    {
        LaserRenderer.SetPosition(0, this.transform.position);
        Ray ray = new Ray(this.transform.position, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            LaserRenderer.SetPosition(1, hit.transform.position);
            if(hit.collider.GetComponent<Player>() != null && hit.collider.GetComponent<Stone>() == null) SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
