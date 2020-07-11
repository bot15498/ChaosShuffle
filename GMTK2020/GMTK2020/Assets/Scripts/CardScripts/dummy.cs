using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummy : MonoBehaviour, UpdateableEntity
{
	private CardManager cardManager;

	public void ReceiveUpdate(List<Card> activeCards)
	{
		foreach(Card c in activeCards)
		{
			Debug.Log(c.name + ", " + c.desc);
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		cardManager = FindObjectOfType<CardManager>();
		cardManager.AddObserver(this);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
