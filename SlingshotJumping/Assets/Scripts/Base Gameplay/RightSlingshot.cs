using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightSlingshot : MonoBehaviour {
    [SerializeField] public GameObject grenade;
    [SerializeField] public GameObject otherSlingshot;
    private Vector3 mousePos;

    private void Update() {
        mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ListenForInputs();
    }

    private void ListenForInputs() {
        if(Input.GetMouseButton(1)) {
            AimSlingshot();
        } if(Input.GetMouseButtonUp(1)) {
            ShootSlingshot();
            transform.localRotation = Quaternion.Euler(0,0,0);
            otherSlingshot.GetComponent<LeftSlingshot>().enabled = true;
        } if(Input.GetMouseButtonDown(1)) {
            otherSlingshot.GetComponent<LeftSlingshot>().enabled = false;
        }
    }

    private void AimSlingshot() {      
        GetComponent<SpriteRenderer>().enabled = true;
        
        Vector3 perpendicular = transform.position - mousePos;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, perpendicular);
    }

    private void ShootSlingshot() {
        float distance = Vector3.Distance(mousePos,transform.position);
        distance *= 0.75f;
        GameObject _grenade = Instantiate(grenade,transform.position,Quaternion.identity) as GameObject;
        _grenade.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * distance, ForceMode2D.Impulse);
        _grenade.GetComponent<Grenade>().secondsToDet = 1;

        GetComponent<SpriteRenderer>().enabled = false;
    }
}
