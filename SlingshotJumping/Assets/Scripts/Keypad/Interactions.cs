using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactions : MonoBehaviour {
    [Serializable]
    public struct KeypadData {
        public GameObject keypadPanel;
        [HideInInspector] public InputField keypadInput;
        public LayerMask keypadLayer;
    } [SerializeField]
    public KeypadData kd;

    [HideInInspector]
    public bool passInputs = true;

    private GameManager instance;

    public ButtonDoorScr bds;

    public GameObject door1;
    public GameObject door2;

    public GameObject notePanel;

    public GameObject kpdPanel;
    public GameObject Monster;

    //can edit later
    //key and locker variables to get keypad for lvl 1 to work right

    public GameObject key;
    public GameObject locker1;
    public GameObject locker2;

    private void Start() {
        Transform child = kd.keypadPanel.transform.GetChild(0);
        kd.keypadInput = child.gameObject.GetComponent<InputField>();
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();

        key.SetActive(false);
    }

    private void Update() {
        if((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Keypad1)) && passInputs) {
            CheckForOverlapOnPress();
        }

        if(!passInputs)
            CheckForNoOverlap();

        if (Input.GetKeyDown("0"))
        {
            instance.GoToNextLevel();
        }
        if (Input.GetKeyDown("1"))
        {
            instance.hasKey = true;
        }
    }

    private void CheckForOverlapOnPress() {
        Collider2D circle = Physics2D.OverlapCircle(transform.position, 1f, kd.keypadLayer);
        if(circle != null && circle.gameObject.tag == "Keypad") {
            kd.keypadPanel.SetActive(true);
            passInputs = false;
        }
    }

    private void CheckForNoOverlap() {
        Collider2D circle = Physics2D.OverlapCircle(transform.position, 2f, kd.keypadLayer);
        if(circle == null) {
            kd.keypadPanel.SetActive(false);
            passInputs = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Exit" && instance.hasKey == true)
            instance.GoToNextLevel();

        if (col.gameObject.tag == "Button")
        {
            bds.closestDoor.GetComponent<BoxCollider2D>().enabled = false;

            door1 = bds.closestDoor.transform.GetChild(0).gameObject;
            door2 = bds.closestDoor.transform.GetChild(1).gameObject;

            door1.SetActive(false);
            door2.SetActive(true);

        }
        if (col.gameObject.tag == "InRoom")
        {
            bds.roomBlinds.SetActive(false);
        }
        if (col.gameObject.tag == "OutRoom")
        {
            bds.roomBlinds.SetActive(true);
        }
        if(col.gameObject.tag == "openKeypad")
        {
            kpdPanel.SetActive(true);
        }
        if (col.gameObject.tag == "closeKeypad")
        {
            kpdPanel.SetActive(false);
        }
        if (col.gameObject.tag == "Spawner")
        {
            Monster.SetActive(true);
        }
        if (col.gameObject.tag == "Despawner")
        {
            Monster.SetActive(false);
        }
    }

    public void OnClickNote()
    {
        notePanel.SetActive(true);
    }

    public void OnClickExit()
    {
        notePanel.SetActive(false);
        kpdPanel.SetActive(false);
    }

    //IF THE LOCKER IS OPEN ENABLE KEY, LOCKER IS OPENED WITH KEYPAD

}
