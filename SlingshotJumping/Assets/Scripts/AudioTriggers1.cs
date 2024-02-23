using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{

    public AudioSource AudioSource;
    public AudioClip bookThrow;
    public AudioClip BookExplosion;
    public bool grenadeThrown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bookCheck()
    {
        if (Input.GetKeyUp(KeyCode.LeftMeta))
        {
            BookAudios();
        }
    }

    public void BookAudios()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = bookThrow;
        audioSource.Play();
        audioSource.clip = BookExplosion;
        audioSource.PlayDelayed(3);
    }
}
