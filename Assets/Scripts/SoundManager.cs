using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static SoundManager instance {get; private set;}
    AudioSource _audio;
    [SerializeField] AudioClip _deadSound;
    [SerializeField] AudioClip _jumpingSound;
    
    void Awake()
    {
        
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        _audio = GetComponent<AudioSource>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverSound ()
    {
        _audio.PlayOneShot(_deadSound);
    }

    public void JumpSound ()
    {
        _audio.PlayOneShot(_jumpingSound);
    }
}
