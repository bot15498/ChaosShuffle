using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListener : MonoBehaviour, UpdateableEntity
{
    public GameObject explosion;
    private EnemyMovement movement;
    private EnemyHealth health;
    private CardManager cardManager;
    private bool wallLava = false;
    private bool isInvisible = false;

    public void ReceiveUpdate(Card activeCard)
    {
        switch (activeCard.cardType)
        {
            case CardType.EveryoneFast:
                movement.speed += 1f;
                movement.icySpeed += 0.6f;
                break;
            case CardType.EveryoneSlow:
                movement.speed -= 1f;
                movement.icySpeed -= 0.6f;
                if (movement.speed < 1f) { movement.speed = 1f; }
                if (movement.icySpeed < 0.5f) { movement.icySpeed = 0.5f; }
                break;
            case CardType.EveryoneIceFloor:
                movement.icyfloor = !movement.icyfloor;
                break;
            case CardType.EnvironmentLavaWalls:
                wallLava = !wallLava;
                break;
            case CardType.EveryoneNoMovement:
                movement.canMove = !movement.canMove;
                movement.StopMoving();
                break;
            case CardType.EveryoneSnakeMovement:
                movement.snakeMovement = !movement.snakeMovement;
                break;
            case CardType.EveryoneExplodingBodies:
                health.ToggleExplodeOnDeath(explosion);
                break;
            case CardType.EnemiesInvisible:
                isInvisible = !isInvisible;
                SpriteRenderer[] srs = transform.GetComponentsInChildren<SpriteRenderer>();
                foreach(SpriteRenderer sr in srs)
                {
                    if (isInvisible)
                    {
                        sr.enabled = false;
                    }
                    else
                    {
                        sr.enabled = true;
                    }
                }
                transform.GetComponent<SpriteRenderer>().enabled = !isInvisible;
                break;
            case CardType.PlayerDamageGivesGold:
                health.dropMoneyOnDamage = !health.dropMoneyOnDamage;
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        cardManager = FindObjectOfType<CardManager>();                                                                                                                             
        cardManager.AddObserver(this);
        movement = GetComponent<EnemyMovement>();
        health = GetComponent<EnemyHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (wallLava && collision.gameObject.tag == "Wall")
        {
            health.takeDamage(1f);
        }
    }
}
