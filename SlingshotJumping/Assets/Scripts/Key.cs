using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    private bool isActive = false;
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player")
            player = col.gameObject;
            isActive = true;
        if(isActive && col.gameObject.tag == "Keypad")
            isActive = false;
    }

    private void FixedUpdate() {
        if(isActive) {
            MoveKeyToPlayer();
        }
    }

    private void MoveKeyToPlayer() {
        float magnitude = Vector3.Distance(transform.position, player.transform.position);
        Vector3 desiredPos = player.transform.position;
        desiredPos.y += 1.5f;

        float oscillation = 60 / magnitude;
        oscillation = Mathf.Pow(oscillation, 1/2);
        oscillation = Mathf.Clamp(oscillation,0,10);
        desiredPos.y += Mathf.Sin(Time.time * oscillation) * 0.1f;

        transform.position = Vector3.Slerp(transform.position, desiredPos, 3f * magnitude * Time.deltaTime);
    }
}
