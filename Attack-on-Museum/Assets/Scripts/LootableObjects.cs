using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableObjects : MonoBehaviour
{
    [SerializeField] private float _grabRange = 1;
    [SerializeField] private LootableObjectsData _data = null;
    [SerializeField] private CircleCollider2D _grabCollider = null;
    [SerializeField] private SpriteRenderer _spriteRender = null;
    [SerializeField] private float _maxTimeBeforeGrab = 2f;
    private float _currentTimeBeforeGrab = 0f;

    public LootableObjectsData Data
    {
        get
        {
            return _data;
        }

        set
        {
            _data = value;
        }
    }

    // Start is called before the first frame update

    private void Awake()
    {
        _grabCollider.radius = _grabRange;
        _spriteRender.sprite = _data.Sprite;
        _grabCollider.enabled = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_grabCollider.enabled)
        {
            if (_currentTimeBeforeGrab >= _maxTimeBeforeGrab)
            {
                _grabCollider.enabled = true;
            }
            else
            {
                _currentTimeBeforeGrab += Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == ScoreManager.Instance.Character)
        {
            ScoreManager.Instance.CharacterController.Grab(this);
        }
    }
}
