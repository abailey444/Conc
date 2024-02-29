using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {
    private GameObject player;
    private GameManager instance;

    private void Start() => instance = GameObject.Find("GameManager").GetComponent<GameManager>();

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player") {
            player = col.gameObject;
            instance.hasKey = true;
        }
    }

    private void FixedUpdate() {
        if(instance.hasKey) {
            MoveKeyToPlayer();
        } else {
            Oscillate();
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

    private void Oscillate() {
        Vector3 desiredPos = transform.position;

        float oscillation = 60;
        oscillation = Mathf.Pow(oscillation, 1/2);
        oscillation = Mathf.Clamp(oscillation,0,10);
        desiredPos.y += Mathf.Sin(Time.time * oscillation) * 0.1f;

        transform.position = Vector3.Slerp(transform.position, desiredPos, 3f * Time.deltaTime);
    }
}
