using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, UpdateableEntity
{
	public float baseHealth;
	[SerializeField]
	private float MaxHealth;
	[SerializeField]
	private float currentHealth;
    public bool CanTakeDamage;
    // Start is called before the first frame update
    void Start()
    {
		FindObjectOfType<CardManager>().AddObserver(this);
		MaxHealth = baseHealth;
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

    public void ReceiveUpdate(List<Card> activeCards)
    {
        foreach (Card c in activeCards)
        {
            switch(c.cardType)
			{
				case CardType.IncreasePlayerHealth:
					//update max health to be the difference of what was added versus what will be added.
					// c.count + basehealth is amount to increase max health by, max health is current maxhealth
					AddMaxHealth(c.count + baseHealth - MaxHealth);
					break;
			}
        }
    }


}
