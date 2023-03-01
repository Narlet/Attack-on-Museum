using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 100;
    [SerializeField] private float _maxWeight = 100;
    [SerializeField] private float _currentWeight = 0;
    [SerializeField] private List<LootableObjects> _objectsLooted = new List<LootableObjects>();
    [SerializeField] private bool _oldLady = false;

    // Start is called before the first frame update
    void Start()
    {
      
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
        }
    }

    private void MoveUp()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.position = transform.position + (Vector3.forward) * _maxSpeed * (1 - _currentWeight / _maxWeight) * Time.deltaTime;
        }
    }

    private void MoveDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (Vector3.back) * _maxSpeed * (1 - _currentWeight / _maxWeight) * Time.deltaTime;
        }
    }

    private void MoveRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right) * _maxSpeed * (1 - _currentWeight / _maxWeight) * Time.deltaTime;
        }
    }

    private void MoveLeft()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position = transform.position + (Vector3.left) * _maxSpeed * (1 - _currentWeight / _maxWeight) * Time.deltaTime;
        }
    }
}
