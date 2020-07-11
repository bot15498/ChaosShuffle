using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public int behaviorValue;
    public float speed;
    Transform playerTransform;
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

    }
}
