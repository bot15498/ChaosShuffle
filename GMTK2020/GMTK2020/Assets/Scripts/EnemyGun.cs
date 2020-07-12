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
    public bool touhouMode = false;
    public int touhouModeGuns = 8;
    public float touhouDistanceGunAwayFromCenter = 0.706f;

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

    public void ActivateTouhouMode()
    {
        if (touhouMode) { return; }
        touhouMode = true;
        float angleBetweenGuns = 360f / touhouModeGuns;
        for (float i = angleBetweenGuns; i < 360f; i += angleBetweenGuns)
        {
            Quaternion angleToApply = Quaternion.AngleAxis(i, gunBarrel.forward);
            Vector3 vectorAngleToOffset = new Vector2(Mathf.Cos(i), Mathf.Sin(i)) * Mathf.Sqrt(touhouDistanceGunAwayFromCenter);
            GameObject extra = Instantiate(gameObject, transform.parent.position + vectorAngleToOffset, angleToApply, transform.parent);
            extraGuns.Add(extra);
        }
    }

    public void DeactivateTouhouMode()
    {
        if (!touhouMode) { return; }
        touhouMode = false;
        while (extraGuns.Count > 0)
        {
            GameObject extra = extraGuns[0];
            extraGuns.RemoveAt(0);
            Destroy(extra);
        }
    }
}
