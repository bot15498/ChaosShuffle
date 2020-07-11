using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public int behaviorValue = 1;
    public float speed;
    Transform playerTransform;
    public float RetreatDistance;
    public float stopDistance;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
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
    

    void pursue()
    {
        Vector2 PlayerMove = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        rb2d.MovePosition(PlayerMove);
    }

    void DistanceFollow()
    {
        if(Vector2.Distance(transform.position,playerTransform.position) > stopDistance){
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

        }  else if (Vector2.Distance(transform.position,playerTransform.position) < stopDistance && Vector2.Distance(transform.position,playerTransform.position) > RetreatDistance)
        {
            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position,playerTransform.position) < RetreatDistance) 
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, -speed * Time.deltaTime);
        }
    }
}
