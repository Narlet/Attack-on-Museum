using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObjects/LootableObjects", order = 1)]
public class LootableObjectsData : ScriptableObject
{
    [SerializeField] private float _weight = 0;
    [SerializeField] private float _price = 0;
    [SerializeField] private Sprite _sprite = null;

    public float Weight => _weight;
    public float Price => _price;
    public Sprite Sprite => _sprite;
}
