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

    private void Start() {
        Transform child = kd.keypadPanel.transform.GetChild(0);
        kd.keypadInput = child.gameObject.GetComponent<InputField>();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E) && passInputs) {
            CheckForOverlapOnPress();
        }

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
}
