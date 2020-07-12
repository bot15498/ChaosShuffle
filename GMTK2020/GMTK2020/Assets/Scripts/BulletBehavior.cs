using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public bool richochet;
    public float damage;
    public float BulletSpeed;
    public int bulletBouncesAllowed = 0;

    private int numberOfBounces;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * BulletSpeed;
        richochet = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateDamage(float damagevalue)
    {
        damage = damagevalue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
            Destroy(gameObject);
        }

        if (richochet == false)
        {
            Destroy(gameObject);
        }
    }
}
