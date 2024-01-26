using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassCalculator : MonoBehaviour {
    private Rigidbody2D rb;
    private Bounds colliderBounds;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.mass = 1;

        colliderBounds = GetComponent<Collider2D>().bounds;
    }

    private void Update() {
        colliderBounds = GetComponent<Collider2D>().bounds;
        float newMass;
        float boundsArea = colliderBounds.size.x * colliderBounds.size.y;

        if(boundsArea >= 2)
            newMass = 1;
        else
            newMass = (colliderBounds.size.x * colliderBounds.size.y) / 2;

        rb.mass = newMass;
    }
}