using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadPlay() 
    {
        SceneManager.LoadScene(1);
        Debug.LogWarning("Play");
    }
    public void loadMenu()
    {
        SceneManager.LoadScene(0);
        Debug.LogWarning("menu");
    }
    public void loadNextScene() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
    public void OnApplicationQuit()
    {
        Debug.LogWarning("Quit");
        Application.Quit();
    }

}
