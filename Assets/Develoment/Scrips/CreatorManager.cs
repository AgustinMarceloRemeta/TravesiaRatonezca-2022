using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreatorManager : MonoBehaviour
{
    [SerializeField] GameObject TerrainNormal, TerrainWin, Obstacle, Stone, Activate, Desactivate;
    GameObject ObjectActual;
    [SerializeField] Sprite TerrainSp, ObjetiveSp, ObstacleSp, StoneSp, DeleteSp;
    [SerializeField] Image image;
    int number= 0;
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);
        TipeObject();
        ChangerNumber();
        if (number == 0 || number == 1) Action("Replace");
        if (number == 2 || number == 3) Action("Spawn");
        if (number == 4) Action("Delete");
        if (Input.GetKeyDown("p")) PlayLevel();
    }

    private void ChangerNumber()
    {
        if (Input.GetKeyDown("1")) number = 0;
        if (Input.GetKeyDown("2")) number = 1;
        if (Input.GetKeyDown("3")) number = 2;
        if (Input.GetKeyDown("4")) number = 3;
        if (Input.GetKeyDown("5")) number = 4;

    }
    private void TipeObject()
    {
        switch (number)
        {
            case 0:
                ObjectActual = TerrainNormal;
                image.sprite = TerrainSp;
                break;
            case 1:
                ObjectActual = TerrainWin;
                image.sprite = ObjetiveSp;
                break;
            case 2:
                ObjectActual = Obstacle;
                image.sprite = ObstacleSp;
                break;
            case 3:
                ObjectActual = Stone;
                image.sprite = StoneSp;
                break;
            case 4: image.sprite = DeleteSp;
                break;
            default:
                break;
        }
    }

    void Action(string Type)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Terrain terrain = hit.collider.GetComponent<Terrain>();
                if (terrain != null)
                {
                    if (!terrain.box && !terrain.occupied && Type == "Spawn")
                        Instantiate(ObjectActual, hit.transform.position + new Vector3(0, 0.2f, 0), Quaternion.identity);
                    else if(Type == "Replace")
                    {
                        Vector3 position = hit.transform.position;
                        Destroy(hit.collider.gameObject);
                        Instantiate(ObjectActual, position, Quaternion.identity);
                    }
                    else if(Type == "Delete")
                    {
                        Destroy(terrain.Up);
                    }
                }
                if (hit.collider.GetComponent<Stone>() != null && Type == "Delete") Destroy(hit.collider.gameObject);
                if (hit.collider.gameObject.CompareTag("Obstacle") && Type == "Delete") Destroy(hit.collider.gameObject);
            }
        }
    }
    void PlayLevel()
    {
        Activate.SetActive(true);
        Desactivate.SetActive(false);
    }
}
