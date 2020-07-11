using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool useArrowKeys = false;
    public bool mirrored = false;
    public float speed;
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

        playerRigidbody.velocity = new Vector2(h * speed, v * speed);
    }
}
