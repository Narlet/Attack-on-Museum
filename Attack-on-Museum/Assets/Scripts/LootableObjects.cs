using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObjects/LootableObjects", order = 1)]
public class LootableObjects : ScriptableObject
{
    [SerializeField] private float _weight = 0;
    [SerializeField] private float _price = 0;

}
