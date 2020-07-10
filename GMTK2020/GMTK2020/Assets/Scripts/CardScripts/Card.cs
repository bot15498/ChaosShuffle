using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card
{
	public CardType cardType;
	public string name;
	public Sprite image;
	public string desc;

	public Card(CardType cardType, string name, string desc, Sprite image)
	{
		this.cardType = cardType;
		this.name = name;
		this.desc = desc;
		this.image = image;
	}

	public Card(CardType cardType, string name, string desc)
	{
		this.cardType = cardType;
		this.name = name;
		this.desc = desc;
		this.image = null;
	}
}
