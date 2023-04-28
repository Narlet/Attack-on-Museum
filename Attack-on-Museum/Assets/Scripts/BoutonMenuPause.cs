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
    [SerializeField] private TextMeshProUGUI _scoreUI = null;
    [SerializeField] private AudioSource _audioClick = null;



    private void Start()
    {
        TimeManager.Instance.OnGameOver += GameOver;
        TimeManager.Instance.OnPaused += Pause;
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
        SceneManager.LoadScene(_mainMenu);
    }

    public  void Pause()
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
    public async void Resume(float duration )
    {
        _audioClick.Play();
        await Task.Delay((int)(duration * 1000));
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
