using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    bool _bombIsTriggered;
    public bool explode;

    Collider2D _bombRadius;

    // Start is called before the first frame update
    void Start()
    {
        _bombIsTriggered = false;
        explode = false;

        _bombRadius = GetComponentInChildren<Collider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_bombIsTriggered == true)
        {
            yield return new WaitForSeconds(3);
            StartCoroutine("Boom");

        }
    
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 10)
        {
            _bombIsTriggered = true;
        }
    }

    IEnumerator Boom()    
    {
       explode = true;
    }
}
