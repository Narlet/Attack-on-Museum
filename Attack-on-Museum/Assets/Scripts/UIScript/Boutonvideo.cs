using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Video;

public class Boutonvideo : MonoBehaviour
{
    [SerializeField] private string _newGameLevel = "GameLevel";
    [SerializeField] private string _mainMenu = "MainMenu";
    [SerializeField] private GameObject _menuCredits = null;
    [SerializeField] private GameObject _mainMenuUi = null;
    [SerializeField] private GameObject _tutorialUi = null;
    [SerializeField] private TextMeshProUGUI _tutorialText = null;
    [SerializeField] private AudioSource _audioClick = null;
    [SerializeField] AudioSource _music = null;
    [SerializeField] private Button _playButton = null;
    [SerializeField] private Button _creditButton = null;
    [SerializeField] private Button _exitButton = null;

    private void Start()
    {
         
        Invoke(_mainMenu, 6.0f);
        Invoke("Music", 0f);
    }

  

    public async void WaitPlay(float duration)
    {
        _audioClick.Play();
        _tutorialUi.SetActive(true);
        _playButton.interactable = false;
        _creditButton.interactable = false;
        _exitButton.interactable = false;
        await Task.Delay((int)(duration * 4000));
        _tutorialText.text = "Pick objects and get keys to open new rooms, but beware...";
        await Task.Delay((int)(duration * 4000));
        _tutorialText.text = "Things can be heavier than you thought...";
        await Task.Delay((int)(duration * 4000));
        SceneManager.LoadScene(_newGameLevel);
    }


    public async void WaitQuit(float duration)
    {
        _audioClick.Play();
        await Task.Delay((int)(duration * 1000));
        Application.Quit();
        Debug.Log(" bien joué");
    }

    public async void WaitCredits(float duration)
    {
        _audioClick.Play();
        await Task.Delay((int)(duration * 1000));
        _menuCredits.SetActive(true);
    }



    public async void WaitMainMenu(float duration)
    {
        _audioClick.Play();
        await Task.Delay((int)(duration * 1000));
        _menuCredits.SetActive(false);
    }

    public void MainMenu()
    {
       
        _mainMenuUi.SetActive(true);
       
    }
    public void Music()
    {
        _music.Play();
    }
    
    
  
}


