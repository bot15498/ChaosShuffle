using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    private float currentHealth;
    public bool CanTakeDamage;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        CanTakeDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addHealth(float healthToAdd)
    {
        currentHealth += healthToAdd;
        if (currentHealth >= MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }

    public void AddMaxHealth(float healthToAdd)
    {
        MaxHealth += healthToAdd;
        currentHealth += healthToAdd;
    }

    public void MinusHealth(float healhToMinus)
    {
        if (CanTakeDamage == true) {
            currentHealth -= healhToMinus;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();

            }
        }
    }

    void Die()
    {

    }
}
