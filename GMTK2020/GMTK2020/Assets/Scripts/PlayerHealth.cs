using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public bool loseMoneyOnHit = false;
    public float ratioToLose = 1f;
    public float MaxHealth;
    [SerializeField]
    private float currentHealth;
    public bool CanTakeDamage;
    public Text HealthText;
    public Image HealthBar;
    public float healAmount;

    private MoneyManager mm;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
        CanTakeDamage = true;
        mm = FindObjectOfType<MoneyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = ((int)currentHealth).ToString() + "/" + MaxHealth.ToString();
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
            if(loseMoneyOnHit)
            {
                mm.minusMoney(healhToMinus * ratioToLose);
            }
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();

            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Heart")
        {
            if (currentHealth != MaxHealth)
            {
                addHealth(healAmount);

                Destroy(collision.gameObject);
            }
            
        }
    }

    void Die()
    {
        Debug.Log("ur fucking ded kiddo");
    }
}
