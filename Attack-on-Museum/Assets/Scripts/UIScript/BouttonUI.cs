using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouttonUI : MonoBehaviour
{
    [SerializeField] private string _newGameLevel = "GameLevel";
    [SerializeField] private string _mainMenu = " MainMenu";
    [SerializeField] private GameObject _menuCredits = null;
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
        TimeManager.Instance.CurrentTime = 0;
        _menuGameOver.SetActive(false);
        TimeManager.Instance.GameOver = false;
        TimeManager.Instance.Paused = false;
        
    }

    public void BoutonQuit()
    {
        Application.Quit();
        Debug.Log(" bien joué");
    }

    public void Credits()
    {
        _menuCredits.SetActive(true);
       
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(_mainMenu);
       /* TimeManager.Instance.CurrentTime = 0;
        TimeManager.Instance.GameOver = false;
        _menuGameOver.SetActive(false);*/
        
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

    private void OnDestroy()
    {
        TimeManager.Instance.OnGameOver -= GameOver;
        TimeManager.Instance.OnPaused -= Pause;
    }
}



