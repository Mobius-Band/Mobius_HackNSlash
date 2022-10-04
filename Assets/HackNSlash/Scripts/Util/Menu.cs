using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private bool _canClick = false;
    
    private void Awake()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Start()
    {
        StartCoroutine(EnableButtonsDelay());
    }

    public void StartButton()
    {
        if (_canClick)
            // game scene
            SceneManager.LoadScene(1);
    }
    
    public void ReturnToMenuButton()
    {
        if (_canClick)
            // menu scene
            SceneManager.LoadScene(0);
    }
    
    public void QuitButton()
    {
        if (_canClick)
            Application.Quit();
    }

    private IEnumerator EnableButtonsDelay()
    {
        yield return new WaitForSeconds(0.5f);
        _canClick = true;
    }
}
