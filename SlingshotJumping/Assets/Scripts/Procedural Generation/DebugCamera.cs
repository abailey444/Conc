// Quick camera made to made navigating generated tilemaps easier.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCamera : MonoBehaviour {
    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 inputVector = new Vector3(h,v,0);
        
        Vector3 targetPos = transform.position + inputVector;
        transform.position = Vector3.Slerp(transform.position, targetPos, 10f * Time.deltaTime);
    }
}
