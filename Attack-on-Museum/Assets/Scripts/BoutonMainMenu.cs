using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoutonMainMenu : MonoBehaviour
{
    [SerializeField] private string _newGameLevel = "GameLevel";
    [SerializeField] private string _mainMenu = " MainMenu";
    [SerializeField] private GameObject _menuCredits = null;


   


    public void NewGameButton()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void BoutonQuit()
    {
        Application.Quit();
        Debug.Log (" bien joué");
    }

    public void Credits()
    {
        _menuCredits.SetActive(true);

    }

    public void MainMenu()
    {
        _menuCredits.SetActive(false);

    }


}


