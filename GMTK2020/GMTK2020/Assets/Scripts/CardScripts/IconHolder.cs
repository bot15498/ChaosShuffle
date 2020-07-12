using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconHolder : MonoBehaviour
{
    public GameObject IconPrefab;

    private int activeIcons = 0;
    private int maxIconsInRow = 12;
    private float iconGridOffset = 120f;
    private CardManager cardManager;
    private Dictionary<Card, GameObject> visibleCardIcons = new Dictionary<Card, GameObject>();
    private List<GameObject> iconsOnscreen = new List<GameObject>();

    void Start()
    {
        if(cardManager == null)
        {
            cardManager = FindObjectOfType<CardManager>();
        }
    }

    void Update()
    {

    }

    public void AddCardToIcon(Card card)
    {
        // check to see if card exists if it doesnt, add as new icon
        if(!visibleCardIcons.ContainsKey(card))
        {
            if(card.cardType != CardType.PlayerTakeDamage 
                && card.cardType != CardType.EveryoneCarpetBomber
                && card.cardType != CardType.EnvironmentShopkeeper)
            {
                SpawnIcon(card);
            }
        }
        else
        {
            // basically deal with the inversion ones
            switch(card.cardType)
            {
                case CardType.EveryoneNoMovement:
                case CardType.EveryoneKeepAttacking:
                case CardType.EveryoneNoDamageOnlyMoney:
                case CardType.Orphans:
                case CardType.EveryoneSpinning:
                case CardType.PlayerExplosiveRounds:
                case CardType.EveryoneExplodingBodies:
                case CardType.EnvironmentLavaWalls:
                case CardType.EnemiesInvisible:
                case CardType.EveryoneIceFloor:
                case CardType.PlayerReverseControls:
                case CardType.PlayerArrowKeys:
                case CardType.PlayerHeatSeaking:
                case CardType.EveryoneAllDirectionShoot:
                case CardType.PlayerDamageGivesGold:
                case CardType.EveryoneSnakeMovement:
                    if(card.count % 2 == 0) { KillIcon(card); }
                    break;
            }
        }
    }

    private void SpawnIcon(Card card)
    {
        // get row and col of where to put icon
        int row = activeIcons / maxIconsInRow;
        int col = activeIcons % maxIconsInRow;
        // make icon and put it there.
        GameObject icon = Instantiate(IconPrefab);
        icon.GetComponent<CardIconMouseover>().SetCard(card);
        icon.transform.SetParent(transform);
        icon.transform.localScale = Vector3.one;
        icon.transform.localPosition = new Vector2(iconGridOffset * col, iconGridOffset * -row);

        visibleCardIcons.Add(card, icon);
        iconsOnscreen.Add(icon);
        activeIcons++;
    }

    private void KillIcon(Card card)
    {
        GameObject icon = visibleCardIcons[card];
        iconsOnscreen.Remove(icon);
        visibleCardIcons.Remove(card);
        Destroy(icon);
        activeIcons--;

        // I'm lazy so just go through and move each icon again
        int iconCount = 0;
        foreach(GameObject i in iconsOnscreen)
        {
            int row = iconCount / maxIconsInRow;
            int col = iconCount % maxIconsInRow;
            i.transform.localPosition = new Vector2(iconGridOffset * col, iconGridOffset * -row);
            iconCount++;
        }
    }
}
