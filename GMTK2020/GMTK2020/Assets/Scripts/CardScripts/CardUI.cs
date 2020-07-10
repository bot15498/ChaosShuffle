using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
	[SerializeField]
	public Image sprite;
	[SerializeField]
	public Text nameText;
	[SerializeField]
	public Text descText; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void LoadCard(Card card)
	{
		nameText.text = card.name;
		descText.text = card.desc;
		sprite.sprite = card.image;
	}
}
