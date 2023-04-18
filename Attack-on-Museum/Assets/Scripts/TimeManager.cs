using Engine.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : Singleton<TimeManager>
{
    [SerializeField] private float _maxTime = 120;
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
            if(_onGameOver != null)
            {
                if (GameOver)
                {
                    _onGameOver();
                }
            }
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
            if (_onPaused != null)
            {
                _onPaused();
            }
        }
    }


    #region Events
    private event Action _onGameOver = null;
    public event Action OnGameOver
    {
        add
        {
            _onGameOver -= value;
            _onGameOver += value;
        }
        remove
        {
            _onGameOver -= value;
        }
    }
    private event Action _onPaused = null;
    public event Action OnPaused
    {
        add
        {
            _onPaused -= value;
            _onPaused += value;
        }
        remove
        {
            _onPaused -= value;
        }
    }
    #endregion Events

    // Update is called once per frame
    new void Update()
    {
        if (CurrentTime >= MaxTime)
        {
            ScoreManager.Instance.CurrentScore = 0;
            GameOver = true;
        }
        else
        {
            if(!Paused | !GameOver)
            CurrentTime += Time.deltaTime;
        }
    }
}
