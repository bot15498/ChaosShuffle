using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
	PlayerIncreaseHealth,
	PlayerTakeDamage,
	PlayerFireRateIncrease,
	PlayerDamageIncrease,
	PartyHat,
	EveryoneKeepAttacking,
	EveryoneNoDamageOnlyMoney,
	EveryoneBouncingBullets,
	EveryoneNoMovement,
	EnvironmentMakeDarker,
	Orphans,
	PlayerMultishot,
	PlayerDamageGivesGold,
	EveryoneSpinning,
	PlayerLifesteal,
	EnvironmentChangeMusic,
	EveryoneMeleeMode,
	PlayerExplosiveRounds,
	EveryoneExplodingBodies,
	EnvironmentLavaWalls,
	PlayerBigBullet,
	PlayerSmallBullet,
	EveryoneSlow,
	EveryoneFast,
	EnemiesInvisible,
	EveryoneIceFloor,
	EnvironmentShopkeeper,
	PlayerReverseControls,
	PlayerArrowKeys,
	EveryoneCarpetBomber,
	PlayerHeatSeaking,
	EveryoneAllDirectionShoot,
	EveryoneSnakeMovement,
	PlayerLoseMoneyOnHit,
	EnvironmentMakeBrighter,
	CameraCRT,
	CameraSelfie,
	CameraWavy,
	CameraBlurry,
    EnvironmentShorterCardDraw
}

public class CardManager : MonoBehaviour
{
	public GameObject cardUIHolder;
	public List<Card> allEnvCards = new List<Card>();
	public List<Card> allPlayerCards = new List<Card>();
	public List<Card> activeEnvCards = new List<Card>();
	public List<Card> currEnvCards = new List<Card>();
	public List<Card> currPlayerCards = new List<Card>();
    public Image TimerImage;
    AudioSource As;

	public float drawInterval = 10f;
	private float timeRemaining;

	private List<UpdateableEntity> observers = new List<UpdateableEntity>();

	void Start()
	{
        As = GetComponent<AudioSource>();
		timeRemaining = drawInterval;

		foreach (Card card in allEnvCards)
		{
			currEnvCards.Add(card.MakeCopy());
		}
        foreach (Card card in allPlayerCards)
        {
            currEnvCards.Add(card.MakeCopy());
        }
    }

	void Update()
	{
        // updates UI and draws new card every set amount of time.a
        TimerImage.fillAmount = timeRemaining / drawInterval;
        timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0)
		{
			timeRemaining = drawInterval;
            As.Play();
			DrawNewCard();
		}

        // DEBUGGING
        if(Input.GetKeyDown(KeyCode.F))
        {
            Card testCard = new Card(CardType.PartyHat, "test", "test");
            Card testCard2 = new Card(CardType.Orphans, "test", "test");
            BroadcastUpdate(testCard);
            BroadcastUpdate(testCard2);
        }
    }

	public void PlayCard(Card card)
	{
		// For when the player wants to add a card to the pool
		currEnvCards.Add(card);

		//activePlayerCards.Add(card);
		//cardUIHolder.GetComponent<CardUIHolder>().AddCard(card);
		//BroadcastUpdate();
	}

	private void DrawNewCard()
	{
		// For when env wants to draw new card.
		int idx = Random.Range(0, currEnvCards.Count);
		Card currRandomCard = currEnvCards[idx];
		if (activeEnvCards.Contains(currRandomCard))
		{
			currRandomCard.count++;
		}
		else
		{
			activeEnvCards.Add(currRandomCard);
		}
		cardUIHolder.GetComponent<CardUIHolder>().AddCard(currRandomCard);
		BroadcastUpdate(currRandomCard);
	}

	public void BroadcastUpdate(Card recentlyAdded)
	{
		// send update
		foreach (UpdateableEntity e in observers)
		{
			e.ReceiveUpdate(recentlyAdded);
		}
	}

	public void AddObserver(UpdateableEntity entity)
	{
		observers.Add(entity);
	}

    public void RemoveObserver(UpdateableEntity entity)
    {
        observers.Remove(entity);
    }
}
