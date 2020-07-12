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
        }
    }
}
