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
    private GameObject explosion;
    private bool explodeOnDeath = false;
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

    public void ToggleExplodeOnDeath(GameObject explosion)
    {
        explodeOnDeath = !explodeOnDeath;
        this.explosion = explosion;
    }

    void DIE()
    {
        if(explodeOnDeath)
        {
            GameObject boom = Instantiate(explosion);
            boom.transform.position = transform.position;
            boom.GetComponent<Explosion>().Explode();
        }
        
        Instantiate(money, transform.position, transform.rotation * Quaternion.Euler(0, 0, Random.Range(0, 360)));
        Destroy(gameObject);
    }


    private void OnDestroy()
    {

        Em.minusEnemy();

    }
}
