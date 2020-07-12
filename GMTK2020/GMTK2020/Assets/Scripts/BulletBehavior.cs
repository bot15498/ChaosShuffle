using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject explosion;
    public bool richochet;
    public float damage;
    public float BulletSpeed;
    public int bulletBouncesAllowed = 0;
    public bool istracking = false;
    public bool explosive = false;

    private int numberOfBounces;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * BulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(istracking == true)
        {
            rb.velocity = transform.right * BulletSpeed;
        }
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

        if(explosive)
        {
            GameObject boom = Instantiate(explosion);
            boom.transform.position = transform.position;
            boom.GetComponent<Explosion>().Explode();
        }

        numberOfBounces++;
        if(numberOfBounces > bulletBouncesAllowed)
        {
            Destroy(gameObject);
        }
    }
}
