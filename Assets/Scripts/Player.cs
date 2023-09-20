using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _vel = 7f;
    float _playerInput;
    [SerializeField] float _jForce = 0.5f;
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
        _playerInput = Input.GetAxis("Horizontal");
        
         if (Input.GetButtonDown("Jump")) 
            {
                Jump();
            }
            
    }

    void FixedUpdate()
    {
        Move();
       
    }

//Funciones de Acción
      
      void Move()
    {
        

        _rBody2D.velocity = new Vector2(_playerInput * _vel, _rBody2D.velocity.y);
        
          

        /*
         Movimiento sin fisicas
            _vertical = Input.GetAxis("Vertical");
            _playerInput = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            transform.Translate(new Vector2(_playerInput, _vertical) * _vel * Time.deltaTime ); 
        
        Movimiento add force (es ago erratico)
            _rBody2D.AddForce(new Vector2(_playerInput * _vel, 0), ForceMode2D.Impulse);  
        */
    }

    void Jump()
    { 
      _rBody2D.AddForce(new Vector2(0, _jForce), ForceMode2D.Impulse);
         

    }

    
}
