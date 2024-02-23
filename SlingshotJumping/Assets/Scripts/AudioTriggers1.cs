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

    IEnumerator bookTossAndBoom()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = bookThrow;
        audioSource.Play();
        yield return new WaitForSeconds(1);
        audioSource.clip = BookExplosion;
        audioSource.PlayDelayed(3);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            bookTossAndBoom();
        }
    }

    public void bookCheck()
    {

    }
}


