using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class Player : MonoBehaviour
{
    [Header("Player Stats")]   
    [Tooltip("Controla velocidad")] 
    [SerializeField] float _vel = 7f;
    float _playerHorizontal;
    float _playerVertical;

    [Tooltip("Controla fuerza de salto")] 
    [SerializeField] float _jForce = 0.5f;
    //float _vertical;

    //componentes
    Rigidbody2D _rBody2D;
    GroundSensor _sensor;
    [SerializeField] Animator _animator;
    SpriteRenderer _sRenderer;

    [SerializeField] PlayableDirector _director;

    // Start is called before the first frame update
    
    void Start()
    {
        _rBody2D = GetComponent<Rigidbody2D>();
        _sensor = GetComponentInChildren<GroundSensor>();
        _sRenderer = GetComponentInChildren<SpriteRenderer>();

        Debug.Log (GameManager.instance.vidas);
    }

    // Update is called once per frame
    void Update()
    {                    
        if (Input.GetButtonDown("Jump") && _sensor._isGrounded) 
        {
            Jump();
        }
        
        Animate();

        
    }

    void FixedUpdate()
    {
        Move();

        if (Input.GetButtonDown("Fire2"))
        {
            _director.Play();
        }
        
       
    }

//Funciones de Accion
      
    void Animate()
    {
        _playerHorizontal = Input.GetAxis("Horizontal");
        _playerVertical = Input.GetAxis("Vertical");

        //Turn
        if(_playerHorizontal < 0)
        {
            _sRenderer.flipX = true;
        } 
        if(_playerHorizontal > 0)
        {
            _sRenderer.flipX = false;
        }   


        //Run
        
        if(_playerHorizontal != 0)
        {
            _animator.SetBool("isRunning",true);
        }
        if(_playerHorizontal ==0 )
        {
            _animator.SetBool("isRunning",false);
        }

        //Jump
        if (_sensor._isGrounded == true)
        {
            _animator.SetBool("isJumping",false);
        }

        if (_sensor._isGrounded == false)
        {
            _animator.SetBool("isJumping",true);

        }

       
    }
      
    void Move()
    {
        _rBody2D.velocity = new Vector2(_playerHorizontal * _vel, _rBody2D.velocity.y);
        
    }

    void Jump()
    { 
      
      _rBody2D.AddForce(new Vector2(0, _jForce), ForceMode2D.Impulse);
      SoundManager.instance.JumpSound();
         

    }

    public void SignalRecived()
    {
        Debug.Log("AYOOOOO");
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.layer == 6)
        {
            GameManager.instance.GameOver();
            SoundManager.instance.GameOverSound();
            Destroy(this.gameObject);
        }
    }

    
}

  /*
         Movimiento sin fisicas
            _vertical = Input.GetAxis("Vertical");
            _playerHorizontal = Input.GetAxis("Horizontal");
            _vertical = Input.GetAxis("Vertical");
            transform.Translate(new Vector2(_playerHorizontal, _vertical) * _vel * Time.deltaTime ); 
        
        Movimiento add force (es ago erratico)
            _rBody2D.AddForce(new Vector2(_playerHorizontal * _vel, 0), ForceMode2D.Impulse);  
        */
