using System.Collections;
using HackNSlash.Scripts.GameManagement;
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
        //TODO: use scene ref
            SceneManager.LoadScene(1);
    }
    
    public void ReturnToMenuButton()
    {
        if (_canClick)
            // menu scene
            GameManager.Instance.ReloadGame();
    }
    
    public void QuitButton()
    {
        if (_canClick)
            Application.Quit();
    }

    private IEnumerator EnableButtonsDelay()
    {
        //TODO: Delay time should be editable through editor
        yield return new WaitForSeconds(0.5f);
        _canClick = true;
    }
}
