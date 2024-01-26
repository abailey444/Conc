using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    [SerializeField] public GameObject player;

    private void FixedUpdate() {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y + 2, -10);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, 10f * Time.deltaTime);
    }
}