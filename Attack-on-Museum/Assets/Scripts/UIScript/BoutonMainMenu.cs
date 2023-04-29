using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
using UnityEngine.Video;

public class BoutonMainMenu : MonoBehaviour
{
    [SerializeField] private string _newGameLevel = "GameLevel";
    [SerializeField] private string _mainMenu = "MainMenu";
    [SerializeField] private GameObject _menuCredits = null;
    [SerializeField] private GameObject _mainMenuUi = null;
    [SerializeField] private GameObject _video = null;
    [SerializeField] private AudioSource _audioClick = null;
    [SerializeField] RawImage _rawImage = null;
    [SerializeField] VideoPlayer _videoPlayer = null;
    [SerializeField] AudioSource _music = null;
   
    private void Start()
    {
        StartCoroutine(PlayVideo());
        Invoke(_mainMenu, 6.0f);
        ScoreManager.Instance.KeyItems = new bool[4];
        ScoreManager.Instance.CurrentScore = 0;
        TimeManager.Instance.Paused = true;
        TimeManager.Instance.CurrentTime = 0;
    }

   IEnumerator PlayVideo()
    {
        _videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!_videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        _rawImage.texture = _videoPlayer.texture;
        _videoPlayer.Play();
      
    }

    public async void WaitPlay(float duration)
    {
        _audioClick.Play();
        await Task.Delay((int)(duration * 1000));
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
        _video.SetActive(false);
        _mainMenuUi.SetActive(true);
        _music.Play();
    }
    
    
  
}


