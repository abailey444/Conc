using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{
    public bool hasKey = false;
    public GameObject door;
    public GameObject key;

    public GameObject keyPanel;
    public bool code;

    public AudioSource BookExplosionSFX;
    public AudioClip BookAudio;

    //public GameObject player;
    Rigidbody2D playerRigidbody;

    void Start()
    {
        keyPanel.SetActive(false);
        code = false;

        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Key")
        {
            hasKey = true;
        }

        if (collider.gameObject.tag == "Button")
        {
            door.SetActive(false);
        }

        if(collider.gameObject.tag == "Monster")
        {
            //play monster jumpscare screen
            SceneManager.LoadScene("Credits"); //load lose scene instead
        }

        if(collider.gameObject.tag == "Door")
        {

        }
    }

    public void OnClickKeypad()
    {
        keyPanel.SetActive(true);
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    public void OnClickExitKeypad()
    {
        keyPanel.SetActive(false);
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void OnClickEnter()
    {
        if(code == true)
        {
            keyPanel.SetActive(false);
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }  
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

  