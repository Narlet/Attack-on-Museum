using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableObjects : MonoBehaviour
{
    [SerializeField] private float _grabRange = 1;
    [SerializeField] private LootableObjectsData _data = null;
    [SerializeField] private KeyItem _key = null;
    [SerializeField] private CircleCollider2D _grabCollider = null;
    [SerializeField] private SpriteRenderer _spriteRenderer = null;
    [SerializeField] private float _maxTimeBeforeGrab = 2f;
    [SerializeField] private GameObject _floatingText1 = null;
    [SerializeField] private GameObject _floatingText2 = null;
    [SerializeField] private GameObject _floatingText3 = null;
    [SerializeField] private GameObject _floatingText4 = null;
    [SerializeField] private float _shrinkSpeed = 0.001f;
    [SerializeField] private float _spinSpeed = 1f;
    private bool _animDestroy = false;
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
        _spriteRenderer.sprite = _data.Sprite;
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

        if(_animDestroy)
        {
            _spriteRenderer.transform.localScale -= new Vector3(_shrinkSpeed, _shrinkSpeed, _shrinkSpeed);
            _spriteRenderer.transform.Rotate(Vector3.forward * _spinSpeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == ScoreManager.Instance.CurrentCharacter)
        {
            if (Data.Weight + ScoreManager.Instance.CharacterController.CurrentWeight <= ScoreManager.Instance.CharacterController.MaxWeight - 5)
            {
                if (Data.Price > 25)
                {
                    if (Data.Price > 100)
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
                _animDestroy = true;
                ScoreManager.Instance.CharacterController.Grab(this);
                if (_key != null)
                {
                    ScoreManager.Instance.KeyItems[_key.KeyItemNumber] = true;
                }
            }
            else
            {
                Instantiate(_floatingText4, transform.position, Quaternion.identity);
            }
        }
    }
}
