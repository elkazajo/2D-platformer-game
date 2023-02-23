using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int allScenes;
    private int currentScene;
    private int mainMenuScene = 0;

    private void Awake()
    {
        Time.timeScale = 1;
        allScenes = SceneManager.sceneCountInBuildSettings - 1;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(allScenes);
        Debug.Log(currentScene);
    }

    public void OnGameFinish()
    {
        Time.timeScale = 0;        
        
        if(currentScene < allScenes)
        {
            SceneManager.LoadScene(currentScene + 1);
        }  
       else
        {
            SceneManager.LoadScene(mainMenuScene);
        }
    }
}
