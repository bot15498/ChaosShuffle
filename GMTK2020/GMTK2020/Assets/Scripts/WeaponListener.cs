using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponListener : MonoBehaviour, UpdateableEntity
{
    private Weapon wepon;
    private EnemyGun enemyGun;

    private float originalDamage;
    private float originalEnemyDamage;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CardManager>().AddObserver(this);
        enemyGun = GetComponent<EnemyGun>();
        wepon = GetComponent<Weapon>();
        if (wepon != null)
        {
            originalDamage = wepon.damage;
        }
        if (enemyGun != null)
        {
            originalEnemyDamage = enemyGun.damage;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceiveUpdate(Card activeCard)
    {
        switch (activeCard.cardType)
        {
            case CardType.EveryoneBouncingBullets:
                if (wepon != null) { wepon.allowedBulletBounces++; }
                if (enemyGun != null) { enemyGun.allowedBulletBounces++; }
                break;
            case CardType.PlayerExplosiveRounds:
                if (wepon != null)
                {
                    wepon.explosive = !wepon.explosive;
                }
                break;
            case CardType.EveryoneKeepAttacking:
                if (wepon != null)
                {
                    wepon.onlyShoot = !wepon.onlyShoot;
                }
                if (enemyGun != null)
                {
                    enemyGun.onlyShoot = !enemyGun.onlyShoot;
                }
                break;
            case CardType.PlayerMultishot:
                if (wepon != null)
                {
                    wepon.numberOfBullets++;
                }
                break;
            case CardType.EveryoneAllDirectionShoot:
                if (wepon != null)
                {
                    if (wepon.touhouMode) { wepon.DeactivateTouhouMode(); }
                    else { wepon.ActivateTouhouMode(); }
                }
                if (enemyGun != null)
                {
                    if (enemyGun.touhouMode) { enemyGun.DeactivateTouhouMode(); }
                    else { enemyGun.ActivateTouhouMode(); }
                }
                break;
            case CardType.EveryoneSpinning:
                if (enemyGun != null)
                {
                    RotateTowardsPlayer enemyFollow = enemyGun.transform.parent.GetComponent<RotateTowardsPlayer>();
                    enemyFollow.isSpinning = !enemyFollow.isSpinning;
                }
                if (wepon != null)
                {
                    RotateTowardsMouse follow = wepon.transform.parent.GetComponent<RotateTowardsMouse>();
                    follow.isSpinning = !follow.isSpinning;
                }
                break;
            case CardType.EveryoneNoDamageOnlyMoney:
                if (wepon != null)
                {
                    wepon.bulletsDropMoney = !wepon.bulletsDropMoney;
                    wepon.damage = wepon.bulletsDropMoney ? 0 : originalDamage;
                }
                if (enemyGun != null)
                {
                    enemyGun.damage = enemyGun.damage == 0 ? originalDamage : 0;
                }
                break;
            case CardType.PlayerLifesteal:
                if(wepon != null)
                {
                    wepon.canLifesteal = !wepon.canLifesteal;
                }
                break;
        }
    }
}
