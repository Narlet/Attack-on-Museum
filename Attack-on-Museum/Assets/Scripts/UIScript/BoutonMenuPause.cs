using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class BoutonMenuPause : MonoBehaviour
{
    [SerializeField] private string _mainMenu = "MainMenu";
    [SerializeField] private GameObject _menuPause = null;
    [SerializeField] private GameObject _menuGameOver = null;
    [SerializeField] private GameObject _victoryUI = null;
    [SerializeField] private GameObject _timerScoreUI = null;
    [SerializeField] private TextMeshProUGUI _scorePause = null;
    [SerializeField] private TextMeshProUGUI _scoreUI = null;
    [SerializeField] private TextMeshProUGUI _victoryScoreUI = null;
    [SerializeField] private AudioSource _audioClick = null;
    [SerializeField] private AudioSource _backgroundMusic = null;
    [SerializeField] private AudioSource _victoryMusic = null;
    [SerializeField] private AudioSource _gameOverMusic = null;

    private void Start()
    {
        TimeManager.Instance.OnGameOver += GameOver;
        TimeManager.Instance.OnPaused += Pause;
        TimeManager.Instance.OnVictory += Victory;
    }
    public async void BoutonQuit(float duration)
    {
        _audioClick.Play();
        await Task.Delay((int)(duration * 1000));
        Application.Quit();
        Debug.Log(" bien joué");
    }

    public async void MainMenu(float duration)
    {
        _audioClick.Play();
        await Task.Delay((int)(duration * 1000));
        TimeManager.Instance.Paused = false;
        TimeManager.Instance.GameOver = false;
        TimeManager.Instance.Victory = false;
        SceneManager.LoadScene(_mainMenu);
    }

    public void Pause()
    { 
        _menuPause.SetActive(TimeManager.Instance.Paused);
        _backgroundMusic.mute = TimeManager.Instance.Paused;
    }
    public async void Resume(float duration )
    {
        _audioClick.Play();
        await Task.Delay((int)(duration * 1000));
        _menuPause.SetActive(false);
        TimeManager.Instance.Paused = false;
    }

    public void GameOver()
    {
        _backgroundMusic.Pause();
        _menuGameOver.SetActive(TimeManager.Instance.GameOver);
        _timerScoreUI.SetActive(false);
    }

    public void Victory()
    {
        if (ScoreManager.Instance.BestScore < ScoreManager.Instance.CurrentScore)
        {
            ScoreManager.Instance.BestScore = ScoreManager.Instance.CurrentScore;
        }
        _backgroundMusic.Pause();
        _victoryMusic.Play();
        _victoryUI.SetActive(TimeManager.Instance.Victory);
    }

    private void Update()
    {
        _scoreUI.text = "Score : " + ScoreManager.Instance.CurrentScore.ToString();
        _scorePause.text = "Score : " + ScoreManager.Instance.CurrentScore.ToString();
        _victoryScoreUI.text = "Score : " + ScoreManager.Instance.CurrentScore.ToString();
    }

    private void OnDestroy()
    {
        TimeManager.Instance.OnGameOver -= GameOver;
        TimeManager.Instance.OnPaused -= Pause;
        TimeManager.Instance.OnVictory -= Victory;
    }















}
