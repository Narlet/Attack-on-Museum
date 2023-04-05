using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuBoutton : MonoBehaviour
    
{
    [SerializeField] private string _mainMenu = "MainMenu";
    public void MainMenu()
    {
        SceneManager.LoadScene(_mainMenu);
    }
}
