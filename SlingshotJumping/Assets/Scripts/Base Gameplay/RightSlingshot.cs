using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightSlingshot : MonoBehaviour {
    [SerializeField] public GameObject grenade;
    [SerializeField] public GameObject otherSlingshot;
    [SerializeField] public GameObject canvas;
    private Vector3 mousePos;

    private void Update() {
        mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        ListenForInputs();
    }

    private void ListenForInputs() {
        if(Input.GetMouseButton(1) && canvas.GetComponent<UI>().progress == 0 && !EventSystem.current.IsPointerOverGameObject()) {
            AimSlingshot();
        } if(Input.GetMouseButtonUp(1) && canvas.GetComponent<UI>().progress == 0 && !EventSystem.current.IsPointerOverGameObject()) {
            ShootSlingshot();
            transform.localRotation = Quaternion.Euler(0,0,0);
            otherSlingshot.GetComponent<LeftSlingshot>().enabled = true;
        } if(Input.GetMouseButtonDown(1) && canvas.GetComponent<UI>().progress == 0 && !EventSystem.current.IsPointerOverGameObject()) {
            otherSlingshot.GetComponent<LeftSlingshot>().enabled = false;
        }
    }

    private void AimSlingshot() {      
        GetComponent<SpriteRenderer>().enabled = true;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime);
    }

    private void ShootSlingshot() {
        float distance = Vector3.Distance(mousePos,transform.position);
        distance = Mathf.Clamp(distance, 0, 13);
        GameObject _grenade = Instantiate(grenade,transform.position,Quaternion.identity) as GameObject;
        _grenade.GetComponent<Rigidbody2D>().AddForce(gameObject.transform.up * distance, ForceMode2D.Impulse);
        _grenade.GetComponent<Grenade>().secondsToDet = 1;

        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(canvas.GetComponent<UI>().UpdateLoadingBar());
    }
}
