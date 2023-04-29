using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugSceneLoader : MonoBehaviour
{
    void Awake()
    {
        TimeManager.Instance.GameOver = false;
        TimeManager.Instance.Paused = false;
    }
}
