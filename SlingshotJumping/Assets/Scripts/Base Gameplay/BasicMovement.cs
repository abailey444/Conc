using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour {
    private Rigidbody2D rb;
    [SerializeField] public float p_HorizontalThrust;
    [SerializeField] public float p_VerticalThrust;
    [SerializeField] public LayerMask ignoredLayer;
    [SerializeField] public float crouchHeight;
    [SerializeField] public Sprite[] sprites; // 0 idle 1 crouch
    private float rayLength;
    private RaycastHit2D rayDown;
    private float[] clampValues = new float[2];
    private bool tryingToUncrouch = false;

    [Serializable]
    public enum ForceModifier {
        normal,
        ice,
        air
    } [SerializeField]
    private ForceModifier forceModifier;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        forceModifier = ForceModifier.normal;
        rayLength = 1.05f;

        clampValues[0] = -6.5f;
        clampValues[1] = 6.5f;
        rb.drag = 1;
    }

    private void FixedUpdate() {
        ChangeForceState();
        float _input = Input.GetAxis("Horizontal");
        if(_input > 0)
            GetComponent<SpriteRenderer>().flipX = false;
        else if(_input < 0)
            GetComponent<SpriteRenderer>().flipX = true;

        switch(forceModifier) {
            case(ForceModifier.normal):
                rb.drag = 5;
                _input *= p_HorizontalThrust * Time.deltaTime * 15;
                rb.AddForce(Vector2.right * _input, ForceMode2D.Force);
                Vector2 clampedVelNorm = rb.velocity;
                clampedVelNorm.x = Mathf.Clamp(clampedVelNorm.x, clampValues[0], clampValues[1]);
                rb.velocity = clampedVelNorm;
                break;
            case(ForceModifier.air):
                rb.drag = 0;
                _input = ModifyAirVelocity(_input);
                rb.AddForce(Vector2.right * _input, ForceMode2D.Force);
                break;
            case(ForceModifier.ice):
                rb.drag = 0;
                _input *= p_HorizontalThrust * Time.deltaTime * 5;
                rb.AddForce(Vector2.right * _input, ForceMode2D.Force);
                Vector2 clampedVelIce = rb.velocity;
                clampedVelIce.x = Mathf.Clamp(clampedVelIce.x, clampValues[0] - 1, clampValues[1] + 1);
                rb.velocity = clampedVelIce;
                break;
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, 25);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            Jump();
        if(Input.GetKeyDown(KeyCode.LeftShift))
            Crouch();
        
        if(Input.GetKeyUp(KeyCode.LeftShift))
            tryingToUncrouch = true;
        
        if(tryingToUncrouch)
            TryToUncrouch();

        rayDown = Physics2D.Raycast(transform.position, Vector2.down, rayLength, ~ignoredLayer);
    }

    private float ModifyAirVelocity(float input) {
        float output = input;
        if(rb.velocity.x > 0 && input > 0) { // moving right, holding right
            output *= p_HorizontalThrust * Time.deltaTime;
        } else if(rb.velocity.x > 0 && input <= 0) { // moving right, holding left
            output = -rb.velocity.x * 2f;
        } else if(rb.velocity.x <= 0 && input <= 0) { // moving left, holding left
            output *= p_HorizontalThrust * Time.deltaTime;
        } else if(rb.velocity.x <= 0 && input > 0) { // moving left, holding right
            output = rb.velocity.x * -2f;
        }

        return output;
    }

    private void ChangeForceState() {
        if(rayDown.collider != null) {
            if(rayDown.transform.tag == "Ice")
                forceModifier = ForceModifier.ice;
            else
                forceModifier = ForceModifier.normal;
        } else {
            forceModifier = ForceModifier.air;
        }
    }

    // https://www.youtube.com/watch?v=eJik78bWSg0
    private void Jump() {
        if(rayDown.collider != null) {
            // save me... save me lord ...... lord save me ....
            if(rb.mass <= 0.9) // AGHJ
                rb.AddForce(transform.up * (p_VerticalThrust * 0.5f), ForceMode2D.Impulse);
            else
                rb.AddForce(transform.up * p_VerticalThrust, ForceMode2D.Impulse);
        } 
    }

    private void Crouch() {
        if(!tryingToUncrouch) {
            GetComponent<SpriteRenderer>().sprite = sprites[1];
            GetComponent<BoxCollider2D>().size = new Vector2(0.98f,0.98f);
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - crouchHeight);
            rayLength = 0.55f;
            clampValues[0] *= 0.25f;
            clampValues[1] *= 0.25f;
        }
        
    }

    private void UnCrouch() {
        tryingToUncrouch = false;
        GetComponent<SpriteRenderer>().sprite = sprites[0];
        GetComponent<BoxCollider2D>().size = new Vector2(0.98f,1.95f);
        transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + crouchHeight);
        rayLength = 1.05f;
        clampValues[0] *= 4;
        clampValues[1] *= 4;
    }

    private void TryToUncrouch() {
        Vector2 origin = new Vector2(this.transform.position.x, this.transform.position.y + 0.5f);
        RaycastHit2D hit = Physics2D.CapsuleCast(origin, new Vector2(1,1), CapsuleDirection2D.Vertical, 0, Vector2.up, 1, ~ignoredLayer);
        if(hit.collider == null)
            UnCrouch();
    }
}