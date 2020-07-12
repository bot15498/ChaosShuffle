using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	public bool canShoot = true;
    public float damage;
    public float fireRate;
    public GameObject bulletToSpawn;
    public Transform gunBarrel;
    public float recoilForce;
    public Rigidbody2D rb;
    public int allowedBulletBounces = 0;

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
        if (canShoot && Input.GetKeyDown(KeyCode.Mouse0) && timer >= fireRate)
        {
            GameObject spawnedBullet;   
            spawnedBullet = Instantiate(bulletToSpawn, gunBarrel.position, gunBarrel.rotation);
            spawnedBullet.GetComponent<BulletBehavior>().bulletBouncesAllowed = allowedBulletBounces;
            BulletBehavior Bbehave = spawnedBullet.GetComponent<BulletBehavior>();
            Bbehave.updateDamage(damage);
            timer = 0;
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

    void Recoil()
    {
        Vector3 force = -gunBarrel.transform.right * recoilForce;
        rb.AddForce(force);
    }

    public void changeBulletType(GameObject bullettoSwitch)
    {
        bulletToSpawn = bullettoSwitch;
    }
}
