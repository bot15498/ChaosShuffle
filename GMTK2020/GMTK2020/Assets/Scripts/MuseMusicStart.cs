using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuseMusicStart : MonoBehaviour, UpdateableEntity
{
    public List<AudioClip> bgms = new List<AudioClip>();

    private AudioSource source;
    private int currMusic = 0;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        source.clip = bgms[0];
        source.Play();
        FindObjectOfType<CardManager>().AddObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveUpdate(Card activeCard)
    {
        switch(activeCard.cardType)
        {
            case CardType.EnvironmentChangeMusic:
                currMusic = (currMusic + 1) % bgms.Count;
                source.clip = bgms[currMusic];
                source.Play();
                break;
        }
    }
}
