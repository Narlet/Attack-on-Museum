using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] private float _maxTime = 300;
    private float _currentTime = 0;
    private bool _gameOver = false;
    private bool _paused = false;

    public float MaxTime => _maxTime;
    public float CurrentTime
    {
        get
        {
            return _currentTime;
        }

        set
        {
            _currentTime = Mathf.Clamp(value, 0, float.MaxValue);
        }
    }

    public bool GameOver
    {
        get
        {
            return _gameOver;
        }
        set
        {
            _gameOver = value;
        }
    }

    public bool Paused
    {
        get
        {
            return _paused;
        }
        set
        {
            _paused = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime >= MaxTime)
        {
            _gameOver = true;
        }
        else
        {
            if(!_paused)
            _currentTime += Time.deltaTime;
        }
    }
}
