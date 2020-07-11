using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float damage;
    public float BulletSpeed;
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
        
    }

    public void updateDamage(float damagevalue)
    {
        damage = damagevalue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<EnemyHealth>() != null)
        {
            collision.GetComponent<EnemyHealth>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
