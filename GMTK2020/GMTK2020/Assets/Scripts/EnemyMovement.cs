using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool following = true;
    public bool snakeMovement = false;
    public bool canMove = true;
    public bool icyfloor = false;
    public int behaviorValue = 1;
    public float speed = 2.5f;
    public float icySpeed = 3f;
    public Transform arm;
    Transform playerTransform;
    public float RetreatDistance;
    public float stopDistance;
    Rigidbody2D rb2d;
    bool facingRight;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove && following)
        {
            switch (behaviorValue)
            {
                case 2:
                    DistanceFollow();
                    break;
                case 1:
                    pursue();
                    break;
                default:

                    break;
            }
        }

        WeaponFlipping();
    }

    void WeaponFlipping()
    {
        //current mouse position
        
        var delta = playerTransform.position - transform.position;

        //CharacterFlipping
        if (delta.x >= 0 && !facingRight)
        { // mouse is on right side of player

        
             sr.flipX = false;
            //WeaponSprite.flipY = false;
            facingRight = true;

        }
        else if (delta.x < 0 && facingRight)
        { // mouse is on left side
           
            sr.flipX = true;
            //WeaponSprite.flipY = true;


            facingRight = false;
        }
    }

    public void AddKnockback(Vector2 direction, float force, float duration)
    {
        canMove = false;
        StopMoving();
        rb2d.AddForce(direction.normalized * force);
        StartCoroutine(StopMoving(duration));
    }

    private IEnumerator StopMoving(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        canMove = true;
        StopMoving();
        yield return null;
    }

    public void StopMoving()
    {
        if(rb2d != null)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0f;
        }
    }


    void pursue()
    {
        if (icyfloor)
        {
            rb2d.drag = 0.5f;
            Vector2 PlayerMove = playerTransform.position - transform.position;
            rb2d.AddForce(PlayerMove.normalized * icySpeed);
        }
        else
        {
            rb2d.drag = 0f; ;
            Vector2 PlayerMove = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
            if(snakeMovement)
            {
                rb2d.MovePosition(PlayerMove.normalized);
            }
            else
            {
                rb2d.MovePosition(PlayerMove);
            }
        }
    }

    void DistanceFollow()
    {
        if(icyfloor)
        {
            rb2d.drag = 0.5f;
            if (Vector2.Distance(transform.position, playerTransform.position) > stopDistance)
            {
                Vector2 PlayerMove = playerTransform.position - transform.position;
                rb2d.AddForce(PlayerMove.normalized * icySpeed);
            }
            else if (Vector2.Distance(transform.position, playerTransform.position) < stopDistance && Vector2.Distance(transform.position, playerTransform.position) > RetreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, playerTransform.position) < RetreatDistance)
            {
                Vector2 PlayerMove = transform.position - playerTransform.position;
                rb2d.AddForce(PlayerMove.normalized * icySpeed);
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, playerTransform.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

            }
            else if (Vector2.Distance(transform.position, playerTransform.position) < stopDistance && Vector2.Distance(transform.position, playerTransform.position) > RetreatDistance)
            {
                transform.position = this.transform.position;
            }
            else if (Vector2.Distance(transform.position, playerTransform.position) < RetreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, -speed * Time.deltaTime);
            }
        }
    }
}
