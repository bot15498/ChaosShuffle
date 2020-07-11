using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListener : MonoBehaviour, UpdateableEntity
{
    private PlayerHealth health;
    private Weapon wepon;
    private PlayerMovement movement;
    private CardManager cardManager;

    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<PlayerHealth>();
        wepon = GetComponentInChildren<Weapon>();
        movement = GetComponent<PlayerMovement>();
        cardManager = FindObjectOfType<CardManager>();
        cardManager.AddObserver(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReceiveUpdate(Card activeCard)
    {
        switch (activeCard.cardType)
        {
            case CardType.PlayerIncreaseHealth:
                health.AddMaxHealth(1);
                break;
            case CardType.PlayerTakeDamage:
                health.MinusHealth(1);
                break;
            case CardType.PlayerArrowKeys:
                movement.useArrowKeys = !movement.useArrowKeys;
                break;
            case CardType.PlayerReverseControls:
                movement.mirrored = !movement.mirrored;
                break;
            case CardType.PlayerDamageIncrease:
                wepon.damage += 1;
                break;
            case CardType.PlayerFireRateIncrease:
                wepon.fireRate -= 0.1f;
                break;
            case CardType.EveryoneSlow:
                movement.speed += 1f;
                movement.icySpeed += 0.6f;
                break;
            case CardType.EveryoneFast:
                break;
            case CardType.EveryoneIceFloor:
                movement.icyFloor = !movement.icyFloor;
                break;
        }
    }
}
