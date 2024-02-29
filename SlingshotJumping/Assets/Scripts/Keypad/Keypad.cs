using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour {
    private GameManager instance;
    private TMP_InputField inField;

    private void Start() { 
        inField = GetComponent<TMP_InputField>();
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void OnClickEnter() {
        if(inField.text.ToString() == instance.keypadCode) {
            inField.text = "Correct code.";
            inField.enabled = false;

            GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
            foreach(GameObject door in doors) {
                door.SetActive(false);
            }
        } else {
           inField.text = "Incorrect code.";
        }
    }
}
