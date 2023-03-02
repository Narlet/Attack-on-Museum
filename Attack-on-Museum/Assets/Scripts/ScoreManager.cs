using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private float _bestScore = 0;
    private float _currentScore = 0;
    private bool[] _keyItems = new bool[4];

    public float BestScore
    {
        get
        {
            return _bestScore;
        }
        set
        {
            _bestScore = Mathf.Clamp(value, 0, float.MaxValue);
        }
    }

    public float CurrentScore
    {
        get
        {
            return _currentScore;
        }
        set
        {
            _currentScore = Mathf.Clamp(value, 0, float.MaxValue);
        }
    }

    public bool[] KeyItems
    {
        get
        {
            return _keyItems;
        }
        set
        {
            _keyItems = value;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
