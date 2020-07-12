using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrphanMode : MonoBehaviour, UpdateableEntity
{
    public Sprite orphanSprite;
    public RuntimeAnimatorController orphanController;
    public SpriteRenderer sr;
    public bool isOrphan = false;
    private Sprite oldSprite;
    private RuntimeAnimatorController oldAnime;
    private CardManager cm;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        oldSprite = sr.sprite;
        anim = GetComponent<Animator>();
        if(anim != null)
        {
            oldAnime = anim.runtimeAnimatorController;
        }
        cm = FindObjectOfType<CardManager>();
        cm.AddObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveUpdate(Card activeCard)
    {
        switch(activeCard.cardType)
        {
            case CardType.Orphans:
                if(isOrphan)
                {
                    isOrphan = false;
                    sr.sprite = oldSprite;
                    if(anim != null)
                    {
                        GetComponent<Animator>().runtimeAnimatorController = oldAnime;
                    }
                }
                else
                {
                    isOrphan = true;
                    sr.sprite = orphanSprite;
                    if (anim != null)
                    {
                        GetComponent<Animator>().runtimeAnimatorController = orphanController;
                    }
                }
                break;
        }
    }

    public void OnDestroy()
    {
        cm.RemoveObserver(this);
    }
}
