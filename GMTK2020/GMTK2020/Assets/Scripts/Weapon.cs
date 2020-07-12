using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public bool canShoot = true;
    public float damage;
    public float fireRate;
    public bool onlyShoot = false;
    public bool explosive = false;
    public GameObject bulletToSpawn;
    public Transform gunBarrel;
    public float recoilForce;
    public PlayerMovement movement;
    public int allowedBulletBounces = 0;
    public float recoil = 500f;
    public float recoilStopTime = 0.1f;
    public int numberOfBullets = 1;
    public float angleDiffBetweenBullets = 20f;
    public bool touhouMode = false;

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
        if (canShoot && (Input.GetKeyDown(KeyCode.Mouse0) || onlyShoot) && timer >= fireRate)
        {
            float startAngle = (180f - (numberOfBullets - 1) * angleDiffBetweenBullets) / 2f - 90f;
            for (float i=0;i<numberOfBullets;i++)
            {
                Quaternion angleToApply = Quaternion.AngleAxis(startAngle + i * angleDiffBetweenBullets, gunBarrel.forward);
                GameObject spawnedBullet;
                spawnedBullet = Instantiate(bulletToSpawn, gunBarrel.position, gunBarrel.rotation * angleToApply);
                spawnedBullet.GetComponent<BulletBehavior>().bulletBouncesAllowed = allowedBulletBounces;
                BulletBehavior Bbehave = spawnedBullet.GetComponent<BulletBehavior>();
                Bbehave.updateDamage(damage);
                Bbehave.explosive = explosive;
            }
            timer = 0;
            if(onlyShoot)
            {
                movement.AddKnockback(transform.position - gunBarrel.position, recoil, recoilStopTime);
            }
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

    public void ActivateTouhouMode()
    {

    }
}
