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

    private ButtonDoorScr bds;

    private void Start() {
        Transform child = kd.keypadPanel.transform.GetChild(0);
        kd.keypadInput = child.gameObject.GetComponent<InputField>();
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update() {
        if((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Keypad1)) && passInputs) {
            CheckForOverlapOnPress();
        }

        if(!passInputs)
            CheckForNoOverlap();
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
            bds.roomBlinds.SetActive(false);

            //bds.closestDoor.tr;
        }
    }
}
