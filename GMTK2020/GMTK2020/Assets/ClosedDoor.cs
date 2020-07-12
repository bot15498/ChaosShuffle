using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : MonoBehaviour
{
    SpriteRenderer sr;
    EnemyManager Em;
    // Start is called before the first frame update
    void Start()
    {
        Em = GameObject.FindGameObjectWithTag("GameManager").GetComponent<EnemyManager>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Em.currentNumberofenemies > 0)
        {
            sr.enabled = true;
        } else if (Em.currentNumberofenemies <=0) 
        {
            sr.enabled = false;
        }
    }
}
