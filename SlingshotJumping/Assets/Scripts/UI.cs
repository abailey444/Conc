using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour {
    [SerializeField] public Slider loadingBar;
    public float progress;

    public IEnumerator UpdateLoadingBar() {
        loadingBar.gameObject.transform.parent.gameObject.SetActive(true); // this line is so awful
        
        progress = 0;
        while(progress < 1) {
            loadingBar.value = progress;
            progress += 0.02f;
            yield return new WaitForSeconds(0.01f);
        }

        progress = 0;
        loadingBar.gameObject.transform.parent.gameObject.SetActive(false);
    }
}