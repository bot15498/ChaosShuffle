using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListener : MonoBehaviour, UpdateableEntity
{
    private PlayerHealth health;
    private Weapon wepon;
    private PlayerMovement movement;
    private CardManager cardManager;

    private bool wallLava = false;

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
                movement.speed -= 1f;
                movement.icySpeed -= 0.6f;
                if(movement.speed < 1f) { movement.speed = 1f; }
                if(movement.icySpeed < 0.5f) { movement.icySpeed = 0.5f; }
                break;
            case CardType.EveryoneFast:
                movement.speed += 1f;
                movement.icySpeed += 0.6f;
                break;
            case CardType.EveryoneIceFloor:
                movement.icyFloor = !movement.icyFloor;
                break;
            case CardType.EnvironmentLavaWalls:
                wallLava = !wallLava;
                break;
            case CardType.EveryoneNoMovement:
                movement.canControlMove = !movement.canControlMove;
                movement.StopMoving();
                break;
            case CardType.EveryoneSnakeMovement:
                movement.snakeMovement = !movement.snakeMovement;
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(wallLava && collision.gameObject.tag == "Wall")
        {
            health.MinusHealth(1);
        }
    }
}
