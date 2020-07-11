using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardUIHolder : MonoBehaviour
{
    public GameObject cardPrefab;

    private float holdDuration = 3f;
    private float moveSpeed = 900f;
    private float posOffset = 500f;
    private List<GameObject> activeCards = new List<GameObject>();

    void Start()
    {

    }


    void Update()
    {

    }

    public void AddCard(Card card)
    {
        StartCoroutine(PeekShowCard(card));
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
        while (obj.transform.localPosition.y > 0)
        {
            Vector2 position = obj.transform.localPosition;
            position.y -= moveSpeed * Time.deltaTime;
            obj.transform.localPosition = position;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(holdDuration);
        while (obj.transform.localPosition.y < posOffset)
        {
            Vector2 position = obj.transform.localPosition;
            position.y += moveSpeed * Time.deltaTime;
            obj.transform.localPosition = position;
            yield return new WaitForEndOfFrame();
        }
        Destroy(obj);

        //add obj to icon UI
    }

    private IEnumerator SlideObjectsDown(Card card)
    {
        //slide other cards down
        if (activeCards.Count > 0)
        {
            float topOldPos = activeCards[0].transform.localPosition.y;
            while (activeCards[0].transform.localPosition.y > topOldPos - posOffset)
            {
                foreach (GameObject gameobj in activeCards)
                {
                    //float oldPos = activeCards[activeCards.Count - 1].transform.localPosition.y;
                    Vector2 position = gameobj.transform.localPosition;
                    position.y -= moveSpeed * Time.deltaTime;
                    //if (position.y < oldPos - posOffset)
                    //{
                    //	position.y = oldPos - posOffset;
                    //}
                    gameobj.transform.localPosition = position;
                }
                yield return new WaitForEndOfFrame();
            }
        }

        // make the prefab
        GameObject obj = Instantiate(cardPrefab);
        obj.transform.SetParent(transform);
        obj.transform.localPosition = new Vector2(0, -40);
        //put the card data on it
        CardUI cardUI = obj.GetComponent<CardUI>();
        cardUI.LoadCard(card);
        activeCards.Add(obj);
    }
}
