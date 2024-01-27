using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    private GameObject player;

    private void Start() => player = GameObject.Find("Player");

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Player")
            player.transform.position = new Vector2(0,0);
    }
}
