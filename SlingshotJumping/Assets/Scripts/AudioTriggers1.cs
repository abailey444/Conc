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


