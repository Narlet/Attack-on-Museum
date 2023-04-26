using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private BoxCollider2D _collider = null;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private int _doorNumber = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (ScoreManager.Instance.KeyItems[_doorNumber])
        {
            _collider.isTrigger = true;
            _animator.Play("Open");
        }
    }
}
