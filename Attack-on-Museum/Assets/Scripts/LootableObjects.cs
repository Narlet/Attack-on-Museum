using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootableObjects : MonoBehaviour
{
    [SerializeField] private float _grabRange = 1;
    [SerializeField] private LootableObjectsData _data = null;
    [SerializeField] private CircleCollider2D _grabCollider = null;

    public LootableObjectsData Data => _data;

    // Start is called before the first frame update

    private void Awake()
    {
        _grabCollider.radius = _grabRange;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == ScoreManager.Instance.Character)
        {
            ScoreManager.Instance.CharacterController.Grab(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject);
    }
}
