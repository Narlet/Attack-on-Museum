using Engine.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private float _bestScore = 0;
    private float _currentScore = 0;
    private bool[] _keyItems = new bool[4];
    [SerializeField] private GameObject _character = null;
    [SerializeField] private GameObject _currentCharacter = null;
    [SerializeField] private CharacterController _characterController = null;

    public GameObject Character
    {
        get 
        {
            return _character; 
        }

        set
        {
            _character = value;
        }
    }

    public GameObject CurrentCharacter
    {
        get
        {
            return _currentCharacter;
        }

        set
        {
            _currentCharacter = value;
        }
    }
    public CharacterController CharacterController
    {
        get
        {
            return _characterController;
        }

        set
        {
            _characterController = value;
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


}
