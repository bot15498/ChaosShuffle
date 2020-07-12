using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField]
    private float currentHealth;
    public bool CanTakeDamage;
    public Text HealthText;
    public Image HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        CanTakeDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = currentHealth.ToString();
        HealthBar.fillAmount = currentHealth / MaxHealth;
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
