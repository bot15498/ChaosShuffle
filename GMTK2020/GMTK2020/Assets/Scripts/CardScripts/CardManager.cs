using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
	PartyHat,
	Orphans,
	NoMove
}

public class CardManager : MonoBehaviour
{
	public Text timerText;
	public List<Card> allCards = new List<Card>();
	public List<Card> activePlayerCards = new List<Card>();
	public List<Card> activeRandomCards = new List<Card>();
	public List<Card> currentCards = new List<Card>();
	public List<Card> playerCards = new List<Card>();

	[SerializeField]
	private float drawInterval = 10f;
	private float timeRemaining;
	[SerializeField]
	private int maxPlayerCards = 1;
	[SerializeField]
	private int maxRandomCards = 1;

	private List<UpdateableEntity> observers = new List<UpdateableEntity>();

	void Start()
	{
		timeRemaining = drawInterval;

		currentCards.AddRange(allCards);
	}

	void Update()
	{
		// updates UI and draws new card every set amount of time.
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
		if(activePlayerCards.Count > maxPlayerCards)
		{
			activePlayerCards.RemoveAt(0);
		}
		BroadcastUpdate();
	}

	private void DrawNewCard()
	{
		// For when env wants to draw new card.
		int idx = Random.Range(0, currentCards.Count);
		Card currRandomCard = currentCards[idx];
		activeRandomCards.Add(currRandomCard);
		if (activeRandomCards.Count > maxRandomCards)
		{
			activeRandomCards.RemoveAt(0);
		}
		BroadcastUpdate();
	}

	public void BroadcastUpdate()
	{
		// Merge lists together and send
		List<Card> cards = new List<Card>(activePlayerCards.Count + activeRandomCards.Count);
		cards.AddRange(activePlayerCards);
		cards.AddRange(activeRandomCards);
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
