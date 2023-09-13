using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _vel = 7f;
    float _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(_playerInput, 0) * _vel * Time.deltaTime ); 
    }

    
}
