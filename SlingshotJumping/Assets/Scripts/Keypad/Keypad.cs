using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;

public class Keypad : MonoBehaviour {
    private GameManager instance;
    private TMP_InputField inField;
    public Interactions intScr;
    public bool isOpen = false;

    public GameObject locker;
    public GameObject locker1;
    public GameObject locker2;


    //public Canvas keyCanv;

    private void Start() { 
        inField = GetComponent<TMP_InputField>();
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void Update()
    {
        //checkIfOpen();
    }

    public void OnClickEnter() {
        if(inField.text.ToString() == instance.keypadCode) {
            inField.text = "Correct code.";
            inField.enabled = false;

            locker1 = locker.transform.GetChild(0).gameObject;
            locker2 = locker.transform.GetChild(1).gameObject;

            locker1.SetActive(false);
            locker2.SetActive(true);


            locker1.SetActive(false);
            locker2.SetActive(true);
            intScr.key.SetActive(true);

            if (instance.sceneName != "Level1")
            {
                GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
                foreach (GameObject door in doors)
                {
                    door.SetActive(false);
                }
            
            }
            else
            {
                locker1 = locker.transform.GetChild(0).gameObject;
                locker2 = locker.transform.GetChild(1).gameObject;

                locker1.SetActive(false);
                locker2.SetActive(true);


                locker1.SetActive(false);
                locker2.SetActive(true);
                intScr.key.SetActive(true);
            }
        } 
        else {
           inField.text = "Incorrect code.";
        }
    }

    public void checkIfOpen()
    {
        if(inField.text == "Correct code.")
        {
            isOpen = true;
        }
    }

}
