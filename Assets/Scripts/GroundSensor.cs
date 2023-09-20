using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{

    public bool _isGrounded;

    void OnTriggerEnter2D()
    {
        _isGrounded = true;
    }

 void OnTriggerStay2D()
    {
        _isGrounded = true;
    }

    void OnTriggerExit2D()
    {
        _isGrounded = false;
    }
}
