using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopkeeperMenu : MonoBehaviour
{
	public ShopkeeperButtons easyCardButton;
	public ShopkeeperButtons medCardButton;
	public ShopkeeperButtons hardCardButton;

	[SerializeField]
	private int easyCost = 100;
	[SerializeField]
	private int medCost = 500;
	[SerializeField]
	private int hardCost = 3000;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void ShowShop(Card easyCard, Card medCard, Card hardCard, bool actuallyShowCards=false)
	{
		easyCardButton.gameObject.SetActive(true);
		medCardButton.gameObject.SetActive(true);
		hardCardButton.gameObject.SetActive(true);
		easyCardButton.GetComponent<Button>().interactable = true;
		medCardButton.GetComponent<Button>().interactable = true;
		hardCardButton.GetComponent<Button>().interactable = true;
		easyCardButton.UpdateCard(easyCard, GetCost(easyCard.diff));
		medCardButton.UpdateCard(medCard, GetCost(medCard.diff));
		hardCardButton.UpdateCard(hardCard, GetCost(hardCard.diff));
		if(actuallyShowCards)
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
	}

	public void BuyMedCard()
	{
		medCardButton.GetComponent<Button>().interactable = false;
	}

	public void BuyHardCard()
	{
		hardCardButton.GetComponent<Button>().interactable = false;
	}
}
