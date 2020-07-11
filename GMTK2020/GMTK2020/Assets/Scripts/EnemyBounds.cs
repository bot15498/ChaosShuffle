using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounds : MonoBehaviour
{
    private bool follow = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            follow = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if (follow)
            {
                collision.gameObject.GetComponent<EnemyMovement>().following = true;
            }
            else
            {
                collision.gameObject.GetComponent<EnemyMovement>().following = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            follow = false;
        }
    }
}
