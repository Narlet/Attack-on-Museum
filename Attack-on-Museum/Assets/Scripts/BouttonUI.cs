using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouttonUI : MonoBehaviour
{
    [SerializeField] private string _newGameLevel = "Level1";
    [SerializeField] private GameObject _menuCredits = null;
    [SerializeField] private GameObject _mainMenu = null;
    


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
    }

    public void MainMenu()
    {
        _mainMenu.SetActive(true);
    }
}
