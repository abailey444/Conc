using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour {
    [SerializeField] public GameObject player;
    [SerializeField] public TMP_Text speedometer;
    [SerializeField] public TMP_Text timer;

    private void Start() => StartCoroutine(Timer());

    private void Update() {
        DisplaySpeed();
    }

    private IEnumerator Timer() {
        float time = 0;
        while(time < 86400) {
            yield return new WaitForSeconds(1);
            time++;
            timer.text = time.ToString();
        }

        timer.text = "You've taken 24 hours. Congrats on not crashing.";
        yield return null;
    }

    private void DisplaySpeed() {
        double velocity = player.GetComponent<Rigidbody2D>().velocity.magnitude;
        velocity = Math.Round(velocity,2);
        speedometer.text = "Speedo: " + velocity.ToString();   
    }
}