using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObjects/LootableObjects", order = 1)]
public class LootableObjects : ScriptableObject
{
    [SerializeField] private float _weight = 0;
    [SerializeField] private float _price = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
