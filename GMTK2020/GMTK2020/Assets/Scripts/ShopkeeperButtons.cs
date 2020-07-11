using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopkeeperButtons : MonoBehaviour
{
	public Text nameText;
	public Text descText;
	public Image image;
	public Text costText;
	public GameObject cover;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void HideCard()
	{
		cover.SetActive(true);
	}

	public void ShowCard()
	{
		cover.SetActive(false);
	}

	public void UpdateCard(Card card, int cost)
	{
		nameText.text = card.name;
		descText.text = card.desc;
		image.sprite = card.image;
		costText.text = cost.ToString() + " Gold";
	}
}
