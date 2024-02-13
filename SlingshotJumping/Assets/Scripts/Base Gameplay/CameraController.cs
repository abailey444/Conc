using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour {
    // We use cinemachine virtual cameras for what this script used to accomplish.
    private CinemachineVirtualCamera vcam;

    private void Start()  {
        gameObject.GetComponent<Camera>().backgroundColor = Color.black;
        Screen.SetResolution(768, 432, true);

    }

    public IEnumerator AddCameraKnockback(Vector2 currentVelocity) {
        // 1. Get current velocity
        // 2. Convert the velocity to a rotation.
        // 3. Quickly rotate towards velocity rotation
        // 4. Slowly return to normal.
        
        Quaternion velRotation = Quaternion.LookRotation(currentVelocity, Vector2.up);
        transform.rotation = velRotation;

        yield return null;
    }
}