using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour {
    [SerializeField] public GameManager instance;
    private TMP_InputField inField;

    private void Start() => inField = GetComponent<TMP_InputField>();

    public void OnClickEnter() {
        if(inField.text.ToString() == instance.keypadCode) {

        } else {
           
        }
    }
}
