using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopkeeperMenu : MonoBehaviour
{
	public ShopkeeperButtons easyCardButton;
	public ShopkeeperButtons medCardButton;
	public ShopkeeperButtons hardCardButton;
    public GameObject bgFilter;
	public Text exitText;

	[SerializeField]
	private int easyCost = 100;
	[SerializeField]
	private int medCost = 500;
	[SerializeField]
	private int hardCost = 3000;
	private MoneyManager muns;
	private CardManager cardManager;
	private Card easyCard;
	private Card medCard;
	private Card hardCard;

	// Start is called before the first frame update
	void Start()
	{
		if (muns == null)
		{
			muns = FindObjectOfType<MoneyManager>();
		}
		if(cardManager == null)
		{
			cardManager = FindObjectOfType<CardManager>();
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ShowShop(Card easyCard, Card medCard, Card hardCard, bool actuallyShowCards = false)
	{
		this.easyCard = easyCard;
		this.medCard = medCard;
		this.hardCard = hardCard;
		easyCardButton.gameObject.SetActive(true);
		medCardButton.gameObject.SetActive(true);
		hardCardButton.gameObject.SetActive(true);
        bgFilter.SetActive(true);
		if (muns.currentMoney < easyCost) { easyCardButton.GetComponent<Button>().interactable = false; } else { easyCardButton.GetComponent<Button>().interactable = true; }
		if (muns.currentMoney < medCost) { medCardButton.GetComponent<Button>().interactable = false; } else { medCardButton.GetComponent<Button>().interactable = true; }
		if (muns.currentMoney < hardCost) { hardCardButton.GetComponent<Button>().interactable = false; } else { hardCardButton.GetComponent<Button>().interactable = true; }
		easyCardButton.UpdateCard(easyCard, GetCost(easyCard.diff));
		medCardButton.UpdateCard(medCard, GetCost(medCard.diff));
		hardCardButton.UpdateCard(hardCard, GetCost(hardCard.diff));
		if (actuallyShowCards)
		{
			easyCardButton.ShowCard();
			medCardButton.ShowCard();
			hardCardButton.ShowCard();
		}
		else
		{
			easyCardButton.HideCard();
			medCardButton.HideCard();
			hardCardButton.HideCard();
		}
	}

	public void HideShop()
	{
		easyCardButton.gameObject.SetActive(false);
		medCardButton.gameObject.SetActive(false);
		hardCardButton.gameObject.SetActive(false);
        bgFilter.SetActive(false);
    }

    private int GetCost(CardDiff diff)
	{
		switch (diff)
		{
			case CardDiff.Easy:
				return easyCost;
			case CardDiff.Medium:
				return medCost;
			case CardDiff.Hard:
			default:
				return hardCost;
		}
	}

	public void BuyEasyCard()
	{
		easyCardButton.GetComponent<Button>().interactable = false;
		muns.minusMoney(easyCost);
		cardManager.PlayCard(easyCard);
	}

	public void BuyMedCard()
	{
		medCardButton.GetComponent<Button>().interactable = false;
		muns.minusMoney(medCost);
		cardManager.PlayCard(medCard);
	}

	public void BuyHardCard()
	{
		hardCardButton.GetComponent<Button>().interactable = false;
		muns.minusMoney(hardCost);
		cardManager.PlayCard(hardCard);
	}
}
