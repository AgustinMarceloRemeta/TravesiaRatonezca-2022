using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
   public List<Objetive> objetives;
    public static Action Back;
    GameObject Win;
    void Start()
    {
        Win = GameObject.FindGameObjectWithTag("NextLevel");
        foreach (var item in FindObjectsOfType<Objetive>())
        {
            objetives.Add(item);
        }
        Win.SetActive(false);
    }

    void Update()
    {
        if (isComplete()) Win.SetActive(true);
        else Win.SetActive(false);
    }
    bool isComplete()
    {
        foreach (var item in objetives)
        {
            if (!item.Complete) return false;
        }
        return true;
    }
    public void BackPosition()
    {
        Back?.Invoke();
    }
    public void NewLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void Exit()
    {
        Application.Quit();
        print("Sali");
    }
}
