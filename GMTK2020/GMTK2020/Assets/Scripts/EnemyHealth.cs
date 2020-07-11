using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    EnemyManager Em;
    // Start is called before the first frame update
    void Awake()
    {
        Em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>();
        Em.addEnemy();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(float damageToTake)
    {
        currentHealth -= damageToTake;
        if(currentHealth <= 0)
        {
            DIE();
        }
    }

    void DIE()
    {

    }
}
