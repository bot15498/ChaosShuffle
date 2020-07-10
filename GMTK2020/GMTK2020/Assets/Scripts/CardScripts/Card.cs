using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card
{
	public string name;
	public Sprite image;
	public string desc;

	public Card(string name, string desc, Sprite image)
	{
		this.name = name;
		this.desc = desc;
		this.image = image;
	}

	public Card(string name, string desc)
	{
		this.name = name;
		this.desc = desc;
		this.image = null;
	}
}
