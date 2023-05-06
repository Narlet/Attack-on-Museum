using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5;
    [SerializeField] private float _maxWeight = 100;
    [SerializeField] private float _currentWeight = 0;
    [SerializeField] private List<LootableObjectsData> _objectsLooted = null;
    [SerializeField] private bool _oldLady = false;
    [SerializeField] private GameObject _lootablePrefab = null;
    [SerializeField] private Rigidbody2D _rb = null;
    [SerializeField] private Animator _animator = null;
    [SerializeField] private AudioSource _audioMovement = null;
    [SerializeField] private AudioSource _audioGrab = null;
    
    public float MaxWeight => _maxWeight;
    public float MaxSpeed => _maxSpeed;
    public float CurrentWeight
    {
        get
        {
            return _currentWeight;
        }
        set
        {
            _currentWeight = Mathf.Clamp(value, 0, _maxWeight-5);
        }
    }

    public bool OldLady
    {
        get
        {
            return _oldLady;
        }
        set
        {
            _oldLady = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.Instance.CharacterController = this;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Pause();
        if (!TimeManager.Instance.Paused && !TimeManager.Instance.GameOver && !TimeManager.Instance.Victory)
        {
            /*PlusWeight();
            MinusWeight();*/
            Drop();
        }
    }

/*    private void MoveUp()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position = transform.position + (Vector3.up) * MaxSpeed * (1 - (CurrentWeight / MaxWeight)) * Time.deltaTime;
        }
    }

    private void MoveDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (Vector3.down) * MaxSpeed * (1 - (CurrentWeight / MaxWeight)) * Time.deltaTime;
        }
    }

    private void MoveRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right) * MaxSpeed * (1 - (CurrentWeight / MaxWeight)) * Time.deltaTime;
        }
    }

    private void MoveLeft()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = transform.position + (Vector3.left) * MaxSpeed * (1 - (CurrentWeight / MaxWeight)) * Time.deltaTime;
        }
    }
*/
    private void Move()
    {
        //For the character movement
        Vector2 direction = Vector2.zero;
        if (!TimeManager.Instance.Paused && !TimeManager.Instance.GameOver && !TimeManager.Instance.Victory)
        {
            if (Input.GetKey(KeyCode.W))
            {
                direction.y = 1;
            }
            if (Input.GetKey(KeyCode.A))
            {
                direction.x = -1;
            }
            if (Input.GetKey(KeyCode.S))
            {
                direction.y = -1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                direction.x = 1;
            }
        }
        _rb.velocity = direction * MaxSpeed * (1 - (CurrentWeight / MaxWeight));

        //For the character animation
        if(direction.x != 0 || direction.y != 0)
        {
            _audioMovement.volume = 0.5f;
            _audioMovement.pitch = 2 * (1 - (CurrentWeight / MaxWeight));
            _animator.speed = 2 * (1 - (CurrentWeight / MaxWeight));
            string animation = "Front";
            if(direction.x > 0)
            {
                animation = "Right";
            }
            if(direction.x < 0)
            {
                animation = "Left";
            }
            if(direction.y > 0)
            {
                animation = "Back";
            }
            if(direction.y < 0)
            {
                animation = "Front";
            }
            _animator.Play(animation);
        }
        else
        {
            _animator.speed = 0;
            _audioMovement.volume = 0;
        }
    }
    /*
    private void PlusWeight()
    {
        //Debug for adding weight
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            CurrentWeight += 10;
        }
    }

    private void MinusWeight()
    {
        //Debug for losing weight
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            CurrentWeight -= 10;
        }
    }
    */
    public void Grab(LootableObjects obj)
    {
        //For the character to grab a LootableObject
        _objectsLooted.Add(obj.Data);
        CurrentWeight += obj.Data.Weight;
        ScoreManager.Instance.CurrentScore += obj.Data.Price*10;
        _audioGrab.Play();
        Destroy(obj.gameObject, 0.5f);
        Debug.Log("Object Looted : " + obj.gameObject.name);
    }

    private void Drop()
    {
        //For the character to drop the oldest object he grabbed
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_objectsLooted.Count != 0)
            {
                GameObject obj = _lootablePrefab;
                obj.GetComponent<LootableObjects>().Data = _objectsLooted[0];
                Instantiate(obj, transform.position, Random.rotation);
                _currentWeight -= _objectsLooted[0].Weight;
                ScoreManager.Instance.CurrentScore -= _objectsLooted[0].Price*10;
                _objectsLooted.RemoveAt(0);
            }
        }
    }

    private void Pause()
    {
        //For the player to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TimeManager.Instance.Paused = !TimeManager.Instance.Paused;
        }
     
    }

}
