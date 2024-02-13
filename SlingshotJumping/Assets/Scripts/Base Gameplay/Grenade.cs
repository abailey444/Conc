using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {
    private GameObject player;
    private GameObject cam;
    public LayerMask playerLayer;
    public GameObject explosion;
    public int secondsToDet;
    private Rigidbody2D rb;

    private void Start() {
        player = GameObject.Find("Player");
        cam = Camera.main.gameObject;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(PlayAnimation());
        Invoke("Explode",secondsToDet);
    }

    // FUCK YOU
    private IEnumerator PlayAnimation() {
        float nonRed = 1;
        
        if(secondsToDet == 1) {
            while(nonRed > 0) {
                nonRed -= 0.01f;
                GetComponent<SpriteRenderer>().color = new Color(1,nonRed,nonRed,1);
                yield return new WaitForSeconds(0.01f);
            }
        } if(secondsToDet == 2) {
            while(nonRed > 0) {
                nonRed -= 0.01f;
                GetComponent<SpriteRenderer>().color = new Color(1,nonRed,nonRed,1);
                yield return new WaitForSeconds(0.02f);
            }
        }
    }

    private void Explode() {
        GetComponent<SpriteRenderer>().color = Color.red;
        bool playerHit = Physics2D.OverlapCircle(transform.position, 3f, playerLayer);
        if(playerHit) {
            DoKnockback();
        }
        
        StartCoroutine(DestroyGrenade());
    }

    private void DoKnockback() {
        // get distances
        float dx = player.transform.position.x - this.transform.position.x;
        float dy = player.transform.position.y - this.transform.position.y;
        float distance = (player.transform.position - this.transform.position).magnitude;
        // normalize the distances
        Vector3 diff = new Vector3(dx,dy,0).normalized;
        // inverse the knockback (i.e. the closer you are the more knockback it does)
        diff = diff * 6.5f / distance;

        // make the knockback additive to current velocity
        player.GetComponent<Rigidbody2D>().AddForce(diff, ForceMode2D.Impulse);
        StartCoroutine(cam.GetComponent<CameraController>().AddCameraKnockback(player.GetComponent<Rigidbody2D>().velocity));
    }

    private IEnumerator DestroyGrenade() {
        GetComponent<SpriteRenderer>().enabled = false;
        GameObject explosionSprite = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(2);
        Destroy(explosionSprite);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 3f);
    }

    private void OnCollisionStay2D(Collision2D col) {
        rb.drag = 2;
    }
}