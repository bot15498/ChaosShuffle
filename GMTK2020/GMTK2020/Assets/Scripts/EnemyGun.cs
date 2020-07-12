using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public bool canShoot = true;
    public bool onlyShoot = false;
    public float damage;
    public float fireRate;
    public float knockbackForce = 500f;
    public float knockbackTimeWait = 0.3f;
    public GameObject bulletToSpawn;
    public Transform gunBarrel;
    public float recoilForce;
    public EnemyMovement movement;
    public int allowedBulletBounces;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((canShoot || onlyShoot) && timer >= fireRate)
        {
            GameObject spawnedBullet;
            spawnedBullet = Instantiate(bulletToSpawn, gunBarrel.position, gunBarrel.rotation);
            spawnedBullet.GetComponent<BulletBehavior>().bulletBouncesAllowed = allowedBulletBounces;
            BulletBehavior Bbehave = spawnedBullet.GetComponent<BulletBehavior>();
            Bbehave.updateDamage(damage);
            timer = 0;
        }
        if(onlyShoot)
        {
            movement.AddKnockback(transform.position - gunBarrel.position, knockbackForce, knockbackTimeWait);
        }
    }


    public void ChangeFireRate(float fireRateChange)
    {
        fireRate += fireRateChange;
    }
    public void ChangeDamage(float damageChange)
    {
        damage += damageChange;
    }

    public void changeBulletType(GameObject bullettoSwitch)
    {
        bulletToSpawn = bullettoSwitch;
    }
}
