using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField] public float p_HorizontalThrust;
    [SerializeField] public float p_VerticalThrust;
    [SerializeField] public LayerMask ignoredLayer;
    [SerializeField] public float crouchHeight;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        MoveHorizontal();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            Jump();
        if(Input.GetKeyDown(KeyCode.LeftShift))
            Crouch();
        
        if(Input.GetKeyUp(KeyCode.LeftShift))
            UnCrouch();
    }

    private void MoveHorizontal() {
        // This is highly influenced by the sensitivity of horizontal input within the project settings.
        float h = Input.GetAxis("Horizontal");
        h *= p_HorizontalThrust;
        h *= Time.deltaTime;
        transform.Translate(h,0,0);
    }

    private void Jump() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.05f, ~ignoredLayer);
        if(hit.collider != null) {
            // save me... save me lord ...... lord save me ....
            if(rb.mass <= 0.99) // AGHJ
                rb.AddForce(transform.up * (p_VerticalThrust * 0.5f), ForceMode2D.Impulse);
            else
                rb.AddForce(transform.up * p_VerticalThrust, ForceMode2D.Impulse);
        } 
    }

    private void Crouch() {
        transform.localScale = new Vector2(1,0.5f);
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - crouchHeight);
    }

    private void UnCrouch() {
        transform.localScale = new Vector2(1,1);
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + crouchHeight);
    }
}