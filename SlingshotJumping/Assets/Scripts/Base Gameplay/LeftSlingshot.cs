using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSlingshot : MonoBehaviour {
    [SerializeField] public GameObject grenade;
    [SerializeField] public GameObject otherSlingshot;
    private Vector3 mousePos;
    
    private void Update() {
        mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        ListenForInputs();
    }

    private void ListenForInputs() {
        if(Input.GetMouseButton(0)) {
            AimSlingshot();
        } if(Input.GetMouseButtonUp(0)) {
            ShootSlingshot();
            transform.localRotation = Quaternion.Euler(0,0,0);
            otherSlingshot.GetComponent<RightSlingshot>().enabled = true;
        } if(Input.GetMouseButtonDown(0)) {
            otherSlingshot.GetComponent<RightSlingshot>().enabled = false;
        }
    }
    

    private void AimSlingshot() {      
        GetComponent<SpriteRenderer>().enabled = true;
        
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    private void ShootSlingshot() {
        float distance = Vector3.Distance(mousePos,transform.position);
        distance *= 1;
        GameObject _grenade = Instantiate(grenade,transform.position,Quaternion.identity) as GameObject;
        _grenade.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * distance, ForceMode2D.Impulse);
        _grenade.GetComponent<Grenade>().secondsToDet = 2;

        GetComponent<SpriteRenderer>().enabled = false;
    }
}