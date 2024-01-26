using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    private GameObject player;
    public LayerMask playerLayer;
    
    private void Start() {
        player = GameObject.Find("Player");
        StartCoroutine(ExplodeIn(3f));
    }

    private IEnumerator ExplodeIn(float seconds) {
        yield return new WaitForSeconds(seconds);
        Explode();
    }

    private void Explode() {
        GetComponent<SpriteRenderer>().color = Color.red;
        bool playerHit = Physics2D.OverlapCircle(transform.position, 3f, playerLayer);
        if(playerHit) {
            Vector3 newForce = CalculateDamage();
            player.GetComponent<Rigidbody2D>().AddForce(newForce, ForceMode2D.Impulse);
        }
    }

    private Vector3 CalculateDamage() {
        Vector3 newThrust = player.transform.position - this.transform.position;
        newThrust.z = 0;

        // -2.5x^2 + x + 3
        if(newThrust.x > 0) { // positive x
            newThrust.x = (-0.55f * Mathf.Pow(newThrust.x,2)) + 4;
        } else { // negative x
            newThrust.x = (-0.55f * Mathf.Pow(newThrust.x,2)) + 4;
            newThrust.x = -newThrust.x;
        }

        if(newThrust.y > 0) { // positive y
            newThrust.y = (-0.55f * Mathf.Pow(newThrust.y,2)) + 4;
        } else { // negative y
            newThrust.y = (-0.55f * Mathf.Pow(newThrust.y,2)) + 4;
            newThrust.y = -newThrust.y;
        }

        return newThrust;
    }
}