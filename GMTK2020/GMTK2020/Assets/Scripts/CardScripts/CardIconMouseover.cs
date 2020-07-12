using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardIconMouseover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public CardUIHolder uiHolder;
    public Image sprite;
    public Card card;

    private GameObject highlightedCard;

    public void OnPointerEnter(PointerEventData eventData)
    {
        highlightedCard = uiHolder.ShowHighlightedCard(card);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiHolder.HideHighlightedCard(highlightedCard);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(uiHolder == null)
        {
            uiHolder = FindObjectOfType<CardUIHolder>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCard(Card card)
    {
        this.card = card;
        sprite.sprite = card.image;
    }
}
