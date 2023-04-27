using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingLootableObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    [SerializeField] private float _shrinkSpeed = 0.05f;
    [SerializeField] private float _spinSpeed = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _spriteRenderer.transform.localScale -= new Vector3(_shrinkSpeed, _shrinkSpeed, _shrinkSpeed);
        _spriteRenderer.transform.Rotate(Vector3.forward * _spinSpeed);
    }
}
