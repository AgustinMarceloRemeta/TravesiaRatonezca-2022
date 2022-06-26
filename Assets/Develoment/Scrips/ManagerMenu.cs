using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMenu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
    }
    public void Play()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void Exit()
    {
        Application.Quit();
        print("Sali");
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
