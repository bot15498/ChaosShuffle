using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
	PartyHat,
	Orphans,
	NoMove,
	IncreasePlayerHealth,
	DecreasePlayerHealth
}

public class CardManager : MonoBehaviour
{
	public Text timerText;
	public GameObject cardUIHolder;
	public List<Card> allEnvCards = new List<Card>();
	public List<Card> allPlayerCards = new List<Card>();
	public List<Card> activePlayerCards = new List<Card>();
	public List<Card> activeEnvCards = new List<Card>();
	public List<Card> currEnvCards = new List<Card>();
	public List<Card> currPlayerCards = new List<Card>();

	[SerializeField]
	private float drawInterval = 10f;
	private float timeRemaining;

	private List<UpdateableEntity> observers = new List<UpdateableEntity>();

	void Start()
	{
		timeRemaining = drawInterval;

		foreach(Card card in allEnvCards)
		{
			currEnvCards.Add(card.MakeCopy());
		}
	}

	void Update()
	{
		// updates UI and draws new card every set amount of time.a
		timeRemaining -= Time.deltaTime;
		timerText.text = ((int) timeRemaining).ToString();
		if(timeRemaining <= 0)
		{ 
			timeRemaining = drawInterval;
			DrawNewCard();
		}
	}

	public void PlayCard(Card card)
	{
		// For when the player wants to play a card
		activePlayerCards.Add(card);
		cardUIHolder.GetComponent<CardUIHolder>().AddCard(card);
		BroadcastUpdate();
	}

	private void DrawNewCard()
	{
		// For when env wants to draw new card.
		int idx = Random.Range(0, currEnvCards.Count);
		Card currRandomCard = currEnvCards[idx];
		if(activeEnvCards.Contains(currRandomCard))
		{
			currRandomCard.count++;
		}
		else
		{
			activeEnvCards.Add(currRandomCard);
		}
		cardUIHolder.GetComponent<CardUIHolder>().AddCard(currRandomCard);
		BroadcastUpdate();
	}

	public void BroadcastUpdate()
	{
		// Merge lists together and send
		List<Card> cards = new List<Card>(activePlayerCards.Count + activeEnvCards.Count);
		cards.AddRange(activePlayerCards);
		cards.AddRange(activeEnvCards);
		// send update
		foreach (UpdateableEntity e in observers)
		{
			e.ReceiveUpdate(cards);
		}
	}

	public void AddObserver(UpdateableEntity entity)
	{
		observers.Add(entity);
	}
}
