using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
	public Text timerText;
	public List<Card> allCards = new List<Card>();
	public List<Card> activePlayerCards = new List<Card>();
	public List<Card> activeRandomCards = new List<Card>();
	public List<Card> currentCards = new List<Card>();
	public List<Card> playerCards = new List<Card>();

	[SerializeField]
	private float drawInterval = 30f;
	private float timeRemaining;
	[SerializeField]
	private int maxPlayerCards = 1;
	[SerializeField]
	private int maxRandomCards = 1;

	private List<UpdateableEntity> observers = new List<UpdateableEntity>();

	void Start()
	{
		timeRemaining = drawInterval;
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
		BroadcastUpdate();
	}

	private void DrawNewCard()
	{
		int idx = Random.Range(0, currentCards.Count);
		Card currRandomCard = currentCards[idx];
		PlayCard(currRandomCard);
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
