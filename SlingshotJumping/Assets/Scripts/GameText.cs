using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// Information ///
/// This code sequentially displays text in a text box. 
/// The speed at which it displays each character is defined by the speedPerChar float (seconds). 
/// The distance at which the script can be triggered is defined by the triggerRadius float. 
/// The string that the script outputs is dependant on whether the gameManager variable is assigned or not. 
/// If it is null, the script will output whatever the textbox is assigned to when the scene is loaded.
/// If the gameManager is assigned, it will output the keypadCode of the level with the corresponding digits found in the digitsToShow array. 
/// Set the  digits that you want to display to true, and leave the others as false.
/// Note that if the gameManager is null, there is no point in worrying about what the array is assigned to.
/// Note that the array must be the same length as the keypadCode (4 digits), or you will probably encounter an out of range error.
public class GameText : MonoBehaviour {
    private string desiredText;
    [SerializeField] public float speedPerChar;
    [SerializeField] public float triggerRadius;
    [SerializeField] public bool referenceGameManager;
    
    [Tooltip("Make null if the script should not reference gameManager.keypadCode")]
    [SerializeField] public GameManager gameManager;
    [Tooltip("Should not be larger than 4 values (0-3). Disregard this variable if gameManager is null.")]
    [SerializeField] public bool[] digitsToShow = {false, false, false, false};

    private void Start() { 
        if(gameManager == null)
            desiredText = gameObject.GetComponent<TMP_Text>().text;
        else
            desiredText = gameManager.keypadCode;
        
        
        gameObject.GetComponent<TMP_Text>().text = "";
        CircleCollider2D circleCollider = gameObject.AddComponent<CircleCollider2D>();
        circleCollider.radius = triggerRadius;
        circleCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player" && gameManager == null)
            StartCoroutine("WriteNormalText");
        if(col.gameObject.tag == "Player" && gameManager != null)
            StartCoroutine("WriteDigits");
    }

    private IEnumerator WriteNormalText() {
        foreach(char c in desiredText) {
            gameObject.GetComponent<TMP_Text>().text += c;
            yield return new WaitForSeconds(speedPerChar);
        }

        Destroy(GetComponent<Collider2D>());
        Destroy(this);
    }

    private IEnumerator WriteDigits() {
        for(int i=0;i<gameManager.keypadCode.Length;i++) {
            if(digitsToShow[i] == true)
                gameObject.GetComponent<TMP_Text>().text += gameManager.keypadCode[i];
                yield return new WaitForSeconds(speedPerChar);
        }

        Destroy(GetComponent<Collider2D>());
        Destroy(this);
    }
}
