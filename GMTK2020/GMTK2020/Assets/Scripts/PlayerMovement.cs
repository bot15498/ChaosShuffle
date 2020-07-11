using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool useArrowKeys = false;
    public bool mirrored = false;
    public bool icyFloor = false;
    public float speed;
    public float icySpeed = 3.5f;
    Rigidbody2D playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        float h = 0f;
        float v = 0f;
        if(!useArrowKeys)
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
        }
        else
        {
            h = Input.GetAxisRaw("Horizontal2");
            v = Input.GetAxisRaw("Vertical2");
        }

        if(mirrored)
        {
            h = h * -1;
            v = v * -1;
        }

        if(icyFloor)
        {
            playerRigidbody.drag = 0.5f;
            Vector2 PlayerMove = new Vector2(h, v);
            playerRigidbody.AddForce(PlayerMove.normalized * icySpeed);
        }
        else
        {
            playerRigidbody.velocity = new Vector2(h * speed, v * speed);
        }
    }
}
