using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObjects/KeyItem", order = 1)]
public class KeyItem : ScriptableObject
{
    [SerializeField] private int _keyItemNumber = 0;

    public int KeyItemNumber => _keyItemNumber;
}
