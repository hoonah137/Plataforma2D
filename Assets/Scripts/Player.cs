using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _vel = 7f;
    float _playerInput;
    //float _vertical;

    //componentes
    Rigidbody2D _rBody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    void FixedUpdate()
    {
        Move();
    }

      void Move()
    {
        _playerInput = Input.GetAxis("Horizontal");

        _rBody2D.velocity = new Vector2(_playerInput * _vel, 0);
        
          

        /*
         Movimiento sin fisicas
        
            _playerInput = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            transform.Translate(new Vector2(_playerInput, _vertical) * _vel * Time.deltaTime ); 
        
        Movimiento add force (es ago erratico)
            _rBody2D.AddForce(new Vector2(_playerInput * _vel, 0), ForceMode2D.Impulse);  
        */
    }

    
}
