using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    [SerializeField]
    private float currentHealth;
    public GameObject money;
    public Image HealthBar;
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
        HealthBar.fillAmount = currentHealth / maxHealth;
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
        Em.minusEnemy();
        Instantiate(money, transform.position, transform.rotation * Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Destroy(gameObject);
    }
}
