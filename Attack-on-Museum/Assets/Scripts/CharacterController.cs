using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5;
    [SerializeField] private float _maxWeight = 100;
    [SerializeField] private float _currentWeight = 0;
    [SerializeField] private List<LootableObjects> _objectsLooted = new List<LootableObjects>();
    [SerializeField] private bool _oldLady = false;

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
        if (!TimeManager.Instance.Paused || !TimeManager.Instance.GameOver)
        {
            MoveUp();
            MoveDown();
            MoveRight();
            MoveLeft();
            PlusWeight();
            MinusWeight();
        }
    }

    private void MoveUp()
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

    private void PlusWeight()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            CurrentWeight += 10;
        }
    }

    private void MinusWeight()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            CurrentWeight -= 10;
        }
    }

    public void Grab(LootableObjects obj)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _objectsLooted.Add(obj);
            CurrentWeight += obj.Data.Weight;
            Destroy(obj.gameObject);
            Debug.Log("Object Looted : " + obj.gameObject.name);
        }
    }
}
