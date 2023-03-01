using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object", menuName = "ScriptableObjects/KeyItem", order = 1)]
public class KeyItem : LootableObjects
{
    [SerializeField] private int _keyItemNumber = 0;
}
