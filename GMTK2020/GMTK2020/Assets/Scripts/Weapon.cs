using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public bool bulletsDropMoney = false;
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
    public int touhouModeGuns = 8;
    public float touhouDistanceGunAwayFromCenter = 0.706f;
    public bool canLifesteal = false;

    private float timer;
    private List<GameObject> extraGuns = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (canShoot && (Input.GetAxis("Fire1") > 0.1f || onlyShoot) && timer >= fireRate)
        {
            float startAngle = (180f - (numberOfBullets - 1) * angleDiffBetweenBullets) / 2f - 90f;
            for (float i = 0; i < numberOfBullets; i++)
            {
                Quaternion angleToApply = Quaternion.AngleAxis(startAngle + i * angleDiffBetweenBullets, gunBarrel.forward);
                GameObject spawnedBullet;
                spawnedBullet = Instantiate(bulletToSpawn, gunBarrel.position, gunBarrel.rotation * angleToApply);
                spawnedBullet.GetComponent<BulletBehavior>().bulletBouncesAllowed = allowedBulletBounces;
                BulletBehavior Bbehave = spawnedBullet.GetComponent<BulletBehavior>();
                Bbehave.updateDamage(damage);
                Bbehave.explosive = explosive;
                Bbehave.dropMoney = bulletsDropMoney;
                Bbehave.originTag = "Player";
                Bbehave.canLifesteal = canLifesteal;
            }
            timer = 0;
            if (onlyShoot)
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
        if(touhouMode) { return; }
        touhouMode = true;
        float angleBetweenGuns = 360f / touhouModeGuns;
        for (float i = angleBetweenGuns; i < 360f; i += angleBetweenGuns)
        {
            Quaternion angleToApply = Quaternion.AngleAxis(i, gunBarrel.forward);
            Vector3 vectorAngleToOffset = new Vector2(Mathf.Cos(i), Mathf.Sin(i)) * Mathf.Sqrt(touhouDistanceGunAwayFromCenter);
            GameObject extra = Instantiate(gameObject, transform.parent.position, angleToApply, transform.parent);
            extraGuns.Add(extra);
        }
    }

    public void DeactivateTouhouMode()
    {
        if (!touhouMode) { return; }
        touhouMode = false;
        while(extraGuns.Count > 0)
        {
            GameObject extra = extraGuns[0];
            extraGuns.RemoveAt(0);
            Destroy(extra);
        }
    }
}
