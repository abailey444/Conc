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

    public ScaryScr scary;

    Rigidbody2D monsterRigidbody;

    public LayerMask ground;

    float yVal;


   


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        speed = 2f;
        localScale = transform.localScale;
        monsterRigidbody = GetComponent<Rigidbody2D>();
        monsterRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
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
            StartCoroutine(scary.MonsterCloseEffect());
        }
    }

    bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.0f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, ground);
        if (hit.collider != null)
        {
            return true;
            speed = 2f;
            yVal = transform.position.y;
            transform.position = new Vector2(transform.position.x,yVal);

        }
        else
        {
            return false;
            speed = 1.0f;

            //see what height it is right before it leaves ground, cap it at like height +2 and then return it to original height slowly
        }
        //if its on the ground, check the y val if it isnt on the ground use the flight.
    }

    //make transorm instead of player object
    //find the transform of player
    //find gameobject

}
