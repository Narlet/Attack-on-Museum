using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint = null;
    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.Character = Instantiate(ScoreManager.Instance.Character, _spawnPoint);
    }

}
