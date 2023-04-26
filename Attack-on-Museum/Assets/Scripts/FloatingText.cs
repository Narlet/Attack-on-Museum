using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text = null;
    [SerializeField] private float _lifeTime = 1;
    [SerializeField] private float _speed = 1;
    private float _currentLifeTime = 0;

    public TextMeshProUGUI Text
    {
        get
        {
            return _text;
        }
        set
        {
            _text = value;
        }
    }



    private void Start()
    {
        Debug.Log(transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        if(_currentLifeTime < _lifeTime)
        {
            _currentLifeTime += Time.deltaTime;
            _text.transform.Translate(Vector2.up * _speed * Time.deltaTime);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
