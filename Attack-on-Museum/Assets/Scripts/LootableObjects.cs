using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableObjects : MonoBehaviour
{
    [SerializeField] private float _grabRange = 1;
    [SerializeField] private LootableObjectsData _data = null;
    [SerializeField] private KeyItem _key = null;
    [SerializeField] private CircleCollider2D _grabCollider = null;
    [SerializeField] private SpriteRenderer _spriteRender = null;
    [SerializeField] private float _maxTimeBeforeGrab = 2f;
    [SerializeField] private GameObject _floatingText1 = null;
    [SerializeField] private GameObject _floatingText2 = null;
    [SerializeField] private GameObject _floatingText3 = null;
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
        if (other.gameObject == ScoreManager.Instance.CurrentCharacter)
        {
            if(Data.Price > 25)
            {
                if(Data.Price > 100)
                {
                    Instantiate(_floatingText3, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(_floatingText2, transform.position, Quaternion.identity);
                }
            }
            else
            {
                Instantiate(_floatingText1, transform.position, Quaternion.identity);
            }
            ScoreManager.Instance.CharacterController.Grab(this);
            if(_key != null)
            {
                ScoreManager.Instance.KeyItems[_key.KeyItemNumber] = true;
            }
        }
    }
}
