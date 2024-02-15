using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerScript : MonoBehaviour
{
    public bool hasKey = false;
    public GameObject door;
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Key")
        {
            Destroy(collider.gameObject);
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
    }
}
