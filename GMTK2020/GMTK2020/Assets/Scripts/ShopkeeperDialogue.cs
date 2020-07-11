using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperDialogue : MonoBehaviour
{
	public ShopkeeperMenu shopScreen;
	public CardManager cardManager;
	[SerializeField]
	private Weapon wepon;

	private bool canOpenShop = false;
	private bool shopOpen = false;
	[SerializeField]
	private bool showCards = false;
	private List<Card> easyCards;
	private List<Card> medCards;
	private List<Card> hardCards;

	private Card easyCard;
	private Card medCard;
	private Card hardCard;

	// Start is called before the first frame update
	void Start()
    {
		if(cardManager == null)
		{
			cardManager = FindObjectOfType<CardManager>();
		}
		if (shopScreen == null)
		{
			shopScreen = FindObjectOfType<ShopkeeperMenu>();
		}
		if(wepon == null)
		{
			PlayerMovement move = FindObjectOfType<PlayerMovement>();
			wepon = move.gameObject.GetComponentInChildren<Weapon>();
		}
	}

    // Update is called once per frame
    void Update()
    {
        if(canOpenShop && Input.GetKeyUp(KeyCode.E))
		{
			if(!shopOpen)
			{
				RollForCards();
				Time.timeScale = 0f;
				wepon.canShoot = false;
				shopOpen = true;
				shopScreen.ShowShop(easyCard, medCard, hardCard);
			}
			else
			{
				Time.timeScale = 1f;
				wepon.canShoot = true;
				shopOpen = false;
				shopScreen.HideShop();
			}
		}
    }

	public void SayDialogue(List<string> lines)
	{

	}

	private void RollForCards()
	{
		// pick the cards to sell.
		easyCards = cardManager.allPlayerCards.FindAll(e => e.diff == CardDiff.Easy);
		medCards = cardManager.allPlayerCards.FindAll(e => e.diff == CardDiff.Medium);
		hardCards = cardManager.allPlayerCards.FindAll(e => e.diff == CardDiff.Hard);
		easyCard = easyCards[(int)Random.Range(0, easyCards.Count)];
		medCard = medCards[(int)Random.Range(0, medCards.Count)];
		hardCard = hardCards[(int)Random.Range(0, hardCards.Count)];
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		canOpenShop = true;
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		canOpenShop = false;
	}
}
