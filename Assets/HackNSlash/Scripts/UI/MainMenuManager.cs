using System;
using HackNSlash.Scripts.GameManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gamePlayElements;
    [SerializeField] private GameObject[] mainMenuElements;
    [SerializeField] private GameObject[] pauseMenuElements;
    [SerializeField] private GameObject controlScreen;
    [SerializeField] private GameObject pauseMenu;
    [Header("Main Menu Buttons")]
    [SerializeField] private Button playButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button quitButton;
    
    private void Start()
    {
        Array.ForEach(gamePlayElements, ctx => ctx.SetActive(false));
        Array.ForEach(mainMenuElements, ctx => ctx.SetActive(true));
        Time.timeScale = 0;
        
        SetMainMenuButtons();
    }

    public void StartGameplay()
    {
        Array.ForEach(gamePlayElements, ctx => ctx.SetActive(true));
        Array.ForEach(mainMenuElements, ctx => ctx.SetActive(false));
        Time.timeScale = 1;
    }
    
    public void ShowControls()
    {
        controlScreen.SetActive(true);
        Array.ForEach(mainMenuElements, ctx => ctx.SetActive(false));
    }
    
    public void HideControls()
    {
        controlScreen.SetActive(false);
        Array.ForEach(mainMenuElements, ctx => ctx.SetActive(true));
    }

    private void SetMainMenuButtons()
    {
        playButton.onClick.AddListener(StartGameplay);
        controlsButton.onClick.AddListener(ShowControls);
        quitButton.onClick.AddListener(GameManager.Instance.Quit);
    }
    
    
}
