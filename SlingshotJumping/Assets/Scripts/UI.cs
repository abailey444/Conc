using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour {
    [SerializeField] public GameObject player;
    [SerializeField] public TMP_Text speedometer;

    private void Update() {
        DisplaySpeed();
    }

    private void DisplaySpeed() {
        double velocity = player.GetComponent<Rigidbody2D>().velocity.magnitude;
        velocity = Math.Round(velocity,2);
        speedometer.text = "Speedo: " + velocity.ToString();   
    }
}