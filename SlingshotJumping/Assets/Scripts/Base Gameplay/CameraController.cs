using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    // We use cinemachine virtual cameras for what this script used to accomplish.

    private void Start()  {
        gameObject.GetComponent<Camera>().backgroundColor = Color.black;
        Screen.SetResolution(768, 432, true);
    }
}