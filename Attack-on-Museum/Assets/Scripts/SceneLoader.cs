using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _sceneName = "SampleScene";
    void Start()
    {
        TimeManager.Instance.GameOver = false;
        TimeManager.Instance.Paused = false;
        SceneManager.LoadScene(_sceneName);
    }

}
