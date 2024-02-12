using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    private void Start()  {
        gameObject.GetComponent<Camera>().backgroundColor = Color.black;
        Screen.SetResolution(320, 180, true);
    }
}