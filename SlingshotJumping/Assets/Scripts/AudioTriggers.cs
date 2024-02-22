using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{

    public AudioSource BookExplosionSFX;
    public AudioClip BookAudio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        BookAudios();
    }

    public void BookAudios()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(3);
        audioSource.clip = BookAudio;
        audioSource.Play();
    }
}
