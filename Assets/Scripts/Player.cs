using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _vel = 7f;
    float _playerInput;
    float _vertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Move();

    }

    void Move()
    {
         _playerInput = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(_playerInput, _vertical) * _vel * Time.deltaTime );        
    }

    
}
