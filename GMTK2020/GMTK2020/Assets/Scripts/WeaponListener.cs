using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponListener : MonoBehaviour, UpdateableEntity
{
    private Weapon wepon;
    private EnemyGun enemyGun;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<CardManager>().AddObserver(this);
        if(wepon == null)
        {
            wepon = GetComponent<Weapon>();            
        }
        if(enemyGun == null)
        {
            enemyGun = GetComponent<EnemyGun>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveUpdate(Card activeCard)
    {
        switch(activeCard.cardType)
        {
            case CardType.EveryoneBouncingBullets:
                if(wepon != null) { wepon.allowedBulletBounces++; }
                if(enemyGun != null) { enemyGun.allowedBulletBounces++; }
                break;
            case CardType.PlayerExplosiveRounds:
                if (wepon != null)
                {
                    wepon.explosive = !wepon.explosive;
                }
                break;
            case CardType.EveryoneKeepAttacking:
                if(wepon != null)
                {
                    wepon.onlyShoot = !wepon.onlyShoot;
                }
                if(enemyGun != null)
                {
                    enemyGun.onlyShoot = !enemyGun.onlyShoot;
                }
                break;
            case CardType.PlayerMultishot:
                if(wepon!= null)
                {
                    wepon.numberOfBullets++;
                }
                break;
            case CardType.EveryoneAllDirectionShoot:
                if(wepon != null)
                {
                    if(wepon.touhouMode) { wepon.DeactivateTouhouMode(); }
                    else { wepon.ActivateTouhouMode(); }
                }
                if(enemyGun != null)
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
        }
    }
}
