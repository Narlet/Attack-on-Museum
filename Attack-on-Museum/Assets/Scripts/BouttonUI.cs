using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouttonUI : MonoBehaviour
{
    [SerializeField] private string _newGameLevel = "Level1";
    [SerializeField] private GameObject _menuCredits = null;
    [SerializeField] private GameObject _mainMenu = null;
    [SerializeField] private GameObject _menuPause = null;
    private bool _isPaused = false;



    public void NewGameButton()
    {
        SceneManager.LoadScene(_newGameLevel);

    }

    public void BoutonQuit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        _menuCredits.SetActive(true);
        _mainMenu.SetActive(false);
    }

    public void MainMenu()
    {
        _mainMenu.SetActive(true);
    }

    public void Pause()
    {
        _menuPause.SetActive(true);
        Time.timeScale = 0;
        _isPaused = true;
    }

    public void Resume()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (_isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
}



