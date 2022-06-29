using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMenu : MonoBehaviour
{
    [SerializeField] GameObject Levels, Principal, Score, Level1, Level2, Level3, Level4;
    int Level;
    void Start()
    {
        Level = PlayerPrefs.GetInt("Levels", 1);
        if (Level < 4) Level4.SetActive(false);
        if (Level < 3) Level3.SetActive(false);
        if (Level < 2) Level2.SetActive(false);
        OpenPrincipal();
    }

    void Update()
    {
        if (Input.GetKeyDown("r")) Reset();
    }
    public void Play()
    {
        ChangeLevel(Level);
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
    public void OpenLevels()
    {
        Principal.SetActive(false);
        Levels.SetActive(true);
        Score.SetActive(false);
    }
    public void OpenPrincipal()
    {
        Levels.SetActive(false);
        Principal.SetActive(true);
        Score.SetActive(false);
    }  
    public void OpenScore()
    {
        Levels.SetActive(false);
        Principal.SetActive(false);
        Score.SetActive(true);
    }
    public void ChangeLevel(int Level)
    {
        SceneManager.LoadScene(Level);
    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
