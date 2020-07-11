using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardDiff
{
	Easy,
	Medium,
	Hard
};

[Serializable]
public class Card
{
	public CardType cardType;
	public string name;
	public Sprite image;
	public string desc;
	public int count = 1;
	public CardDiff diff = CardDiff.Easy;

	public Card(CardType cardType, string name, string desc, Sprite image, CardDiff diff)
	{
		this.cardType = cardType;
		this.name = name;
		this.desc = desc;
		this.image = image;
		this.diff = diff;
	}

	public Card(CardType cardType, string name, string desc)
	{
		this.cardType = cardType;
		this.name = name;
		this.desc = desc;
		this.image = null;
	}

	public Card MakeCopy()
	{
		return new Card(cardType, name, desc, image, diff);
	}
}
