using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void StartButton()
    {
        // game scene
        SceneManager.LoadScene(1);
    }
    
    public void ReturnToMenuButton()
    {
        // menu scene
        SceneManager.LoadScene(0);
    }
    
    public void QuitButton()
    {
        Application.Quit();
    }
}
