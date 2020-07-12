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
    [SerializeField]
    public Animator anime;

    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anime == null)
        {
            anime = GetComponent<Animator>();
        }
    }

	public void LoadCard(Card card)
	{
		nameText.text = card.name;
		descText.text = card.desc;
		sprite.sprite = card.image;
	}

    public void PlayShowCardAnimation()
    {
        anime.SetBool("showCard", true);
    }

    public void PlayHideCardAnimation()
    {
        anime.SetBool("showCard", false);
    }
}
