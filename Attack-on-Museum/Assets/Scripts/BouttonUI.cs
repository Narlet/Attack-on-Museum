using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouttonUI : MonoBehaviour
{
    [SerializeField] private string _newGameLevel = "Level1";
    [SerializeField] private GameObject _menuCredits = null;
    [SerializeField] private GameObject _mainMenu = null;
    [SerializeField] private GameObject _menuPause = null;
    [SerializeField] private GameObject _menuGameOver = null;
    [SerializeField] private TextMeshProUGUI _scoreUI = null;

    private void Start()
    {
        TimeManager.Instance.OnGameOver += GameOver;
        TimeManager.Instance.OnPaused += Pause;
    }

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
        if (TimeManager.Instance.Paused)
        {
            _menuPause.SetActive(true);
        }
        else
        {
            _menuPause.SetActive(false);
        }
    }

    public void Resume()
    {
        _menuPause.SetActive(false);
        TimeManager.Instance.Paused = false;
    }

    public void GameOver()
    {
        _menuGameOver.SetActive(true);
    }

    private void Update()
    {
        _scoreUI.text = "Score : " + ScoreManager.Instance.CurrentScore.ToString();
    }
}



