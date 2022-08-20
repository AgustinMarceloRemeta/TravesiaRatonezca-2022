using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public List<Objetive> objetives;
    public static Action Back;
    float CantMovs, time;
    [SerializeField] Text textContMov, textTime;
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
        if(!isComplete())time += Time.deltaTime;
        textContMov.text ="Movimientos: " +CantMovs.ToString();
        textTime.text ="Tiempo: " + time.ToString("00");
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
        if(CantMovs>0)RestMov();
        Back?.Invoke();
    }
    public void NewLevel()
    {
        int ActiveScene = SceneManager.GetActiveScene().buildIndex;
        if (ActiveScene+1 > PlayerPrefs.GetInt("Levels", 0)) 
        PlayerPrefs.SetInt("Levels", ActiveScene+1);

        int GetMov = PlayerPrefs.GetInt("Level" + ActiveScene.ToString() + "Mov", 0);
        if (GetMov> CantMovs || GetMov==0)
        PlayerPrefs.SetInt("Level" + ActiveScene.ToString() + "Mov", (int)CantMovs );

        int GetTime = PlayerPrefs.GetInt("Level" + ActiveScene.ToString() + "Time", 0) ;
        if (GetTime > time || GetTime == 0)
            PlayerPrefs.SetInt("Level" + ActiveScene.ToString() + "Time", (int)time );
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Reset()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
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
    void AddMov() => CantMovs++;

    void RestMov() => CantMovs--;

    private void OnEnable()
    {
        Player.AddMovs += AddMov;
 
    }
    private void OnDisable()
    {
        Player.AddMovs -= AddMov;
    }
}
