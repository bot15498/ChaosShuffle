using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUIHolder : MonoBehaviour
{
    public GameObject cardPrefab;
    public IconHolder iconHolder;

    public float holdDuration = 3f;
    private float moveSpeed = 900f;
    private float posOffset = 500f;

    void Start()
    {

    }


    void Update()
    {

    }

    public void AddCard(Card card)
    {
        // animate the showing
        StartCoroutine(PeekShowCard(card));
        // add the icon
        iconHolder.AddCardToIcon(card);
    }

    public GameObject ShowHighlightedCard(Card card)
    {
        // shows the card (but doesn't make it go away)
        // make the prefab
        GameObject obj = Instantiate(cardPrefab);
        obj.transform.SetParent(transform);
        obj.transform.localScale = Vector3.one;
        obj.transform.localPosition = new Vector2(0, posOffset);
        //put the card data on it
        CardUI cardUI = obj.GetComponent<CardUI>();
        cardUI.LoadCard(card);
        cardUI.PlayShowCardAnimation();

        return obj;
    }

    public void HideHighlightedCard(GameObject obj)
    {
        // Hides the card that is currently on screen
        StartCoroutine(HideCard(obj));
    }

    private IEnumerator PeekShowCard(Card card)
    {
        // make the prefab
        GameObject obj = Instantiate(cardPrefab);
        obj.transform.SetParent(transform);
        obj.transform.localScale = Vector3.one;
        obj.transform.localPosition = new Vector2(0, posOffset);
        //put the card data on it
        CardUI cardUI = obj.GetComponent<CardUI>();
        cardUI.LoadCard(card);

        // animate it showing, then leaving
        cardUI.PlayShowCardAnimation();
        yield return new WaitForSecondsRealtime(holdDuration);
        cardUI.PlayHideCardAnimation();
        yield return new WaitForSecondsRealtime(2f);
        Destroy(obj);
    }

    private IEnumerator ShowCardHold(GameObject cardToShow)
    {
        while (cardToShow.transform.localPosition.y > 0)
        {
            Vector2 position = cardToShow.transform.localPosition;
            position.y -= moveSpeed * Time.deltaTime;
            cardToShow.transform.localPosition = position;
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator HideCard(GameObject cardToHide)
    {
        cardToHide.GetComponent<CardUI>().PlayHideCardAnimation();
        while (!cardToHide.GetComponent<CardUI>().anime.GetCurrentAnimatorStateInfo(0).IsName("Hide"))
        {
            yield return new WaitForEndOfFrame();
        }
        Destroy(cardToHide);
    }
}
