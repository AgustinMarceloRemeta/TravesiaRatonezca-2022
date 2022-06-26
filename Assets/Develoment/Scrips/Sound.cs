using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    private Sound intance;
    
    public Sound Intance
    {
        get
        {
            return intance;
        }
    }
    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else if (intance != null && intance != this)
        {
            Destroy(gameObject);
            return;
        }
        else intance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 4) Destroy(this.gameObject);  
    }
}
