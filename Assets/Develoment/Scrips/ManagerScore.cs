using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerScore : MonoBehaviour
{
    [SerializeField] Text Level1, Level2, Level3, Level4;
    void Start()
    {
        if (PlayerPrefs.GetInt("Level1Mov", 0) > 0)
          Level1.text = "Tiempo: " + PlayerPrefs.GetInt("Level1Time", 0).ToString()+ " segundos" + "\n" + "Movimientos: " + PlayerPrefs.GetInt("Level1Mov", 0) ;
        else
        Level1.text = "No Jugado";

        if (PlayerPrefs.GetInt("Level2Mov", 0) > 0)
          Level2.text = "Tiempo: " + PlayerPrefs.GetInt("Level2Time", 0).ToString() + " segundos" + "\n" + "Movimientos: " + PlayerPrefs.GetInt("Level2Mov", 0) ;
        else
        Level2.text = "No Jugado";   

        if (PlayerPrefs.GetInt("Level3Mov", 0) > 0)
          Level3.text = "Tiempo: " + PlayerPrefs.GetInt("Level3Time", 0).ToString() + " segundos" + "\n" + "Movimientos: " + PlayerPrefs.GetInt("Level3Mov", 0) ;
        else
        Level3.text = "No Jugado"; 
        
        if (PlayerPrefs.GetInt("Level4Mov", 0) > 0)
          Level4.text = "Tiempo: " + PlayerPrefs.GetInt("Level4Time", 0).ToString() + " segundos" + "\n" + "Movimientos: " + PlayerPrefs.GetInt("Level4Mov", 0) ;
        else
        Level4.text = "No Jugado";
    }


    void Update()
    {
        
    }
}
