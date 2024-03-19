using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Keypad : MonoBehaviour {
    private GameManager instance;
    private TMP_Text textObj;
    private string enteredCode = "";

    private void Start() { 
        instance = GameObject.Find("GameManager").GetComponent<GameManager>();
        textObj = GetComponent<TMP_Text>();
    }

    // Updates the displayed code in the UI.
    // "CLEAR" (case sensitive) clears the screen
    // Buttons stop doing anything when you reach 6 digits. 
    private void SetCode(string toAdd) {
        if(toAdd == "CLEAR") {
            enteredCode = "";
        } else {
            if(4 > enteredCode.Length)
                enteredCode += toAdd;
        }

        textObj.text = enteredCode;
    }

    // Putting this in a separate method because I don't like nesting code.
    // Finds a list of all the keypad buttons and turns off interactability. 
    private void TurnOffButtons() {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("UIButton");
        foreach(var button in buttons) {
            button.GetComponent<Button>().interactable = false;
        }
    }

    #region buttons

    public void OnClickOne() {
        SetCode("1");
    } public void OnClickTwo() {
        SetCode("2");
    } public void OnClickThree() {
        SetCode("3");
    } public void OnClickFour() {
        SetCode("4");
    } public void OnClickFive() {
        SetCode("5");
    } public void OnClickSix() {
        SetCode("6");
    } public void OnClickSeven() {
        SetCode("7");
    } public void OnClickEight() {
        SetCode("8");
    } public void OnClickNine() {
        SetCode("9");
    } public void OnClickClear() {
        SetCode("CLEAR");
    } public void OnClickEnter() {
        // Check if code is correct
        if(enteredCode == instance.keypadCode) {
            textObj.text = "Correct code.";
            TurnOffButtons();
            instance.keyEnabled = true;
        } else {
            textObj.text = "Incorrect code.";
            SetCode("CLEAR");
        }
    }

    #endregion
}
