using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] public GameObject player;
    [SerializeField] public float speed;

    private void FixedUpdate() {
        Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y + 2, -10);
        Vector3 currentPos = new Vector3(transform.position.x, transform.position.y, -10);

        float distance = (targetPos - currentPos).magnitude;
        float speedChange = (speed / distance);

        float time = Time.deltaTime * speedChange * speed;
        transform.position = Vector3.Lerp(currentPos,targetPos,time);
    }
}