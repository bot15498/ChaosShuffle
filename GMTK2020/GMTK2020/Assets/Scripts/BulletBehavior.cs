using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject money;
    public GameObject explosion;
    public bool dropMoney = false;
    public bool richochet;
    public float damage;
    public float BulletSpeed;
    public int bulletBouncesAllowed = 0;
    public bool istracking = false;
    public bool explosive = false;
    public string originTag = "";

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
        if (collision.gameObject.tag == "Enemy" && originTag != "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
            if(dropMoney)
            {
                Vector3 randomPoint = Random.insideUnitCircle *0.8f;
                Instantiate(money, transform.position + randomPoint, transform.rotation * Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Player" && originTag != "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().MinusHealth(damage);
            Destroy(gameObject);
            return;
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
