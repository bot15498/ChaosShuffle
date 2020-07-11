using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    // Start is called before the first frame update
    void Start()
    {
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
