using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListener : MonoBehaviour, UpdateableEntity
{
    private EnemyMovement movement;

    public void ReceiveUpdate(Card activeCard)
    {
        switch(activeCard.cardType)
        {
            case CardType.EveryoneFast:
                movement.speed += 1f;
                movement.icySpeed += 0.6f;
                break;
            case CardType.EveryoneSlow:
                movement.speed -= 1f;
                movement.icySpeed -= 0.6f;
                break;
            case CardType.EveryoneIceFloor:
                movement.icyfloor = !movement.icyfloor;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
