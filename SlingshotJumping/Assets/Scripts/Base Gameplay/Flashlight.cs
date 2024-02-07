// This script changes the direction the flashlight is facing.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.Rendering.Universal {
    [RequireComponent(typeof(Light2D))]
    public class Flashlight : MonoBehaviour {
        [SerializeField] public GameObject player;
        [SerializeField] public LayerMask playerLayer;
        private Vector3 mousePos;

        private void FixedUpdate() {
            mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        
            // Change speed based on if the mouse is inside the player.
            // Meant to prevent fast and weird looking flashlight movements.
            // May be a very slight performance hit (estimated 5 frames.)
            RaycastHit2D hit = Physics2D.Raycast(mousePos, player.transform.position, 5f, playerLayer);
            if(hit.collider == null)
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10f * Time.deltaTime); // Default speed
            else
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 3f * Time.deltaTime);

            // This part changes the way the sprite is facing based on the mouse position.
            var delta = player.transform.position.x - mousePos.x;
            delta = Mathf.Sign(delta);
            if(delta == 1)
                player.GetComponent<SpriteRenderer>().flipX = true;
            if(delta == -1)
                player.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
