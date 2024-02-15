using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MothMonster : MonoBehaviour
{
    public Transform playerTransform;
    private float speed;
    private Rigidbody2D rb;
    private Vector3 directionToPlayer;
    private Vector3 localScale;
    float distance;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        speed = 2f;
        localScale = transform.localScale;
        
    }

    private void FixedUpdate()
    {
        MoveEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(playerTransform.position, rb.position);
        ScreenShake();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "EndMonster")
        {
            Destroy(gameObject);
        }
    }

    private void MoveEnemy()
    {
        directionToPlayer = (playerTransform.position - transform.position).normalized;
        rb.velocity = new Vector2(directionToPlayer.x, directionToPlayer.y) * speed;
    }

    private void ScreenShake()
    {
        if(distance<= 5)
        {
            //screenshake
            Debug.Log("Shake the screen");
        }
    }

    //make transorm instead of player object
    //find the transform of player
    //find gameobject

}
