using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerScript : MonoBehaviour
{
    public bool hasKey = false;
    public GameObject door;
    public GameObject key;

    public GameObject keyPanel;
    public bool code;

    public AudioSource AudioSource;
    public AudioClip bookThrow;
    public AudioClip bookExplosion;

    public InputField codeInput;

    //public GameObject player;
    Rigidbody2D playerRigidbody;

    public GameObject monster;

    //locker opened, then they have the book
    public bool lockerOpened = false;


    IEnumerator bookTossAndBoom()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = bookThrow;
        audioSource.Play();
        yield return new WaitForSeconds(1);
        audioSource.clip = bookExplosion;
        audioSource.Play();

    }

    void Start()
    {
        keyPanel.SetActive(false);
        code = false;
        monster.SetActive(false);
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            bookTossAndBoom();
        }
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
            Invoke("DoorBack", 2f);
        }

        if(collider.gameObject.tag == "Monster")
        {
            //play monster jumpscare screen
            SceneManager.LoadScene("Credits"); //load lose scene instead
        }

        if (collider.gameObject.tag == "Spawner")
        {
            monster.SetActive(true);
        }
        if (collider.gameObject.tag == "Despawner")
        {
            monster.SetActive(false);
        }
        if (collider.gameObject.tag == "LevelDoor")
        {
            if (hasKey == true)
            {
                SceneManager.LoadScene("LevelTemplate");
            }
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
            lockerOpened = true;
            keyPanel.SetActive(false);
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }  
    }

    public void DoorBack()
    {
        door.SetActive(true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        BookAudios();
    }

    public void BookAudios()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(3);
        audioSource.clip = bookThrow;
        audioSource.Play();
    }
}

  