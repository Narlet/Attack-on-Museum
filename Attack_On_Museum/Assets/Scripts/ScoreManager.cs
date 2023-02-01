using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    #region Attributes

    [SerializeField] private float _currentScore = 0;
    [SerializeField] private float _bestScore = 0;

    #endregion Attributes

    #region Properties
    public float CurrentScore
    {
        get
        {
            return _currentScore;
        }

        set
        {
            _currentScore = Mathf.Clamp(value, 0, float.PositiveInfinity);
        }
    }

    public float BestScore
    {
        get
        {
            return _bestScore;
        }

        set
        {
            _bestScore = Mathf.Clamp(value, 0, float.PositiveInfinity);
        }
    }
    #endregion Properties
}
